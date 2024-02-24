using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    private Collider2D collider;
    private UIManager uiManager;
    //[SerializeField] private GameObject player;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        uiManager = FindObjectOfType<UIManager>();
    
    }


    void OnTriggerEnter2D(Collider2D thing)
    {

        if (thing.gameObject.CompareTag("Player"))
        {
            uiManager.GameOver();
        }

    }
}
