using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Schiedsrichter : MonoBehaviour
{
    [SerializeField] private float zeitZumNeustart;
    [SerializeField] private int punkteZumSieg = 5;

    public event Action<PaddelBewegung, int> OnScoreUpdate;
    
    private Dictionary<PaddelBewegung, int> playerScores;

    private BallBewegung ball;

    private void Start()
    {
        playerScores = new Dictionary<PaddelBewegung, int>();
        FindObjectsOfType<PaddelBewegung>().ToList().ForEach(paddle => playerScores[paddle] = 0);

        ball = FindObjectOfType<BallBewegung>();
    }

    public void AddScore(PaddelBewegung player)
    {
        int newScore = ++playerScores[player];
        OnScoreUpdate?.Invoke(player, newScore);

        if (newScore >= punkteZumSieg)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        
        StartCoroutine(ball.Reset(zeitZumNeustart));
    }
}