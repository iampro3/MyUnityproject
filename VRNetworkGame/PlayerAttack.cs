using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviourPun 
{
    public Animator anim;
    public float maxHP = 10;
    public float attackPower = 2;
    public Slider hpSlider;
    public BoxCollider weaponCol;

    float curHP = 0;
        
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        hpSlider.value = curHP / maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)) // OVr 사용할 때
        if(Input.GetMouseButtonDown(0))
        { 
            if(photonView.IsMine)
            {
                photonView.RPC("AttackAnimation", RpcTarget.AllBuffered);
                }
        }
    }

    [PunRPC]
    public void AttackAnimation()
    {
        
        anim.SetTrigger("Attack");
    }
    [PunRPC]
    public void Damaged(float pow)
    {
        curHP = Mathf.Max(0, curHP - pow);
        hpSlider.value = curHP / maxHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine && other.gameObject.name.Contains("Player"))
        {
            PhotonView pv = other.GetComponent<PhotonView>();
            pv.RPC("Damaged", RpcTarget.AllBuffered, attackPower);
            weaponCol.enabled = false;
        }
    }
}
