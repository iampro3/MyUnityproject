using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public float throwPower = 15f;
    public GameObject bulletEffect;
    ParticleSystem ps;
    public int weaponPower = 5;
    Animator anim;
    bool ZoomMode = false;
    public Text wModeText;
    public GameObject[] eff_Flash;

    public GameObject weapon01;
    public GameObject weapon02;
    public GameObject crosshair01;
    public GameObject crosshair02;
    public GameObject weapon01_R;
    public GameObject weapon02_R;
    public GameObject crosshair02_Zoom;
    // Start is called before the first frame update
    enum WeaponMode  // 무기모드 변수를 전역변수로 만들었다.
    { 
        Normal,
            Sniper
    }
    WeaponMode wMode;


    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
        wMode = WeaponMode.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))  // 수류탄
        {
            switch (wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;
                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

                    break;

                case WeaponMode.Sniper:

                    if (!ZoomMode)
                    {
                        Camera.main.fieldOfView = 15f;
                        ZoomMode = true;
                        crosshair02_Zoom.SetActive(true);
                        crosshair02_Zoom.SetActive(false);
                    }
                    else
                    {
                        Camera.main.fieldOfView = 60f;
                        ZoomMode = false;
                        crosshair02_Zoom.SetActive(false);
                        crosshair02_Zoom.SetActive(true);

                    }

                    break;
            }
            
        }
        if (Input.GetMouseButtonDown(0)) // 총알
        {
            if (anim.GetFloat("Movemotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                }
            }
            StartCoroutine(ShootEffectOn(0.05f));
        }

        IEnumerator ShootEffectOn(float duration)
        {
            int num = Random.Range(0, eff_Flash.Length);
            eff_Flash[num].SetActive(true);
            yield return new WaitForSeconds(duration);
            eff_Flash[num].SetActive(false);                
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))// 키보드의 숫자 1번을 입력받으면 무기를 일반모드로
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "Normal Mode";
            weapon01.SetActive(true);
            weapon02.SetActive(false);
            crosshair01.SetActive(true);
            crosshair02.SetActive(false);
            weapon01_R.SetActive(true);
            weapon02_R.SetActive(false);
            crosshair02_Zoom.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))// 키보드의 숫자 2번을 입력받으면 무기를 스나이퍼로
        {
            wMode = WeaponMode.Sniper;
            wModeText.text = "Sniper Mode";
            weapon01.SetActive(false);
            weapon02.SetActive(true);
            crosshair01.SetActive(false);
            crosshair02.SetActive(true);
            weapon01_R.SetActive(false);
            weapon02_R.SetActive(true);
        }
    }
}

