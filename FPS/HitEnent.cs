using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnent : MonoBehaviour
{
    public EnemyFSM efsm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void PlayerHit()
    {
        efsm.AttackAction();
    }

}
