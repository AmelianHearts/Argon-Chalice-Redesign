using UnityEngine;
using UnityEngine.UI;

//taken from https://github.com/nickbota/Unity-Platformer-Episode-7/blob/main/2D%20Tutorial/Assets/Scripts/Health/Healthbar.cs
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}