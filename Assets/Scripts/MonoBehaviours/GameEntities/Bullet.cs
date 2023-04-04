using Interfaces;
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDamageableByBullet damageable))
            {
                damageable.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}