using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BallBewegung : MonoBehaviour
{
    [SerializeField] private float geschwindigkeit = 5f;
    [SerializeField] private float hoechsteStartGeschwindigkeit = 5f;

    private TrailRenderer trailRenderer;
    private Vector2 startPoint;
    private Vector2 velocity;
    
    private void Start()
    {
        trailRenderer = transform.GetComponentInChildren<TrailRenderer>();
        startPoint = transform.position;
        SetInitialVelocity();
    }

    private void SetInitialVelocity()
    {
        float initialVelocityX = Random.Range(0, 2) == 0 ? -1f : 1f;
        velocity = new Vector2(initialVelocityX, GetRandomYVelocity()).normalized;
    }

    private void Update()
    {
        transform.Translate(velocity * geschwindigkeit * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<PaddelBewegung>() != null) velocity = new Vector2(-velocity.x, GetRandomYVelocity()).normalized;
        
        if (col.collider.GetComponent<Wand>() != null)
        {
            bool velocityWasPositive = velocity.y > 0f;
            float randomVelocity = GetRandomYVelocity();
            
            if (velocityWasPositive && randomVelocity > 0f || !velocityWasPositive && randomVelocity <= 0f) 
                randomVelocity *= -1f;
            
            velocity = new Vector2(velocity.x, randomVelocity).normalized;
        }
    }

    private float GetRandomYVelocity() => Random.Range(-hoechsteStartGeschwindigkeit, hoechsteStartGeschwindigkeit);

    public IEnumerator Reset(float timeToRestart)
    {
        transform.position = startPoint;
        trailRenderer.Clear();
        velocity = Vector2.zero;
        yield return new WaitForSeconds(timeToRestart);
        
        SetInitialVelocity();
    }
}