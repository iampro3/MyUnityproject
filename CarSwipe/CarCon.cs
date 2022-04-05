using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCon : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;

    void Start()
    {

    }

    void Update()
    {
        // ���������� ���̸� ���Ѵ�, 
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺�� Ŭ���� ��ǥ
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ���콺�� ������ �� ��ǥ
            Vector2 endPos = Input.mousePosition;   //��ġ�� ó���������� ����Ǿ��� ��
            float swipeLength = endPos.x - this.startPos.x; // up������ down�� �������� ����.

            // �������� ���̸� ó�� �ӵ��� �����Ѵ�
            this.speed = swipeLength / 500.0f;
        }

        transform.Translate(this.speed, 0, 0);  // �̵�
        this.speed *= 0.98f;                    // ����
    }
}