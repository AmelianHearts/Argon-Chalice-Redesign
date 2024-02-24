using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool inInventory { get; private set; }
    private Collider2D collider;
    private SpriteRenderer sprite;
    [SerializeField] private Sprite newSprite;
    [SerializeField] private int itemNumber;

    // Start is called before the first frame update
    void Start()
    {
        inInventory = false;
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
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
            sprite.sprite= newSprite;
            //collider.enable = false;
            CollectableList.Instance.Collected[itemNumber] = true;
        }

    }
}
