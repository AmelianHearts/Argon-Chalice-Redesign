using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{

    public bool isLocked;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            collider.enabled = false;
        }
    }
}
