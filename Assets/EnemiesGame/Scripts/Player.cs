using System;
using System.Collections;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EnemiesGame
{
    public enum WeaponType
    {
        CombatRifle = 1,
        Bazooka = 2,
        // FlameThrower = 3,
        // LaserGun = 4
    }
    
    public class Player : MonoBehaviour // Класс, представляющий игрока
    {
        [SerializeField] private float _hp;
        [SerializeField] private int _damage; // Урон, наносимый игроком
        [SerializeField] private float _shootInterval;
        [SerializeField] private float _enemyDetectionRadius = 20f;
        [SerializeField] private int _damageBazooka; // Урон, наносимый игроком
        [SerializeField] private float _shootIntervalBazooka;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _timeLimit;
        [SerializeField] private float _gameTimeLimit = 60f;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private Vector3 _moveVector;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _speed;
        // [SerializeField] private Vector2 _direction;
        
        private float _collisionDamage = 1;
        private float _maxHp;
        private int _score;
        private float _currentTime;
        private bool _isGameOver;
        // private Vector3 playerPosition;
        // private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private Transform _transformBullet;
        // private Vector3 _target;
        private WeaponType _currentWeapon = WeaponType.CombatRifle;
        private Enemy _enemy;
        private float _time;
        private CharacterController _characterController;
        private Vector3 _flyDirection;
        
        // private Rigidbody2D _rigidbody;
        // private Vector2 _moveVelocity;

        private AudioSource _scoreAudioSource;
        
        public void Awake()
        {
            // _maxHp = _hp;
            // _healthSlider.maxValue = _maxHp;
            // _healthSlider.value = _hp;
        }

        public void Start()
        {
            // playerPosition = transform.position;
            // Debug.Log("Player position" + playerPosition);
            _score = 0;

            // _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogWarning("Animator component is missing on the Player object.");
            }

            _enemy = FindEnemy();

            _characterController = GetComponent<CharacterController>();
            
            // _rigidbody = GetComponent<Rigidbody2D>();
            
            // if (_enemy != null)
            // {
            //     _transformBullet = _enemy.transform;
            //     _target = _enemy.transform.position;   
            // }
        }

        private Enemy FindEnemy()
        {
            GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            if (enemyObject != null)
            {
                return enemyObject.GetComponent<Enemy>();
            }
            return null;
        }

        public bool CanShoot
        {
            get
            {
                bool canShoot = false;
                if (_currentWeapon == WeaponType.CombatRifle && _time > _shootInterval)
                {
                    canShoot = true;
                }
                else if (_currentWeapon == WeaponType.Bazooka && _time > _shootIntervalBazooka)
                {
                    canShoot = true;
                }
                return canShoot && _enemy != null;
            }
        }

        public void Update()
        {
            if (Time.timeScale == 0)
            {
                return;
            }
            
            if (_enemy == null)
            {
                _enemy = FindNewTargetByColliders();
            }
            else
            {
                var distance = Vector3.Distance(transform.position, _enemy.transform.position);
                if (distance > _enemyDetectionRadius)
                {
                    _enemy = null;
                    return;
                }

                //find the vector pointing from our position to the target
                var direction = (_enemy.transform.position - transform.position).normalized;
                //create the rotation we need to be in to look at the target
                var lookRotation = Quaternion.LookRotation(direction);
                //rotate us over time according to speed until we are in the required rotation
                var newRotation = Quaternion.Slerp(transform.rotation, lookRotation, 1);
                newRotation.x = 0;
                newRotation.y = 0;
                transform.rotation = newRotation;
                
                
                if (_gameTimeLimit > 0)
                {
                    _time += Time.deltaTime;
                    _gameTimeLimit -= Time.deltaTime;
                    _timeLimit.text = Mathf.Round(_gameTimeLimit).ToString();
                }
                
                else if (_gameTimeLimit <= 0)
                {
                    _gameTimeLimit = 0;
                    if(_score < 10)
                    {
                        _canvas.GetComponent<UIManager>().Restart();
                    }
                    else if(_score >= 10)
                    {
                        _canvas.GetComponent<UIManager>().Win();
                    }
                }

                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                _flyDirection = transform.right * x + transform.forward * y;
                
                // Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                // _moveVelocity = moveInput.normalized * _speed;
            }

            void FixedUpdate()
            {
                Flight(_flyDirection);
                
                // _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);

                // transform.Translate(_direction.normalized * _speed);

                // if (Input.GetAxis("Horizontal") < 0)
                // {
                //     _spriteRenderer.flipX = true;
                // }
                // else if (Input.GetAxis("Horizontal") > 0)
                // {
                //     _spriteRenderer.flipX = false;
                // }
                // }

                // private void OnCollisionEnter(Collision collision)
                // {
                //     Debug.Log("Collision:" + collision.gameObject.name);
                //
                //     if (collision.gameObject.CompareTag("Enemy") && _hp > 0)
                //     {
                //         _hp -= _collisionDamage;
                //         _healthSlider.value = _hp;
                //         
                //         
                //         if (_hp <= 0)
                //         {
                //             if (_score < 10 && _canvas != null)
                //             {
                //                 _canvas.GetComponent<UIManager>().Restart();
                //             }
                //             else if (_score >= 10 && _canvas != null)
                //             {
                //                 _canvas.GetComponent<UIManager>().Win();
                //             }
                //             GameOver();
                //         }
                //     }
                // }
            }

            // Flight();
            
            //_bullet.transform.position = Vector2.MoveTowards(transform.position, _target, _bulletSpeed * Time.deltaTime);
            // if (transform.position.x == _target.x && transform.position.y == _target.y)
            // {
            //     DestroyBullet();
            // }
        }
        
        private void Flight(Vector3 direction)
        {
            _characterController.Move(direction * _speed * Time.deltaTime);
            // float horizontalInput = Input.GetAxis("Horizontal");
            // float verticalInput = Input.GetAxis("Vertical");
            //
            // _moveVector.x = horizontalInput;
            // _moveVector.y = verticalInput;
            // //_rigidbody.velocity = new Vector3(_moveVector.x * _speed, _moveVector.y * _speed); // без физики движка
            // _rigidbody.AddForce(_moveVector * _speed); // для прыжков
            // Vector2 newPosition = _rigidbody.position + new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime;
            // _rigidbody.MovePosition(newPosition);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                DestroyBullet();
            }
        }
                
        void DestroyBullet()
        {
            Destroy(gameObject);
        }

            private Enemy FindNewTargetByColliders()
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, _enemyDetectionRadius);
                foreach (var hitCollider in hitColliders)
                {
                    var enemy = hitCollider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        var distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance <= _enemyDetectionRadius)
                        {
                            _animator.SetInteger("State", 1);
                            return enemy;
                        }  
                    }
                }
            
                _animator.SetInteger("State", 0);
                return null;
            }

            public void Shoot() // Метод, вызываемый при выстреле игрока (Player)
            {
                if (_enemy == null) 
                    return;

                switch (_currentWeapon)
                {
                    case WeaponType.CombatRifle:
                        _enemy.GetDamage(_damage);
                        _time = 0;
                        break;
                    case WeaponType.Bazooka:
                        _enemy.GetDamage(_damageBazooka);
                        _time = 0;
                        break;
                }

                // Instantiate(_bullet, _transformBullet.position, Quaternion.identity);
                // if (EventManager.instance != null)
                // {
                //     
                // }
            }

            public void ChangeWeapon(int weaponId)
            {
                _currentWeapon = (WeaponType)weaponId;
            }

            public void EnemyDestroy()
            {
                UpdateScoreUI();
            }

            private void UpdateScoreUI()
            {
                if (_scoreText != null)
                {
                    _score++;
                    
                    // _scoreAudioSource.Play();

                    _scoreText.text = $"Score: {_score}";
                }
                else
                {
                    Debug.LogError("LogError");
                }
            }
        
    }
}
