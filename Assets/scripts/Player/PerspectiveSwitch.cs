using UnityEngine;

public class PerspectiveSwitch : MonoBehaviour
{
    public int perspective= 1;

    [SerializeField] private GameObject fantasy, reality = null;
    [SerializeField] private Cooldown cooldown;

    private SpriteRenderer sprite;
    public Sprite rS, fS;

    void Start()
    {
        //fantasy == GameObject.Find("Fantasy");
        //reality == GameObject.Find("Reality");

        //cooldown.cdTime = 3;

        sprite = GetComponent<SpriteRenderer>();
        fantasy.SetActive(true);
        reality.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (cooldown.cd) return;

        if (Input.GetKey(KeyCode.Q))
        {
            perspective *= -1;
            cooldown.StartCD();
            if (perspective == 1)
            {
                fantasy.SetActive(true);
                reality.SetActive(false);
                sprite.color = new Color(255, 255, 255, 255);
                sprite.sprite = fS;
            }
            else if (perspective == -1)
            {
                fantasy.SetActive(false);
                reality.SetActive(true);
                sprite.color = new Color(0,0,0,255);
                sprite.sprite = rS;
            }
        }
            

        

    }
}
