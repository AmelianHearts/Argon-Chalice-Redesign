using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    //private bool inInventory;
    private Collider2D collider;
    [SerializeField] private GameObject[] door;
    [SerializeField] private DoorLock[] theLock;
    //[SerializeField] private GameObject player;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        //inInventory = false;
    }

    
    void OnTriggerEnter2D( Collider2D thing)
    {

        if (thing.gameObject.CompareTag("Player"))
        {
            //inInventory = true;
            for(int i = 0; i < door.Length;  i++ )
            {
                door[i].transform.localScale = new Vector3(1, (float)11.52447, 1);
                theLock[i].isLocked = false;
            }
            
        }
        
    }

}
