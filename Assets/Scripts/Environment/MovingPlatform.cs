using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public Vector3 targetOffset;

    private Vector3 originalPosition, offsetPosition, targetPosition;
    private Vector3 direction;
    private float currDist, prevDist;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        offsetPosition = originalPosition + targetOffset;
        targetPosition = offsetPosition;
        direction = (targetPosition - transform.position).normalized;
        currDist = 99999.9f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        prevDist = currDist;
        transform.parent.Translate(direction * moveSpeed * Time.fixedDeltaTime);
        currDist = Vector3.Distance(transform.position, targetPosition);

        //Passed our target
        if(currDist > prevDist)
        {
            transform.position = targetPosition;

            if (targetPosition == offsetPosition)
            {
                targetPosition = originalPosition;
            }

            else
            {
                targetPosition = offsetPosition;
            }

            direction = (targetPosition - transform.position).normalized;
            currDist = 99999.9f;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SetParent(transform.parent);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }
}
