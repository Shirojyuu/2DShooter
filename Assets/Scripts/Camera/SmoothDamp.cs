using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour {

    public Transform target;
    public float smoothTime;

    private Vector3 targetPos, offset, velocity;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate () {
        targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
	}
}
