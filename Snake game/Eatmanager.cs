using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatmanager : MonoBehaviour
{ // 관리자일 뿐이다.

    public GameObject Eat;
    public Player is_playing;
    void Start()
    {
        is_playing = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Debug.Log(is_playing.isplaying);
        StartCoroutine(create());
        // 찾는 함수 넣기
    }
    
    
    
    void Update()
    {
        
    }    

    public IEnumerator create()
    {
        while (is_playing.isplaying)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject a = Instantiate(Eat); // inspector에 eat를 올리는 instantiate다 먹이를 플레이어보다 먼저 생성한다.

            int x = Random.Range(-50,50); // int는 float을 못 받는다. 받으려면 강제형변화해야함.
            int z = Random.Range(-50,50); //
            a.transform.position = new Vector3(x,1,z);
        }
    }
}
