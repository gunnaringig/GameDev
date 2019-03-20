using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_score : MonoBehaviour
{
    private float timeLeft = 120;
    private int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Prototype_1");
        }
    }

    //End
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndGame")
        {
            CountScore();
        }

        if (trig.gameObject.name == "coin")
        {
            playerScore += 100;
            Destroy (trig.gameObject);

        }
    }

    private void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);

    }
}
