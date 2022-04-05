using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }
    void Start()
    {
        this.generator = GameObject.Find("Generator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("point");
    }

    void Update()
    {

        this.time -= Time.deltaTime;
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<Generator>().SetParameter(10000.0f, 0, 0);
            
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<Generator>().SetParameter(0.9f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<Generator>().SetParameter(0.4f, -0.06f, 6);
        }
        else if (10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<Generator>().SetParameter(0.7f, -0.04f, 4);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<Generator>().SetParameter(1.0f, -0.03f, 2);
        }
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }
}

