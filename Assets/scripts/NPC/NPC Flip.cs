using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFlip : MonoBehaviour
    
{
    public bool isFollowing;
    [SerializeField] private PerspectiveSwitch player;
    private SpriteRenderer sprite;
    [SerializeField] GameObject playerController;
    private Vector2 vel;
    public float smoothTime;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PerspectiveSwitch>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.perspective == -1)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }

        if (isFollowing)
        {
            Vector3 offset = new Vector3(0, 1, 0);
            transform.position = Vector2.SmoothDamp(transform.position, playerController.transform.position, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !isFollowing)
        {
            isFollowing = true;
        }
    }
}
