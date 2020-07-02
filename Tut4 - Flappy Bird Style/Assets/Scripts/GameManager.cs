using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverTextbox;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //ScoreText = GameOverTextbox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && PersistentManager.instance.isGameOver == true)
        {
            restartGame();
        }
    }

    private void restartGame()
    {
        PersistentManager.instance.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void gameOver()
    {
        PersistentManager.instance.GameOver();
        GameOverTextbox.SetActive(true);
    }

    public void scoreUpdate()
    {
        Debug.Log(PersistentManager.instance.score.ToString());
        ScoreText.text = "Score: " + PersistentManager.instance.score.ToString();
    }
}
