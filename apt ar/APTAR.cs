using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class APTAR : MonoBehaviour
{
    Animator anim;
    //public Text info_status;

    void Start()
    {
        anim = GetComponent<Animator>();

        //info_status.text= "��ư�� �����ּ���";
    }

    public void aniplay()
    {
        anim.SetBool("New Bool", true);

        //info_status.text = "���𵨸� �Ϸ� ���Դϴ�";
    }

    public void anibackplay()
    {
        anim.SetBool("New Bool", false);

        //info_status.text = "���𵨸� ���� ���Դϴ�.";
    }


    void Update()
    {


    }
}
