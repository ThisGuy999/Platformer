using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public GameObject player;
    private int score = 0;
    private int highScore = 0;
    private float timer;
    private Text scoreString;
    private bool isPaused = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreString = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;
        if(timer >= .025f)
        {
            timer = 0f;
            score += 5;
            if(score > highScore)
            {
                highScore = score;
            }
            scoreString.text = "SCORE: " + score + "\n" + "HIGH SCORE: " + highScore
                + "\n" + "LIVES: " + player.GetComponent<Movement>().lives;
        }
        if(player.transform.position.x < .5f)
        {
            score = 0;
        }
    }
}
