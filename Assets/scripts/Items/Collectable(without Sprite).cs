using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNoSprite : MonoBehaviour
{
    public bool inInventory { get; private set; }
    private Collider2D collider;
    [SerializeField] private int itemNumber;

    // Start is called before the first frame update
    void Start()
    {
        inInventory = false;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D thing)
    {

        if (thing.gameObject.CompareTag("Player"))
        {
            inInventory = true;
            //collider.enable = false;
            CollectableList.Instance.Collected[itemNumber] = true;
        }

    }
}