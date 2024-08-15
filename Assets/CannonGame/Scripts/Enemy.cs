using UnityEngine;

namespace CannonGame.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] protected float _moveSpeed;
        [SerializeField] private int _collisionDamageToCannon;
    
        private Transform _destinationPoint;
        private Rigidbody2D _rigidbody;
        private EnemyManager _manager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(Transform point, EnemyManager manager)
        {
            _destinationPoint = point;
            _manager = manager;
        }
    
        private void FixedUpdate()
        {
            if (_destinationPoint != null )
                MoveToDestructionPoint();
        }

        private void MoveToDestructionPoint()
        {
            CheckIfWeAtTheDestination();
            Vector2 direction = new Vector2(_destinationPoint.position.x - transform.position.x, 0).normalized;
            _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
        }

        private void CheckIfWeAtTheDestination()
        {
            if (transform.position.x <= _destinationPoint.position.x)
            {
                Debug.Log("Enemy reached destruction point");
                EventManager.TriggerEnemyReachedDestructionPoint(_collisionDamageToCannon);
                gameObject.SetActive(false);
                _manager.PutToObjectsPull(this);
            }
        }
    
        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("CannonCore"))
            {
                Debug.Log("Enemy hit by cannon core");
                EventManager.TriggerEnemyDestroyed(gameObject);
                Destroy(gameObject);
            }

            if (collision.CompareTag("DestructionPoint"))
            {
                Debug.Log("Enemy reached destruction point");
                EventManager.TriggerEnemyReachedDestructionPoint(_collisionDamageToCannon);
                Destroy(gameObject);
            }
        }
    }
}
