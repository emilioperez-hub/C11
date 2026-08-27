using UnityEngine;

public class knifeScript : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<playerHealth>().TakeDamage(5);
        }
    }
}
