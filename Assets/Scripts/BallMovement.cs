﻿using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxStartVelocity = 5f;

    private Vector2 velocity;
    
    private void Start()
    {
        float initialVelocityX = Random.Range(0, 2) == 0 ? -1f : 1f;
        velocity = new Vector2(initialVelocityX, GetRandomYVelocity()).normalized;
    }

    private void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<PaddleMovement>() != null) velocity = new Vector2(-velocity.x, GetRandomYVelocity()).normalized;
        if (col.collider.GetComponent<Wall>() != null) velocity = new Vector2(velocity.x, GetRandomYVelocity()).normalized;
    }

    private float GetRandomYVelocity() => Random.Range(-maxStartVelocity, maxStartVelocity);
}