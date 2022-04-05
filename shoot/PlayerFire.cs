using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;//-   
    public int poolSize = 10; //- ���Ϲ̸Ŵ����� ����    
    public List<GameObject> bulletObjectPool; //-
    //public static List<GameObject> bulletObjectPool; enemy�� ������ �渴 �Ʒ� GameObject���� �Ʒ��Τ� 3�� ��Ȱ��ȭ �ϰ� �� �Ʒ� �� ���


    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new List<GameObject>(); //-284 ���� publis List�߰��ϸ鼭 ����
        for (int i = 0; i < poolSize; i++) //-
        {
            GameObject bullet = Instantiate(bulletFactory); //-
            //bulletObjectPool[i] = bullet; //-
            bulletObjectPool.Add(bullet); // 11�� List�� �����ϸ鼭 �Բ� ���� 284
            bullet.SetActive(false);//-
        }

            #if UNITY_ANDROID
                        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
            #elif UNITY_EDITOR || UNITY_STANDALONE
                        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
            #endif        
    }
        // Update is called once per frame
        void Update()
        {
 #if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
         //       if (bulletObjectPool.Count > 0)
         //       {
         //           GameObject bullet = bulletObjectPool[0];
         //           bullet.SetActive(true);
         //           bulletObjectPool.Remove(bullet);
         //           bullet.transform.position = transform.position;                
         //       }
             }
 #endif
        }

    public void Fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];
            bullet.SetActive(true);
            bulletObjectPool.Remove(bullet);
            bullet.transform.position = transform.position;
        }
    }   
}





