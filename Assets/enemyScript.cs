using DG.Tweening;
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
    private GameObject AmmoBox;
    [SerializeField]
    private List<Transform> enemyPatrol = new List<Transform>();

    int currentPoint = 0;
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

        if (Vector3.Distance(transform.position, player.position) <= 2)
        {
            agent.destination = player.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, enemyPatrol[currentPoint].position) >= 3)
            {
                agent.destination = enemyPatrol[currentPoint].position;
            }
            else
            {
                if (currentPoint < enemyPatrol.Count-1)
                {
                    currentPoint++;
                }
                else
                {
                    currentPoint = 0;
                }
            }
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
        GetComponent<MeshRenderer>().material.DOColor(Color.red, 1).From();
        GetComponent<MeshRenderer>().material.DOColor(Color.yellow, 1);
        if (health <= 0)
        {
            float drop = Random.Range(0, 10);
            {
            if(drop > 2)
            Instantiate(AmmoBox, transform.position, Quaternion.identity) ;
            }
            
            Destroy(this.gameObject);

        }
    }
}
