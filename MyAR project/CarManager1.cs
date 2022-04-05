
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class CarManager1 : MonoBehaviour
{
    public GameObject indicator;
    ARRaycastManager arManager;

    public GameObject myCar;
    GameObject placeObject; // 생성된 스포츠카의 정보가 담겨져 있다.
    public float relocationDistance = 1.0f; // 인디케이터 오브젝트 위치가 50 cm 이상 떨어진 곳을 비춰야만 자동차의위치가 재배치 될 수  있게함
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        arManager = GetComponent<ARRaycastManager>();
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //인디케이터위치에 터치하면 자동차 생성하고
        DetectGround(); //

        if (EventSystem.current.currentSelectedGameObject)//
        {
            return;
        }

        //만일 인디케이터가 활성화중이면서 화면 터치가 있는 상태라면
        if (indicator.activeInHierarchy && Input.touchCount > 0)
        {
            //첫번째 터치상태를 가져온다.
            Touch touch = Input.GetTouch(0);

            //만일 터치가 시작된 상태라면 자동차를 인디케이터와 동일한 곳에 생성한다.
            if (touch.phase == TouchPhase.Began)
            {
                if (placeObject == null)
                {
                    placeObject = Instantiate(myCar, indicator.transform.position, indicator.transform.rotation);
                }
                //생성된 오브젝트가 있다면 그 오브젝트의 위치와 회전값을 변경한다.
                else
                {
                    // 만일 생성된 오브젝트와 인디케이터 사이의 거리가
                    //최소 이동범위 이상이라면
                    if (Vector3.Distance(placeObject.transform.position, indicator.transform.position) > relocationDistance)
                    {
                        //placeObject.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation); // 476p
                        placeObject.transform.position = indicator.transform.position; // git에 있는 코드로 변경함
                        placeObject.transform.rotation = indicator.transform.rotation;
                    }
                }

            }

        }

        void DetectGround() //
        {
            // 인디케이터 활성화시키는 코드
            //스크린의 중앙지점을 찾는다. 
            Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            //레이에 부딪힌 대상들의 정보를 저장할 리스트변수를 만든다.
            List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

            //만일 스크린 중앙지점에 레이를 발사해서 PLANE 타입추적대상이 있다면
            if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
            {
                //표식 오브젝트를 활성화한다
                indicator.SetActive(true);
                //표식오브젝트의 위치 및 회전값을 레이가 닿은 지점에 일치시킨다.
                indicator.transform.position = hitInfos[0].pose.position;
                indicator.transform.rotation = hitInfos[0].pose.rotation;                
                
                indicator.transform.position += indicator.transform.up * 0.01f; // 위치를 위쪽 방향으로 0.1m 올린다. 기울어진 평면이 있을 수 있다.
            }
            //그렇지 않으면 표식오브젝트를 비활성화한다
            else
            {
                indicator.SetActive(false);
            }
        }
    }
}
