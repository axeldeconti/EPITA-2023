using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D player1;
    public Rigidbody2D player2;

    public Transform player1Origin;
    public Transform player2Origin;

    public Rigidbody2D ball;

    public Transform ballPosForPlayer1;
    public Transform ballPosForPlayer2;

    public float timeBeforerStartGame = 3;

    public TextMeshProUGUI scoreText;

    public float delayBeforeTimeScales = 4f;
    public float timeScaleFactor = 0.1f;

    private int player1Score = 0;
    private int player2Score = 0;
    private float currentTime = -1;

    private void Start()
    {
        StartGame(Random.Range(0, 100) > 50);
    }

    private void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0)
            {
                Time.timeScale += timeScaleFactor;
                currentTime = delayBeforeTimeScales;
            }
        }
    }

    public void StartGame(bool startP1)
    {
        //Reset player positions
        player1.transform.position = player1Origin.position;
        player1.velocity = Vector2.zero;
        player2.transform.position = player2Origin.position;
        player2.velocity = Vector2.zero;

        //Set ball position
        ball.transform.position = startP1 ? ballPosForPlayer1.position : ballPosForPlayer2.position;
        ball.velocity = Vector2.zero;

        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        currentTime = -1;
        Time.timeScale = 1;
        ball.gravityScale = 0;
        yield return new WaitForSeconds(timeBeforerStartGame);
        ball.gravityScale = 1;
        currentTime = delayBeforeTimeScales;
    }

    public void Score(bool player1Scored)
    {
        if (player1Scored)
            player1Score++;
        else
            player2Score++;

        scoreText.text = $"{player1Score} - {player2Score}";
        
        StartGame(!player1Scored);
    }
}
