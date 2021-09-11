using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField]private int point = 10;
    public AudioSource sound;
    public void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            sound.Play();
            gameController.AddScore(point);
            Destroy(gameObject);
        }
    }
} 