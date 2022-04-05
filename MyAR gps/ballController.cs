using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour
{
    public float resetTime = 3.0f;
    public Text result;
    public float captureRate = 0.5f;
    public GameObject effect;

    Rigidbody rb;
    bool isReady = true;
    Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        // UI �ؽ�Ʈ�� �������� �ʱ�ȭ�Ѵ�.
        result.text = "";
    }

    void Update()
    {
        // ���� ���ư��� �ִ� �߿��� ������Ʈ�� �����Ѵ�.
        if (!isReady)
        {
            return;
        }

        SetBallPosition(Camera.main.transform);

        // ����, ����ڰ� ȭ���� ��ġ�ϰ� �ִٸ�...
        if (Input.touchCount > 0 && isReady)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // ��ġ ���� ��ġ�� �����Ѵ�.
                startPos = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                // ��ġ�� ���۵� �������� ������ ���������� �Ÿ��� ���Ѵ�.
                float dragDistance = touch.position.y - startPos.y;

                // ���� ���ư� ������ ���Ѵ�.
                Vector3 throwAngle = (Camera.main.transform.forward + Camera.main.transform.up).normalized;

                // ���� �ɷ��� Ȱ��ȭ�ϰ� �غ� ���¸� false�� �����Ѵ�.
                rb.isKinematic = false;
                isReady = false;

                // ���� ���ư� ����� ���� �̿��Ͽ� ���������� �߻��Ѵ�.
                rb.AddForce(throwAngle * dragDistance * 0.005f, ForceMode.VelocityChange);

                // ������ �ð� �ڿ� ResetBall() �Լ��� ����ǵ��� ������ �Ѵ�.
                Invoke("ResetBall", resetTime);
            }
        }

    }

    void SetBallPosition(Transform anchor)
    {
        // ī�޶�κ��� �������� 0.5����, �Ʒ������� 0.2���� ��ġ�� ��´�.
        Vector3 offset = anchor.forward * 0.5f + anchor.up * -0.2f;

        // ���� ��ġ�� ī�޶�κ��� Ư�� ��ġ�� ���´�(��ġ ����).
        transform.position = anchor.position + offset;
    }

    void ResetBall()
    {
        // ���� �ɷ��� ��Ȱ��ȭ�ϰ� �ӵ��� �ʱ�ȭ�Ѵ�.
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;

        // �غ� ���·� �������´�.
        isReady = true;

        // ���� Ȱ��ȭ�Ѵ�.
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �غ� ���¶�� �浹 ó�� �̺�Ʈ �Լ��� �׳� �����Ų��.
        if (isReady)
        {
            return;
        }

        // ��ȹ Ȯ���� ��÷�Ѵ�.
        float draw = Random.Range(0, 1);

        if (draw <= captureRate)
        {
            result.text = "��ȹ ����!";

            // DB �������� ��ȹ ���θ� �����Ѵ�.
            DBmanager.instance.UpdateCaptured();
        }
        else
        {
            result.text = "��ȹ�� �����Ͽ� �����ƽ��ϴ�...";
        }

        // ����� ĳ���͸� �����Ѵ�.
        Destroy(collision.gameObject);

        // ����Ʈ�� �����Ѵ�.
        Instantiate(effect, collision.transform.position, Camera.main.transform.rotation);

        // ���� ��Ȱ��ȭ�Ѵ�.
        gameObject.SetActive(false);
    }
}