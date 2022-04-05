using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{

    void Update()
    {

    }
    //public float gameRotationSpeed = 2f;
    public void OnClickEasy() {
        //StaticVariables.gameRotationSpeed = 0f;
        SceneManager.LoadScene("Stage1");
    }

    public void OnClickHard() {
        //StaticVariable.gameRotationSpeed = 10f;
        SceneManager.LoadScene("Stage2");
    }
  


    // Update is called once per frame

}
