using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ate : MonoBehaviour
{  // ontriggerEnter을 써야한다. OnCollisionEnter은 잘 안 쓴다.
    
    public Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    private void OnTriggerEnter(Collider other) // istrigger가 체크되어 야 함수호출한다. 한다. 이벤트만호출한다. 물리작용없다.
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("test");
            player.eat();
            Destroy(gameObject); // 플레이어가 계속 생성되지 않도록 한다.
        }
        }
    }

