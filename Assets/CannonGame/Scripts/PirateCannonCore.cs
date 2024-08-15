using System;
using UnityEngine;

namespace CannonGame.Scripts
{
    public class PirateCannonCore : MonoBehaviour
    {
        [SerializeField] private float _speed = 50f;
        [SerializeField] private int _damage = 100;
        private Rigidbody2D _rigidbody;

        private void Awake()
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
    }
}
