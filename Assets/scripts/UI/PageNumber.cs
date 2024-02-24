using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageNumber : MonoBehaviour
{

    public Text pagenum;
    public int page;
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    void Update(){
        page = uiManager.currentDisplay;
        pagenum.text = "Page " + page.ToString();
    
    }
}
