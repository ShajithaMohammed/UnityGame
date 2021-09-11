using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   [SerializeField]GameController gameController;
    [SerializeField]  List<Transform> patrolPoints;
    [SerializeField] private float changeDelay = 5;
    private float timer;
    private NavMeshAgent agent;
    public AudioSource sound;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDelay)
        {
            timer = 0;
            int index = Random.Range(0, patrolPoints.Count);
            agent.SetDestination(patrolPoints[index].position);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Play();
            gameController.EndGame();
        }
    }
}
