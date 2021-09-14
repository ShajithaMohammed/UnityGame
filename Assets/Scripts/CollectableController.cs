using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField]private int point = 10;
    public AudioSource sound;
    private Renderer _renderer;
    public void Start()
    {
        sound = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            _renderer.enabled = false;
            sound.Play();
            gameController.AddScore(point);
            Destroy(gameObject, sound.clip.length);
        }
    }
} 