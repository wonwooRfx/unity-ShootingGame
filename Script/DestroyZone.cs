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

        //�΋H�� ��ü�� �Ѿ��� ��� �Ѿ� ����Ʈ�� ����
        if(other.gameObject.name.Contains("Bullet"))
        {
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
}
