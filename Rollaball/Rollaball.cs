using UnityEngine;
using UnityEngine.SceneManagement;

public class Rollaball : MonoBehaviour
{

    public ItemCount manager;
    public float JumpPower;
    public int ItemCount;

    AudioSource Myaud;
    bool isJump;


    Rigidbody rb;
    MeshRenderer mesh;
    Material mat;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }
    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody>();
        Myaud = GetComponent<AudioSource>();
        isJump = false;



    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

        }
    }
    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal")*0.5f;
        float v = Input.GetAxisRaw("Vertical") * 0.5f;

        rb.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

        //if (Input.GetButtonDown("Jump") && !isJump)

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
        //GetComponent<ParticleSystem>().Play();


    }


        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Item")
            {
                ItemCount++;
                Myaud.Play();
                other.gameObject.SetActive(false);
                manager.GetItem(ItemCount);


            }


        if (other.tag == "Item")
        {
            mat.color = new Color(0, 1, 1);
        }


        else if (other.tag == "FinishPoint")
            {
                if (ItemCount == manager.TotalItemCount)
                {
                    SceneManager.LoadScene("Stage" + (manager.Stage + 1).ToString());
                }
                else
                {
                    SceneManager.LoadScene("Stage" + manager.Stage.ToString());
                }
            }
        }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube")
        {
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }

}




