using System;
using UnityEngine;

public class gameEvents : MonoBehaviour
{
    public static gameEvents instance;

    public event Action onDoorTriggerEnter;

    public event Action onDoorTriggerExit;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void OpenTriggerDoor()
    {
        onDoorTriggerEnter();
    }
    public void CloseTriggerDoor()
    {
        onDoorTriggerExit();
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
