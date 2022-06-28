using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrientAlongVelocity : MonoBehaviour {

    [SerializeField] private float lerpValue = 0.9f;
    [SerializeField] private Vector3 axis = new Vector3(0,0,1);
    [SerializeField] private Vector3 orientation = new Vector3(0,0,0);
    
    // the position we had last frame
    private Vector3 lastPosition;
    
    // the lowest value that will trigger alignment with our velocity
    private const float threshhold = 0.0001f;

    private void Start() {
        lastPosition = transform.position;
    }

    private void Update() {
        Vector3 currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, lastPosition);
        if (distance > threshhold) {
            Vector3 direction = currentPosition - lastPosition;
            Quaternion align = Quaternion.LookRotation(direction, axis) * Quaternion.Euler(orientation);
            transform.rotation = Quaternion.Lerp(align, transform.rotation, lerpValue);
        }
        lastPosition = currentPosition;
    }
}
