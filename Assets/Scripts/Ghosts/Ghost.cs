using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector3 startPosition;
    public Vector3 endPosition;

    private Vector3 startToEnd;
    private Vector3 endToStart;
    private Vector3 movement;
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        startToEnd = endPosition - startPosition;
        endToStart = startPosition - endPosition;
        movement = startToEnd;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (movement.Equals(startToEnd) &&
            (endPosition - position).normalized != startToEnd.normalized)
        {
            movement = endToStart;
        } else if (movement.Equals(endToStart) &&
            (startPosition - position).normalized != endToStart.normalized)
        {
            movement = startToEnd;
        }

        myRigidbody2D.velocity = movement.normalized * speed;
    }
}
