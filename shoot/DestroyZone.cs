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
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false); // 파괴를 비활성화 하고 이 문구를 넣었더니 총알이 계속 나온다.enemy.cs에서도 동일하게 해 줌275 적은 아직 안 나옴하이어아키에서 적은 비활성화회색이다.-스폰 만들기 전
            if (other.gameObject.name.Contains("Bullet"))
            {               
                                                                 
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); //PlayerFire 클래스 얻어오기
                player.bulletObjectPool.Add(other.gameObject); //
                
            }
            else if (other.gameObject.name.Contains("Enemy"))  // 290에서 추가 // else 를 33 동영상에서 삭제함 8:23
            {
                GameObject emObject = GameObject.Find("EnemyManager"); // 290에서 추가
                EnemyManager manager = emObject.GetComponent<EnemyManager>(); //290추가
                manager.enemyObjectPool.Add(other.gameObject); //
            }
        }       
    }
}
