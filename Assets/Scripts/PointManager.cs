using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    [SerializeField] private float timeToReset;
    [SerializeField] private int scoreToWin = 5;

    public event Action<PaddleMovement, int> OnScoreUpdate;
    
    private Dictionary<PaddleMovement, int> playerScores;

    private BallMovement ball;

    private void Start()
    {
        playerScores = new Dictionary<PaddleMovement, int>();
        FindObjectsOfType<PaddleMovement>().ToList().ForEach(paddle => playerScores[paddle] = 0);

        ball = FindObjectOfType<BallMovement>();
    }

    public void AddScore(PaddleMovement player)
    {
        int newScore = ++playerScores[player];
        OnScoreUpdate?.Invoke(player, newScore);

        if (newScore >= scoreToWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        
        StartCoroutine(ball.Reset(timeToReset));
    }
}