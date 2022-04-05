
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
    GameObject placeObject; // ������ ������ī�� ������ ����� �ִ�.
    public float relocationDistance = 1.0f; // �ε������� ������Ʈ ��ġ�� 50 cm �̻� ������ ���� ����߸� �ڵ�������ġ�� ���ġ �� ��  �ְ���
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        arManager = GetComponent<ARRaycastManager>();
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�ε���������ġ�� ��ġ�ϸ� �ڵ��� �����ϰ�
        DetectGround(); //

        if (EventSystem.current.currentSelectedGameObject)//
        {
            return;
        }

        //���� �ε������Ͱ� Ȱ��ȭ���̸鼭 ȭ�� ��ġ�� �ִ� ���¶��
        if (indicator.activeInHierarchy && Input.touchCount > 0)
        {
            //ù��° ��ġ���¸� �����´�.
            Touch touch = Input.GetTouch(0);

            //���� ��ġ�� ���۵� ���¶�� �ڵ����� �ε������Ϳ� ������ ���� �����Ѵ�.
            if (touch.phase == TouchPhase.Began)
            {
                if (placeObject == null)
                {
                    placeObject = Instantiate(myCar, indicator.transform.position, indicator.transform.rotation);
                }
                //������ ������Ʈ�� �ִٸ� �� ������Ʈ�� ��ġ�� ȸ������ �����Ѵ�.
                else
                {
                    // ���� ������ ������Ʈ�� �ε������� ������ �Ÿ���
                    //�ּ� �̵����� �̻��̶��
                    if (Vector3.Distance(placeObject.transform.position, indicator.transform.position) > relocationDistance)
                    {
                        //placeObject.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation); // 476p
                        placeObject.transform.position = indicator.transform.position; // git�� �ִ� �ڵ�� ������
                        placeObject.transform.rotation = indicator.transform.rotation;
                    }
                }

            }

        }

        void DetectGround() //
        {
            // �ε������� Ȱ��ȭ��Ű�� �ڵ�
            //��ũ���� �߾������� ã�´�. 
            Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            //���̿� �ε��� ������ ������ ������ ����Ʈ������ �����.
            List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

            //���� ��ũ�� �߾������� ���̸� �߻��ؼ� PLANE Ÿ����������� �ִٸ�
            if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
            {
                //ǥ�� ������Ʈ�� Ȱ��ȭ�Ѵ�
                indicator.SetActive(true);
                //ǥ�Ŀ�����Ʈ�� ��ġ �� ȸ������ ���̰� ���� ������ ��ġ��Ų��.
                indicator.transform.position = hitInfos[0].pose.position;
                indicator.transform.rotation = hitInfos[0].pose.rotation;                
                
                indicator.transform.position += indicator.transform.up * 0.01f; // ��ġ�� ���� �������� 0.1m �ø���. ������ ����� ���� �� �ִ�.
            }
            //�׷��� ������ ǥ�Ŀ�����Ʈ�� ��Ȱ��ȭ�Ѵ�
            else
            {
                indicator.SetActive(false);
            }
        }
    }
}
