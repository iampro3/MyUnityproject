using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // 자동차 색상변경 및 이동과 회전

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

            //만일 터치상태가 움직이고 있는 중이라면
            if (touch.phase == TouchPhase.Moved)
            {
                //만일 카메라 위치에서 정면방향으로 레이를 발사해 부딪힌 대상이
                //8번 레잉라면 터치이동량을구한다.
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 8))//
                {
                    Vector2 deltapos = touch.deltaPosition;//

                    //직전프레임에서 현재프레임까지의 x축 터치이동량에 비례해
                    //로컬 Y축 방향으로 회전시킨다.
                    transform.Rotate(transform.up, deltapos.x * -1.0f * rotSpeed);//회전값을 transform.up:로컬좌표/와 회전각도로 X좌표값을 전달한다.
                    //이동값을 음수가 좌측, 양수가 우측이지만 Y축회전방향을 음수가 우회전, 양수가 좌회전이라 터치이동방향과 차의 회전방향을 일치시키기위해 X값에 -1을 곱해 방향을 반대로 바꾼다.
                }
            }
        }
    }
}
