using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator animator;
    private static readonly int Shake = Animator.StringToHash("Shake");

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        PointManager pointManager = FindObjectOfType<PointManager>();
        if (pointManager != null) pointManager.OnScoreUpdate += HandleScoreUpdate;
    }

    private void HandleScoreUpdate(PaddleMovement paddleMovement, int score)
    {
        animator.SetTrigger(Shake);
    }
}