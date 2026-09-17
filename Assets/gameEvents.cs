using System;
using UnityEngine;

public class gameEvents : MonoBehaviour
{
    public static gameEvents instance;

    public event Action<DoorController> onDoorTriggerEnter;

   
    public event Action<DoorController> onDoorTriggerExit;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void OpenTriggerDoor(DoorController door)
    {
        if (onDoorTriggerExit != null)
            onDoorTriggerEnter(door);
    }
    public void CloseTriggerDoor(DoorController door)
    {
        if(onDoorTriggerExit != null)
           onDoorTriggerExit(door);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
