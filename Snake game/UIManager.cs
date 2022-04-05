using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startmenu;

    public GameObject ctrmenu;
    public GameObject restartmenu;

    // Start is called before the first frame update
    void Start()
    {
        if(startmenu.activeSelf)
        {
            ctrmenu.SetActive(!startmenu.activeSelf);
            restartmenu.SetActive(false);
        }
    }

    public void menu()
    {
        startmenu.SetActive(false);
        ctrmenu.SetActive(true);
        restartmenu.SetActive(false);        
    }
}
