using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionFactory;
    public float speed = 5;
    Vector3 dir;

   
    // Start is called before the first frame update
    void Start()
    {
        
        //0뷰터 9까지 값중에 하나를 랜덤으로 가져와서
        int randValue = Random.Range(0, 10);
        GameObject target = GameObject.Find("Player");
        // 만약 3보다 작으면 플레이어방향
        if (target != null)
        {
            if (randValue < 5)
            {
                //GameObject target = GameObject.Find("Player");
                //방향을 구하고 싶다 target - me
                dir = target.transform.position - transform.position;
                //방향의 크기 1
                dir.Normalize();

            }
            //그렇지 않으면 아래방향
            else
            {
                dir = Vector3.down;

            }
        }

        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += dir * speed * Time.deltaTime;

       
    }

    private void OnCollisionEnter(Collision other)
    {

        ScoreManager.Instance.Score++;

       
        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        //에너미를 잡을 때 마다 현재 점수표시하고 싶다
        //GameObject smObject = GameObject.Find("ScoreManager");
        //ScoreManager sm = smObject.GetComponent<ScoreManager>();

        //ScoreManager의 Get/set 함수로 수정
        //sm.SetScore(sm.GetScore() + 1);
      
        /*sm.currentScore++;
        //화면에 현재 점수 표시하기
        sm.currentScoreUI.text = "현재점수: " + sm.currentScore; //문자의 합은 문자로 표기됨

        if(sm.currentScore> sm.bestScore)
        {
            //최고점수로 갱신
            sm.bestScore = sm.currentScore;
            //최고점수 UI에 표시
            sm.bestScoreUI.text = "최고점수:" + sm.bestScore;
            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }*/

        if(other.gameObject.name.Contains("Bullet"))
        {
           
            GameObject expiosion = Instantiate(explosionFactory);
            expiosion.transform.position = transform.position;

            if (other.gameObject.name.Contains("Bullet"))
            {
                other.gameObject.SetActive(false);
                //platerFire 클래스 얻어오기
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                //list에 총알 삽입
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if(other.gameObject.name.Contains("Enemy"))
            {
                
                GameObject mObject = GameObject.Find("EnemyManager");
                EnemyManager anager = mObject.GetComponent<EnemyManager>();
                //리스트에 총알 삽입
                anager.enemyObjectPool.Add(other.gameObject);
            }
        }

        else
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);

       
        //Destroy(collision.gameObject);
        //Destroy(this.gameObject);
        
        
        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        //리스트에 총알 삽입
        manager.enemyObjectPool.Add(other.gameObject);

        gameObject.SetActive(false);

    }



}
