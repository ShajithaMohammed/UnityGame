using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]private Text scoreDisplay;
    [SerializeField]private Text gameOverDisplay;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject particles;
    int score;
      
    public void AddScore(int points)
    {
        score += points;
        scoreDisplay.text = "Score : " + score;
    }

    public void EndGame() {
        Instantiate(particles , player.transform.position,Quaternion.identity);
        Destroy(player);
        StartCoroutine(Reset(3));
        scoreDisplay.gameObject.SetActive(false);
        gameOverDisplay.gameObject.SetActive(true);
    }

    private IEnumerator Reset(int delay)
    {
        float time = 0;
        while(time <= delay)
        {
            yield return null;
            time += Time.deltaTime;
        }
        SceneManager.LoadScene("Start");
    }
}
