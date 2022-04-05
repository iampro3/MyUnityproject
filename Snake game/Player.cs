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
        StartCoroutine("movement"); // update���� ó���ϸ� ���ѷ����� ����� ���̵��.
    }

    public bool SET_isplaying(bool isp)
    {
        uimag.restartmenu.SetActive(!isp);
        isplaying = isp;
        return isp;
    }

    // Update is called once per frame
    void Update() // update���� �۾��� ó���ϸ� ���ѷ����� ����� ���̵��. startcoroutine�� �ϴ� ���� ����.
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
                if (body_list.Count <= 1) // 1���� ����ȴ�.
                {
                    body_list[0].transform.position += move; // ������ �ϳ� ���� �� ����
                }

                else 
                {
                    Debug.Log("Body ���� else ����" + isbool);

                    body_list[body_list.Count - 1].transform.position = body_list[0].transform.position + move;//������ �ΰ��̻��϶� ����, +=���� =�� �����ߴ��� ���� ������ ���� �ʰ� �ΰ������� �ȴ�.
                    
                                                                                         //=�̸� ��ӻ��� =�� ���� �ΰ������� �����ȴ�.
                    body_list.Insert(0, body_list[body_list.Count - 1].gameObject);//�������� 0������ �� �ִ� �۾��̴�.

                    body_list.RemoveAt(body_list.Count - 1); // ������ �迭�� ��������� �Ѵ�. body_list.Count���� Count�� list�� �����迭�̴�.

                    body_list[0].GetComponent<MeshRenderer>().material.color = new Color32(0, 200, 200, 255);
                        

                }
            }
            else
            {
                isbool = true;

                Debug.Log("Body ����"+ isbool);
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
        Debug.Log("Body ����");
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
