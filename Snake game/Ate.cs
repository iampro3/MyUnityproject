using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ate : MonoBehaviour
{  // ontriggerEnter�� ����Ѵ�. OnCollisionEnter�� �� �� ����.
    
    public Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    private void OnTriggerEnter(Collider other) // istrigger�� üũ�Ǿ� �� �Լ�ȣ���Ѵ�. �Ѵ�. �̺�Ʈ��ȣ���Ѵ�. �����ۿ����.
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("test");
            player.eat();
            Destroy(gameObject); // �÷��̾ ��� �������� �ʵ��� �Ѵ�.
        }
        }
    }

