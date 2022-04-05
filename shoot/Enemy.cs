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
                dir = target.transform.position - transform.position; // �ڲ� �����ִٰ� ���.
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
        gameObject.SetActive(false); // ���� �ı��� ��Ȱ��ȭ �ϰ� �� ������ �־����� �Ѿ��� ��� ���´�.  destroy.cs������ �����ϰ� �� ��275 ���� ���� �� ����/���̾��Ű���� ���� ��Ȱ��ȭȸ���̴�.-���� ����� ��
        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>(); 
        manager.enemyObjectPool.Add(gameObject);
        
    }
}
