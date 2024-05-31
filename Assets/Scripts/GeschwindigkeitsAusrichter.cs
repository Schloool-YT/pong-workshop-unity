using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class GeschwindigkeitsAusrichter : MonoBehaviour {

    [SerializeField] private float reaktivitaet = 0.9f;
    [SerializeField] private Vector3 achse = new Vector3(0,0,1);
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
            Quaternion align = Quaternion.LookRotation(direction, achse) * Quaternion.Euler(orientation);
            transform.rotation = Quaternion.Lerp(align, transform.rotation, reaktivitaet);
        }
        lastPosition = currentPosition;
    }
}
