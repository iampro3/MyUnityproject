using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ItemCount : MonoBehaviour
{
    public int TotalItemCount;
    public Text stageCountText;
    public Text playerCountText;
    //public GameObject gamestartText;
    public int Stage;
    bool isGameover;
    //bool isGamestart;
    public Text timeText;
    float surviveTime;
    // Start is called before the first frame update
    void Awake()
    {
        stageCountText.text = "/ " + TotalItemCount;
        //isGamestart = true;
        surviveTime = 0;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
            // isGamestart = false;
            // gamestartText.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    // Update is called once per frame
    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Stage" + Stage.ToString());

        }
    }
    //public void StartGame()
   // {
               
      //  isGamestart = false;
      //  gamestartText.SetActive(false);
   // }


}

