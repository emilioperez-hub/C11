using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameEvents.instance.OpenTriggerDoor();
    }
    private void OnTriggerExit(Collider other)
    {
        
        gameEvents.instance.CloseTriggerDoor();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
