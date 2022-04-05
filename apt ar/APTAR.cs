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

        //info_status.text= "버튼을 눌러주세요";
    }

    public void aniplay()
    {
        anim.SetBool("New Bool", true);

        //info_status.text = "리모델링 완료 모델입니다";
    }

    public void anibackplay()
    {
        anim.SetBool("New Bool", false);

        //info_status.text = "리모델링 이전 모델입니다.";
    }


    void Update()
    {


    }
}
