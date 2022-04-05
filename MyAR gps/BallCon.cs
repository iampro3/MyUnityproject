using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallCon : MonoBehaviour
{
    Rigidbody rb;
    bool isReady = true;

    public float resetTime = 3.0f;
    public float captureRate = 0.3f;
    public Text result;    

    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        result.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            return;
        }

        SetBallPosition(Camera.main.transform);

        if (Input.touchCount > 0 && isReady)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                float dragDistance = touch.position.y - startPos.y;
                Vector3 throwAngle = (Camera.main.transform.forward +
                    Camera.main.transform.up).normalized;

                rb.isKinematic = false;
                isReady = false;
                rb.AddForce(throwAngle * dragDistance * 0.005f, 
                            ForceMode.VelocityChange);
                Invoke("ResetBall", resetTime);
            }
        }
    }

    void SetBallPosition(Transform anchor)
    {
        Vector3 offset = anchor.forward * 0.5f + anchor.up * -0.2f;
        transform.position = anchor.position + offset;
    }

    private void ResetBall()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        isReady = true;
        gameObject.SetActive(true);            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isReady)
        {
            return;
        }

        float draw = Random.Range(0, 1.0f);
        if (draw <= captureRate)
        {
            result.text = "포획성공";

        }
        else {
            result.text = "실패";
        }

        Destroy(collision.gameObject);
        gameObject.SetActive(false);

    }
}

