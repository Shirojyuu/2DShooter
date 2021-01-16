using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public Vector3 targetOffset;
    public bool facingLeft;

    private Vector3 originalPosition, offsetPosition, targetPosition;
    private Vector3 direction;
    private float currDist, prevDist;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
        offsetPosition = originalPosition + targetOffset;
        targetPosition = offsetPosition;
        direction = (targetPosition - transform.position).normalized;
        currDist = 99999.9f;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = facingLeft;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prevDist = currDist;
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
        currDist = Vector3.Distance(transform.position, targetPosition);

        //Passed our target
        if (currDist > prevDist)
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
            spriteRenderer.flipX = !spriteRenderer.flipX; // THIS FLIPS THE SPRITE
            currDist = 99999.9f;
        }
    }
}
