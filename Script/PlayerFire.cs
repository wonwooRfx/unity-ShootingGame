using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPre;
    public GameObject firePosition;

    public int poolSize = 10;
    //������ƮǮ �迭
    public List<GameObject> bulletObjectPool; //������ƮǮ �迭
    //GameObject[] bulletObjectPool;

    //�¾ �� ������ƮǮ�� �Ѿ��� �ϳ��� �����Ͽ� �ְ� �ʹ�
    // �¾ ��
    // Start is called before the first frame update
    void Start()
    {


        //źâ�� �Ѿ� ���� �� �ִ� ũ��� ����� �ش�
        // bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();
        //źâ�� ���� �Ѿ� ���� ��ŭ �ݺ��Ѵ�
        for (int i = 0; i< poolSize; i++)
        {
            //��Ȱ��ȭ �� �Ѿ���
            // ���� �Ѿ��� ��Ȱ��ȭ �Ǿ��ٸ�
            GameObject bullet = Instantiate(bulletPre) as GameObject;
            //�Ѿ��� ������ƮǮ�� �ְ�ʹ�
            bulletObjectPool.Add(bullet);
            //��Ȱ��ȭ��Ű��
            bullet.SetActive(false);
           
            
           /* if(obj.activeSelf == false)
            {
                //�Ѿ��� �߻��ϰ� �ʹ�(Ȱ��ȭ��Ų��)
                obj.SetActive(true);
                //�Ѿ��� ��ġ��Ű��
                obj.transform.position = transform.position;
                //�Ѿ� �߻� �Ͽ��� ������ ��Ȱ��ȭ �Ѿ� �˻� �ߴ�
                break;
            }*/
             
        }
        // ����Ǵ� �÷����� �ȵ���̵��� ��� ����
#if UNITY_ANDROID
       GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif


    }

    // Update is called once per frame
    void Update()
    {
        // ��ǥ: �߻��ư�� ������ źâ�� �ִ� �Ѿ� �� ��Ȱ��ȭ�� �༮�� �߻� �ϰ� �ʹ�.
        if(Input.GetButtonDown("Fire1"))
        {
            //źâ�ȿ� �Ѿ��� �ִٸ�
            if(bulletObjectPool.Count>0)
            {
                //��Ȱ��ȭ �� �Ѿ��� �ϳ� �����´�
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
            //��Ȱ��ȭ �� �Ѿ��� �ϳ� �����´�
            GameObject bullet = bulletObjectPool[0];
            bullet.SetActive(true);
            bulletObjectPool.Remove(bullet);
            bullet.transform.position = firePosition.transform.position;
        }
    }

}
