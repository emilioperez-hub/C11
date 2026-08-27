using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.MeshOperations;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    private float health = 10;
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField]
    GameObject knife;
    [SerializeField]
    private List<Transform> enemyPatrol = new List<Transform>();
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent.stoppingDistance = 2;

    }
    void Update()
    {
        agent.destination = player.position;

        if (Vector3.Distance(transform.position, player.position) <= 10)
        {
            agent.destination = player.position;
        }
        else
        {
            agent.destination = enemyPatrol[0].position;
        }
        
        if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }
    }

    public void TakeDamage(float value)
    {
        health -= value;
        if (health <= 0)
            Destroy(this.gameObject);
    }
}
