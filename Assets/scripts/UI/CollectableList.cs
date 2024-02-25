using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableList : MonoBehaviour
{
    public static CollectableList Instance;

    [SerializeField] public GameObject[] Collectables;
    [SerializeField] public GameObject[] CollectablesR;
    [SerializeField] public Sprite[] Amulet;
    [SerializeField] public bool[] Collected;
    [SerializeField] public GameObject naScreen;
    public PerspectiveSwitch player;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        player = FindObjectOfType<PerspectiveSwitch>();
    }

    public void DisplayItem(int index)
    {
        HideItem();

        if (index < 0 )
            index = 0;

        if (index >= Collectables.Length)
            index = Collectables.Length -1;

        if (Collected[index] && player.perspective == 1)
        {
            Collectables[index].gameObject.SetActive(true);
        }

        else if (Collected[index] && player.perspective == -1)
        {
            CollectablesR[index].gameObject.SetActive(true);
        }

        else 
        {
            naScreen.gameObject.SetActive(true);   
        }

    }
    public void HideItem()
    {
        for (int i = 0; i < Collectables.Length;  i++)
        {
            Collectables[i].gameObject.SetActive(false);
            CollectablesR[i].gameObject.SetActive(false);
        }
  
        naScreen.gameObject.SetActive(false);


    }
}