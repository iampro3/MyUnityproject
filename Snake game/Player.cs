using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector3 move;
    public bool isplaying;
    public bool isbool;
    //public KeyCode key;
    public GameObject players;
    public GameObject playermove; 

    public List<GameObject> body_list;
    public UIManager uimag;
    // Start is called before the first frame update
    void Awake()
    {
        uimag = GameObject.FindGameObjectWithTag("uimag").GetComponent<UIManager>();

        playermove = Instantiate(players);
        isbool = true;
        isplaying = true;

        body_list.Add(playermove);
        StartCoroutine("movement"); // update에서 처리하면 무한루프로 비용이 많이든다.
    }

    public bool SET_isplaying(bool isp)
    {
        uimag.restartmenu.SetActive(!isp);
        isplaying = isp;
        return isp;
    }

    // Update is called once per frame
    void Update() // update에서 작업을 처리하면 무한루프로 비용이 많이든다. startcoroutine로 하는 것이 좋다.
    {
        movement2();

        if(Input.GetKey(KeyCode.Space))
        {
            move = Vector3.zero;                        
        }
    }

    IEnumerator movement()
    {
        while (isplaying)
        {
            yield return new WaitForSeconds(0.1f);
            if (isbool == true)
            {
                if (body_list.Count <= 1) // 1번만 실행된다.
                {
                    body_list[0].transform.position += move; // 꼬리가 하나 있을 때 실행
                }

                else 
                {
                    Debug.Log("Body 생성 else 구문" + isbool);

                    body_list[body_list.Count - 1].transform.position = body_list[0].transform.position + move;//꼬리가 두개이상일때 실행, +=에서 =을 삭제했더니 각각 생성이 되지 않고 두개까지만 된다.
                    
                                                                                         //=이면 계속생성 =을 빼면 두개까지만 생성된다.
                    body_list.Insert(0, body_list[body_list.Count - 1].gameObject);//마지막을 0번으로 해 주는 작업이다.

                    body_list.RemoveAt(body_list.Count - 1); // 마지막 배열을 삭제해줘야 한다. body_list.Count에서 Count가 list의 최종배열이다.

                    body_list[0].GetComponent<MeshRenderer>().material.color = new Color32(0, 200, 200, 255);
                        

                }
            }
            else
            {
                isbool = true;

                Debug.Log("Body 생성"+ isbool);
                playermove = Instantiate(players);
                body_list.Add(playermove);
                body_list[body_list.Count - 1].transform.position = body_list[0].transform.position + move;                
            }
            body_list[body_list.Count - 1].GetComponent<MeshRenderer>().material.color = new Color32(200, 0, 200, 255);
        }
    }

    public void btn_up()
    {

            move = Vector3.forward; // 1
        
    }

    public void btn_down()
    {

            move = Vector3.down; // 1
        
    }

    public void btn_left()
    {

            move = Vector3.left; // 1
        
    }

    public void btn_right()
    {

            move = Vector3.right; // 1
        
    }


    void movement2()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move = Vector3.back; // -1
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = Vector3.forward; // 1
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = Vector3.right; // 1
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = Vector3.left; // -1
        }
    }

    public void eat()
    {
        isbool = false;
        Debug.Log("Body 생성");
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
