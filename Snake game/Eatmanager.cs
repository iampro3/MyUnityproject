using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatmanager : MonoBehaviour
{ // �������� ���̴�.

    public GameObject Eat;
    public Player is_playing;
    void Start()
    {
        is_playing = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Debug.Log(is_playing.isplaying);
        StartCoroutine(create());
        // ã�� �Լ� �ֱ�
    }
    
    
    
    void Update()
    {
        
    }    

    public IEnumerator create()
    {
        while (is_playing.isplaying)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject a = Instantiate(Eat); // inspector�� eat�� �ø��� instantiate�� ���̸� �÷��̾�� ���� �����Ѵ�.

            int x = Random.Range(-50,50); // int�� float�� �� �޴´�. �������� ��������ȭ�ؾ���.
            int z = Random.Range(-50,50); //
            a.transform.position = new Vector3(x,1,z);
        }
    }
}
