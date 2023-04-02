using System;
using UnityEngine;

namespace MonoBehaviours.GameEntities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = transform.right * speed;
        }

        public void Crash()
        {
            Destroy(gameObject);
        }
    }
}