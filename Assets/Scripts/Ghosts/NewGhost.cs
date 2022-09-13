using System;
using UnityEngine;

namespace Ghosts
{
    public class NewGhost: MonoBehaviour
    {

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
            if (Vector3.Distance(transform.position, _startPos) > Vector3.Distance(finalPos, _startPos))
            {
                transform.position += direction * speed;
            }

            if (Vector3.Distance(transform.position, finalPos) > Vector3.Distance(finalPos, _startPos))
            {
                transform.position -= direction * speed;
            }
        }
    }
}