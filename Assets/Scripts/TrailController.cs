using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class TrailController : MonoBehaviour {
    
    [SerializeField] private LineRenderer renderer;
    [SerializeField] private int threshhold;
    [SerializeField] private int maximumPoints;

    private Vector3 lastPlacedPosition;
    private Vector3 lastPosition;

    private void Start() {
        lastPosition = transform.position;
        lastPlacedPosition = lastPosition;
    }

    // Update is called once per frame
    private void Update() {

        Vector3 currentPosition = transform.position;
        if (Vector3.Distance(currentPosition, lastPosition) > threshhold) {
            Vector3[] data = new Vector3[renderer.positionCount];
            renderer.GetPositions(data);
            List<Vector3> dataList = data.ToList();
        }
        
    }
}
