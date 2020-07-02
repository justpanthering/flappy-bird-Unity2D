using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager instance { get; private set; }
    //public GameObject GameOverTextbox;
    public bool isGameOver;
    public int score;
    public float scrollHorizonatalSpeed = -3f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isGameOver = false;
        score = 0;
    }

    public void GameOver()
    {
        isGameOver = true;
        //GameOverTextbox.SetActive(true);
    }

    public void ScoreUpdate()
    {
        score++;
        FindObjectOfType<GameManager>().GetComponent<GameManager>().scoreUpdate();
    }
}
