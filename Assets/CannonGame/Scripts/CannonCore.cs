using System;
using UnityEngine;

namespace CannonGame.Scripts
{
    public class CannonCore : MonoBehaviour
    {
        [SerializeField] private float _speed = 50f;
        [SerializeField] private int _damage = 10;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = transform.right * _speed;
        }

        public void SetInitialVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public float GetSpeed()
        {
            return _speed;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyController>()?.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}