using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class ObstacleStopper : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) // Ev veya engel tag�
        {
            Debug.Log("Engel bulundu, dur!");
            agent.isStopped = true; // NavMeshAgent'� durdur
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Engelden ��kt�n, devam et!");
            agent.isStopped = false; // NavMeshAgent'� tekrar ba�lat
        }
    }
}
