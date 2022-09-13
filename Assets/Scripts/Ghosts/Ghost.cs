using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public GameObject player;

    private Vector3 startToEnd;
    private Vector3 endToStart;
    private Vector3 movement;
    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (startPosition.magnitude == 0)
        {
            startPosition = transform.position;
        }

        if (endPosition.magnitude == 0)
        {
            endPosition = transform.position;
        }

        transform.position = startPosition;
        startToEnd = endPosition - startPosition;
        endToStart = startPosition - endPosition;
        movement = startToEnd;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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
        FacePlayer();
    }

    void FacePlayer()
    {
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                mySpriteRenderer.flipX = false;
            } else
            {
                mySpriteRenderer.flipX = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && player.GetComponent<levelLighting>().levelNotCleared)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
