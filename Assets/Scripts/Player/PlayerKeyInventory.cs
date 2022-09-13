using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInventory : MonoBehaviour
{
    private bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("KeyObstacle"))
        {
            if (hasKey)
            {
                Destroy(col.gameObject);
                hasKey = false;
            }
        }
    }

}
