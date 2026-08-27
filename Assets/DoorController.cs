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
    void OpenDoor()
    {
        //translate le suma a todas las coordenadas originales
        //transform.Translate(new Vector3(0f, 1.28f, 0f));
        transform.DOMoveX(7.06f, 2);
        transform.DOMoveY(4f, 2);
    }
    void CloseDoor()
    {
        //transform.Translate(new Vector3(0f, -1.28f, 0f));
        transform.DOMoveX(3.53f, 2);
        transform.DOMoveY(1.28f, 2);
    }
}
