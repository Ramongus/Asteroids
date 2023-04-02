using System;
using MonoBehaviours.GameEntities;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float minRotationSpeed = 1f;
    [SerializeField] private float maxRotationSpeed = 5f;
    [SerializeField] private float points = 1f;
    
    private Vector3 _direction;
    private float _speed;
    private float _rotationSpeed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _direction = VectorUtilities.RandomDirection2D();
        _speed = Random.Range(minSpeed, maxSpeed);
        _rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = _direction * _speed;
        _rigidbody.angularVelocity = _rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Die();
        }
        if(col.TryGetComponent(out Bullet bullet))
        {
            Explode();
            bullet.Crash();
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
