using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Bullet")||other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
       // Destroy(other.gameObject);

        //부딫힌 물체가 총알일 경우 총알 리스트에 삽입
        if(other.gameObject.name.Contains("Bullet"))
        {
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
}
