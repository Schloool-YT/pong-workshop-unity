using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] private float timeToReset;

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
        playerScores[player]++;
        OnScoreUpdate?.Invoke(player, playerScores[player]);
        
        StartCoroutine(ball.Reset(timeToReset));
    }
}