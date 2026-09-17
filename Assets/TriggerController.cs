using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField]
    private DoorController door;
    private void OnTriggerEnter(Collider other)
    {
        gameEvents.instance.OpenTriggerDoor(door);
    }
    private void OnTriggerExit(Collider other)
    {
        
        gameEvents.instance.CloseTriggerDoor(door);
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
