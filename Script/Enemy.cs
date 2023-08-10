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
        
        //0���� 9���� ���߿� �ϳ��� �������� �����ͼ�
        int randValue = Random.Range(0, 10);
        GameObject target = GameObject.Find("Player");
        // ���� 3���� ������ �÷��̾����
        if (target != null)
        {
            if (randValue < 5)
            {
                //GameObject target = GameObject.Find("Player");
                //������ ���ϰ� �ʹ� target - me
                dir = target.transform.position - transform.position;
                //������ ũ�� 1
                dir.Normalize();

            }
            //�׷��� ������ �Ʒ�����
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
        //���ʹ̸� ���� �� ���� ���� ����ǥ���ϰ� �ʹ�
        //GameObject smObject = GameObject.Find("ScoreManager");
        //ScoreManager sm = smObject.GetComponent<ScoreManager>();

        //ScoreManager�� Get/set �Լ��� ����
        //sm.SetScore(sm.GetScore() + 1);
      
        /*sm.currentScore++;
        //ȭ�鿡 ���� ���� ǥ���ϱ�
        sm.currentScoreUI.text = "��������: " + sm.currentScore; //������ ���� ���ڷ� ǥ���

        if(sm.currentScore> sm.bestScore)
        {
            //�ְ������� ����
            sm.bestScore = sm.currentScore;
            //�ְ����� UI�� ǥ��
            sm.bestScoreUI.text = "�ְ�����:" + sm.bestScore;
            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }*/

        if(other.gameObject.name.Contains("Bullet"))
        {
           
            GameObject expiosion = Instantiate(explosionFactory);
            expiosion.transform.position = transform.position;

            if (other.gameObject.name.Contains("Bullet"))
            {
                other.gameObject.SetActive(false);
                //platerFire Ŭ���� ������
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                //list�� �Ѿ� ����
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if(other.gameObject.name.Contains("Enemy"))
            {
                
                GameObject mObject = GameObject.Find("EnemyManager");
                EnemyManager anager = mObject.GetComponent<EnemyManager>();
                //����Ʈ�� �Ѿ� ����
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
        //����Ʈ�� �Ѿ� ����
        manager.enemyObjectPool.Add(other.gameObject);

        gameObject.SetActive(false);

    }



}
