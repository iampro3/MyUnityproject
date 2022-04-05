using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;//-   
    public int poolSize = 10; //- 에니미매니저도 있음    
    public List<GameObject> bulletObjectPool; //-
    //public static List<GameObject> bulletObjectPool; enemy의 컨테인 뷸릿 아래 GameObject부터 아래로ㅓ 3줄 비활성화 하고 그 아래 줄 사용


    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new List<GameObject>(); //-284 위에 publis List추가하면서 변경
        for (int i = 0; i < poolSize; i++) //-
        {
            GameObject bullet = Instantiate(bulletFactory); //-
            //bulletObjectPool[i] = bullet; //-
            bulletObjectPool.Add(bullet); // 11에 List로 변경하면서 함께 변경 284
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





