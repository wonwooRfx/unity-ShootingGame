using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPre;
    public GameObject firePosition;

    public int poolSize = 10;
    //오브젝트풀 배열
    public List<GameObject> bulletObjectPool; //오브젝트풀 배열
    //GameObject[] bulletObjectPool;

    //태어날 때 오브젝트풀에 총알을 하나씩 생성하여 넣고 싶다
    // 태어날 때
    // Start is called before the first frame update
    void Start()
    {


        //탄창을 총알 담을 수 있는 크기로 만들어 준다
        // bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();
        //탄창에 넣을 총알 개수 만큼 반복한다
        for (int i = 0; i< poolSize; i++)
        {
            //비활성화 된 총알을
            // 만약 총알이 비활성화 되었다면
            GameObject bullet = Instantiate(bulletPre) as GameObject;
            //총알을 오브젝트풀에 넣고싶다
            bulletObjectPool.Add(bullet);
            //비활성화시키자
            bullet.SetActive(false);
           
            
           /* if(obj.activeSelf == false)
            {
                //총알을 발사하고 싶다(활성화시킨다)
                obj.SetActive(true);
                //총알을 위치시키기
                obj.transform.position = transform.position;
                //총알 발사 하였기 때문에 비활성화 총알 검색 중단
                break;
            }*/
             
        }
        // 실행되는 플랫폼이 안드로이드일 경우 실행
#if UNITY_ANDROID
       GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif


    }

    // Update is called once per frame
    void Update()
    {
        // 목표: 발사버튼을 누르면 탄창에 있는 총알 중 비활성화된 녀석을 발사 하고 싶다.
        if(Input.GetButtonDown("Fire1"))
        {
            //탄창안에 총알이 있다면
            if(bulletObjectPool.Count>0)
            {
                //비활성화 된 총알을 하나 가져온다
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);
                bullet.transform.position = firePosition.transform.position;
            }
           //GameObject obj = Instantiate(bulletPre) as GameObject;
           // obj.transform.position = firePosition.transform.position;
        }

#if UNITY_EDITOR ||UNITY_STANDALONE
        if(Input.GetButtonDown("Fire1"))
        {
           Fire();
        }
#endif
    }

    void Fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            //비활성화 된 총알을 하나 가져온다
            GameObject bullet = bulletObjectPool[0];
            bullet.SetActive(true);
            bulletObjectPool.Remove(bullet);
            bullet.transform.position = firePosition.transform.position;
        }
    }

}
