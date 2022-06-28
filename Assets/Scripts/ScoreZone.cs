using System;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private PaddleMovement forPlayer;
    
    private PointManager pointManager;

    private void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<BallMovement>() == null) return;
        
        pointManager.AddScore(forPlayer);
    }
}