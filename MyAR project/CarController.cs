using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // �ڵ��� ���󺯰� �� �̵��� ȸ��

    public GameObject[] bodyObjects;
    public Color32[] colors;
    public float rotSpeed = 0.1f;

    Material[] carMats;


    // Start is called before the first frame update
    void Start()
    {
        carMats = new Material[bodyObjects.Length];
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i] = bodyObjects[i].GetComponent<MeshRenderer>().material;
        }
        colors[0] = carMats[0].color;
    }

    public void ChangeColor(int num)
    {
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i].color = colors[num];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //���� ��ġ���°� �����̰� �ִ� ���̶��
            if (touch.phase == TouchPhase.Moved)
            {
                //���� ī�޶� ��ġ���� ����������� ���̸� �߻��� �ε��� �����
                //8�� ���׶�� ��ġ�̵��������Ѵ�.
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 8))//
                {
                    Vector2 deltapos = touch.deltaPosition;//

                    //���������ӿ��� ���������ӱ����� x�� ��ġ�̵����� �����
                    //���� Y�� �������� ȸ����Ų��.
                    transform.Rotate(transform.up, deltapos.x * -1.0f * rotSpeed);//ȸ������ transform.up:������ǥ/�� ȸ�������� X��ǥ���� �����Ѵ�.
                    //�̵����� ������ ����, ����� ���������� Y��ȸ�������� ������ ��ȸ��, ����� ��ȸ���̶� ��ġ�̵������ ���� ȸ�������� ��ġ��Ű������ X���� -1�� ���� ������ �ݴ�� �ٲ۴�.
                }
            }
        }
    }
}
