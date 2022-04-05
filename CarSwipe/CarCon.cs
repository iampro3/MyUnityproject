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
        // 스와이프의 길이를 구한다, 
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 클릭한 좌표
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 마우스를 떼었을 때 좌표
            Vector2 endPos = Input.mousePosition;   //위치가 처음에서부터 변경되었을 것
            float swipeLength = endPos.x - this.startPos.x; // up시점과 down의 시점값을 뺀다.

            // 스와이프 길이를 처음 속도로 변경한다
            this.speed = swipeLength / 500.0f;
        }

        transform.Translate(this.speed, 0, 0);  // 이동
        this.speed *= 0.98f;                    // 감속
    }
}