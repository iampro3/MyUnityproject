using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Player set_isplaying;
    //public UIManager uimag;


    // Start is called before the first frame update
    void Start()
    {
        //set_isplaying = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //Debug.Log(set_isplaying.isplaying);
        //uimag = GameObject.FindGameObjectWithTag("uimag").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 50)
        {
            Debug.Log(transform.position.x);

            transform.position = new Vector3(-50, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < -50)
        {
            Debug.Log(transform.position.x);

            transform.position = new Vector3(49, transform.position.y, transform.position.z);
        }

        if (transform.position.z >= 49)
        {
            Debug.Log(transform.position.z);

            transform.position = new Vector3(transform.position.x, transform.position.y, -49);
        }

        else if (transform.position.z < -49)
        {
            Debug.Log(transform.position.z);

            transform.position = new Vector3(transform.position.x, transform.position.y, 49);
        }
    }

    private void OnTriggerEnter(Collider other) // istrigger가 체크되어 야 함수호출한다. 한다. 이벤트만호출한다. 물리작용없다.
    {
        if (other.gameObject.tag == "Player")
        {
            
            set_isplaying.SET_isplaying(false);
            Debug.Log("test" + set_isplaying);
        }
    }
    
}
