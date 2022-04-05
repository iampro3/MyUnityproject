using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    GameObject player;

    public GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {        
    }
    void OnEnable()
    {
        int randValue = UnityEngine.Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");

            if (target != null)
            {
                dir = target.transform.position - transform.position; // 자꾸 문제있다고 뜬다.
                dir.Normalize();
            }
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
        Scoremanager.Instance.Score++; //- 252-253p / 255
        GameObject explosion = Instantiate(explosionFactory);//-
        explosion.transform.position = transform.position; //-
        //GameObject smObject = GameObject.Find("Scoremanager"); //
        //Scoremanager sm = smObject.GetComponent<Scoremanager>(); //        

        if (other.gameObject.name.Contains("Bullet")) //-
        {
            other.gameObject.SetActive(false); //-
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();            
            player.bulletObjectPool.Add(other.gameObject); 
            
        }
        else
        {
            Destroy(other.gameObject); //-
        }
        gameObject.SetActive(false); // 위의 파괴를 비활성화 하고 이 문구를 넣었더니 총알이 계속 나온다.  destroy.cs에서도 동일하게 해 줌275 적은 아직 안 나옴/하이어아키에서 적은 비활성화회색이다.-스폰 만들기 전
        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>(); 
        manager.enemyObjectPool.Add(gameObject);
        
    }
}
