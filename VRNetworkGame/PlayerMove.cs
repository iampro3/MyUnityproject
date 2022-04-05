using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    public float moveSpeed = 3.0f;
    public float rotSpeed = 200.0f;
    public GameObject cameraRig;
    public Transform myCharacter;
    public Animator anim;
    public Text nameText;

    Vector3 setPos;
    Quaternion setRot;
    float dir_Speed = 0;

    void Start()
    {
        // Start is called before the first frame update
        cameraRig.SetActive(photonView.IsMine);

        // nameText�� ����� �ڽ��� �̸��� ����Ѵ�.
        nameText.text = photonView.Owner.NickName;

        // �� ���� �� ĳ������ ��쿡�� �̸��� ������ ���������� �ϰ�,
        // ���� ĳ������ ��쿡�� �̸��� ������ ������� �Ѵ�.
        if (photonView.IsMine)
        {
            nameText.color = Color.green;
        }
        else
        {
            nameText.color = Color.red;
        }
    }

    void Update()
    {
        Move();
        Rotate();
    }

    // �̵� ���
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        // �� ���� �� ĳ������ ���...
        if (photonView.IsMine)
        {
            // �޼� �潺ƽ�� ���� ��ŭ ���� ���� �̿��ؼ� ĳ������ �̵� ������ �����Ѵ�.
            //Vector2 stickPos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LHand);
            Vector2 stickPos = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Vector3 dir = new Vector3(stickPos.x, 0, stickPos.y);
            dir.Normalize();

            // ī�޶��� ������ �������� �̵� ���� ������ ���� ������ �����Ѵ�.
            dir = cameraRig.transform.TransformDirection(dir);
            transform.position += dir * moveSpeed * Time.deltaTime;

            // ĳ������ ���� ������ �̵� ���⿡ �°� ȸ����Ų��.
            float magnitude = dir.magnitude;

            if (magnitude > 0)
            {
                myCharacter.rotation = Quaternion.LookRotation(dir);
            }

            // �ִϸ��̼� ���� Ʈ���� �̵� ������ ũ�⸦ �����Ѵ�.
            anim.SetFloat("Speed", magnitude);
        }
        // �ٸ� ����� ���� ���� ĳ������ ���(����ȭ)
        else
        {
            // �����κ��� �о�� ������ �̵� �Ǵ� ȸ���� �Ѵ�.
            transform.position = Vector3.Lerp(transform.position, setPos, Time.deltaTime * 20.0f);
            myCharacter.transform.rotation = Quaternion.Lerp(myCharacter.transform.rotation, setRot, Time.deltaTime * 20.0f);
            anim.SetFloat("Speed", dir_Speed);
        }
    }

    // ȸ�� ���
    void Rotate()
    {
        if (photonView.IsMine)
        {
            // ������ �潺ƽ�� ���� ���� ���Ѵ�.
            //float rotH = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
            float rotH = Input.GetAxis("Mouse X");

            // �¿� ��ƽ ���� ����ؼ� ī�޶� ȸ����Ų��.
            cameraRig.transform.eulerAngles += new Vector3(0, rotH, 0) * rotSpeed * Time.deltaTime;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // ����, ������ ������ �ϴ� ��Ȳ�̶��...
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(myCharacter.rotation);
            stream.SendNext(anim.GetFloat("Speed"));
        }
        // �׷��� �ʰ� ���� �����κ��� ������ �޴� ��Ȳ�̶��...
        else if (stream.IsReading)
        {
            setPos = (Vector3)stream.ReceiveNext();
            setRot = (Quaternion)stream.ReceiveNext();
            dir_Speed = (float)stream.ReceiveNext();
        }
    }
}
