using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARController2 : MonoBehaviour
{
    public GameObject[] bodyObjects;
    public Color32[] colors;
    public float rotSpeed = 0.1f;

    Material[] carMats;

    void Start()
    {
        // carMats �迭�� �ʱ�ȭ�Ѵ�.
        carMats = new Material[bodyObjects.Length];

        // ���� ��� ������Ʈ���� ���͸����� carMats �迭�� ����Ѵ�.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i] = bodyObjects[i].GetComponent<MeshRenderer>().material;
        }

        // ���� �迭 0���� �ڵ����� �⺻ ������ �����Ѵ�.
        colors[0] = carMats[0].color;
    }

    public void ChangeColor(int num)
    {
        // ��ư�� �Ҵ�� �Ű�����(num)�� ���ڿ� �ش��ϴ� �÷��� �ڵ����� �������� �ٲ۴�.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i].color = colors[num];
        }
    }

    void Update()
    {
        // ����, ȭ���� ��ġ�ϰ� �ִٸ�...
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ����, ��ġ ���°� �����̴� ���¶��...
            if (touch.phase == TouchPhase.Moved)
            {
                // ����, �ڵ����� ��ġ�ϰ� �ִ� ���¶��...
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 8))
                {
                    // �ڵ����� �հ����� �¿� �����ӿ� ���缭 ȸ����Ų��.
                    Vector2 deltaPos = touch.deltaPosition;

                    transform.Rotate(transform.up, deltaPos.x * -1.0f * rotSpeed);
                }
            }
        }
    }
}