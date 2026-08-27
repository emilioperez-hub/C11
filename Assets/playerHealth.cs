using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    float health = 10;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameManager.instance.ReloadLevel();
        }
    }
}
