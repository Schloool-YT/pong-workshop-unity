using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class TrailController : MonoBehaviour {
    
    [SerializeField] private LineRenderer renderer;
    [SerializeField] private float threshhold = 0.5f;
    
    private Vector3 lastPosition;

    private void Start() {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    private void Update() {

        Vector3 currentPosition = transform.position;
        renderer.SetPosition(renderer.positionCount - 1, currentPosition);
        
        if (Vector3.Distance(currentPosition, lastPosition) > threshhold) {
            Vector3[] data = new Vector3[renderer.positionCount];
            renderer.GetPositions(data);
            List<Vector3> dataList = data.ToList();
            
            // remove the last items until we have one free slot again
            while (dataList.Count >= renderer.positionCount) dataList.RemoveAt(0);

            // append the new position at the front
            dataList.Add(currentPosition);
            renderer.SetPositions(dataList.ToArray());
            lastPosition = currentPosition;
        }
    }
}
