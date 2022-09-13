using System;
using UnityEngine;

namespace Ghosts
{
    public class NewGhost: MonoBehaviour
    {

        private bool flipped = false;
        public Vector3 finalPos;
        private Vector3 _startPos;
        private Vector3 direction;
        public float speed;
        private Rigidbody2D _rb2d;
        private void Start()
        {
            _startPos = transform.position;
            _rb2d = GetComponent<Rigidbody2D>();
            direction = (finalPos - _startPos).normalized;
        }

        private void Update()
        {
            if (transform.position.x > finalPos.x)
            {
                flipped = false;
            }

            if (transform.position.x < _startPos.x)
            {
                flipped = true;
            }

            if (!flipped)
            {
                transform.position -= direction * speed * Time.deltaTime;
            }
            else
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            
        }
    }
}