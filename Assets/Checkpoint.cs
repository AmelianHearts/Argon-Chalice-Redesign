using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D thing)
    {

        if (thing.gameObject.CompareTag("Player"))
        {

            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }

    }
}
