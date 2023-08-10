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
        //태어날 때 적 생성시간을 설정하고
        creativeTime = Random.Range(minTime, maxTime);
        //enemyObjectpool = new GameObject[poolSize];

        //담을 수 있는 크기로 만들기
        enemyObjectPool = new List<GameObject>();

        //에너미 갯수 만큼 반복
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
        // 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 현재시간이 일정시간이 되면
        if(currentTime > creativeTime)
        {
            GameObject enemy = enemyObjectPool[0];
            if (enemyObjectPool.Count > 0)
            {
               
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                
                //랜덤으로 인덱스 선택
                int index = Random.Range(0, spawnPoints.Length);
                //에너미 위치 시키기
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

            //적을 생성한 후 적 생성시간을 다시 설정하고 싶다.
            creativeTime = Random.Range(minTime, maxTime);
            currentTime = 0;

            
        }
       
    }
}
