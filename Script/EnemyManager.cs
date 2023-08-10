using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float creativeTime = 1;
    public GameObject enemyFactory;

    float minTime = 1;
    float maxTime = 5;

    public int poolSize = 10;
    // GameObject[] enemyObjectpool;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        //�¾ �� �� �����ð��� �����ϰ�
        creativeTime = Random.Range(minTime, maxTime);
        //enemyObjectpool = new GameObject[poolSize];

        //���� �� �ִ� ũ��� �����
        enemyObjectPool = new List<GameObject>();

        //���ʹ� ���� ��ŭ �ݺ�
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            //enemyObjectpool[i] = enemy;
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

  
    // Update is called once per frame
    void Update()
    {
        // �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;
        // ����ð��� �����ð��� �Ǹ�
        if(currentTime > creativeTime)
        {
            GameObject enemy = enemyObjectPool[0];
            if (enemyObjectPool.Count > 0)
            {
               
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                
                //�������� �ε��� ����
                int index = Random.Range(0, spawnPoints.Length);
                //���ʹ� ��ġ ��Ű��
                enemy.transform.position = spawnPoints[index].position;
            }

            /*for (int i = 0; i< poolSize; i++)
            {
                GameObject enemy = enemyObjectpool[i];
                if (enemy.activeSelf == false)
                {
                    enemy.SetActive(true);
                    enemy.transform.position = transform.position;
                    break;
                }
            }*/

            //GameObject enemy = Instantiate(enemyFactory);
           // enemy.transform.position = transform.position;

            //���� ������ �� �� �����ð��� �ٽ� �����ϰ� �ʹ�.
            creativeTime = Random.Range(minTime, maxTime);
            currentTime = 0;

            
        }
       
    }
}
