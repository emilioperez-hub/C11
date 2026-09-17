using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameEvents.instance.onDoorTriggerEnter += OpenDoor;
        gameEvents.instance.onDoorTriggerExit += CloseDoor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OpenDoor(DoorController door)
    {
        if (door != this) return;
        //translate le suma a todas las coordenadas originales
        //transform.Translate(new Vector3(0f, 1.28f, 0f));
        transform.DOMoveX(7.06f, 2);
        transform.DOMoveY(0.12595f, 0);
    }
    void CloseDoor(DoorController door)
    {
        if (door != this) return;
        //transform.Translate(new Vector3(0f, -1.28f, 0f));
        transform.DOMoveX(3.53f, 2);
        transform.DOMoveY(0.12595f, 0);
    }
}
