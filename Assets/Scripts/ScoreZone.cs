using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private PaddleMovement forPlayer;
    [SerializeField] private ParticleSystem scoreEffect;

    private PointManager pointManager;

    private void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<BallMovement>() == null) return;
        scoreEffect.transform.position = col.GetContact(0).point;
        scoreEffect.Play();
        
        pointManager.AddScore(forPlayer);
    }
}