using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    public Vector2 offset = Vector2.zero;
  
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(offset.x, offset.y, -10);
    }
}
