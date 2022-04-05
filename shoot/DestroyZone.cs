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
            other.gameObject.SetActive(false); // �ı��� ��Ȱ��ȭ �ϰ� �� ������ �־����� �Ѿ��� ��� ���´�.enemy.cs������ �����ϰ� �� ��275 ���� ���� �� �������̾��Ű���� ���� ��Ȱ��ȭȸ���̴�.-���� ����� ��
            if (other.gameObject.name.Contains("Bullet"))
            {               
                                                                 
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); //PlayerFire Ŭ���� ������
                player.bulletObjectPool.Add(other.gameObject); //
                
            }
            else if (other.gameObject.name.Contains("Enemy"))  // 290���� �߰� // else �� 33 �����󿡼� ������ 8:23
            {
                GameObject emObject = GameObject.Find("EnemyManager"); // 290���� �߰�
                EnemyManager manager = emObject.GetComponent<EnemyManager>(); //290�߰�
                manager.enemyObjectPool.Add(other.gameObject); //
            }
        }       
    }
}
