using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    float health = 5;

    [SerializeField]
    private Slider healthSlider;
    void Start()
    {
        healthSlider.value = health / 10;
    }
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health / 10;
        if(health <= 0)
        {
            gameManager.instance.ReloadLevel();
        }
    }
}
