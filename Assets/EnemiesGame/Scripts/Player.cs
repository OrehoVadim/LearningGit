using TMPro;
using UnityEngine;
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
        [SerializeField] private float _collisionDamage = 1;
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
        [SerializeField] private ParticleSystem _particleSystem;
        
        private float _maxHp;
        private int _score;
        private float _currentTime;
        private bool _isGameOver;
        private Animator _animator;
        private Transform _transformBullet;
        private WeaponType _currentWeapon = WeaponType.CombatRifle;
        private Enemy _enemy;
        private float _time;
        private CharacterController _characterController;

        private AudioSource _scoreAudioSource;
        
        public void Awake()
        {
            // _maxHp = _hp;
            // _healthSlider.maxValue = _maxHp;
            // _healthSlider.value = _hp;
        }

        public void Start()
        {
            _score = 0;
            _scoreAudioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogWarning("Animator component is missing on the Player object.");
            }

            _enemy = FindEnemy();
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

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 newPosition = transform.position + new Vector3(horizontalInput * _speed * Time.deltaTime,
                verticalInput * _speed * Time.deltaTime, 0);
            transform.position = newPosition;

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
                    if (_score < 10)
                    {
                        _canvas.GetComponent<UIManager>().Restart();
                    }
                    else if (_score >= 10)
                    {
                        _canvas.GetComponent<UIManager>().Win();
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && _hp > 0)
            {
                _hp -= _collisionDamage;
                _healthSlider.value = _hp;

                if (_hp <= 0)
                {
                    if (_score < 10 && _canvas != null)
                    {
                        _canvas.GetComponent<UIManager>().Restart();
                    }
                    else if (_score >= 10 && _canvas != null)
                    {
                        _canvas.GetComponent<UIManager>().Win();
                    }
                }
            }
            Debug.Log("Trigger:" + other.gameObject.name);
        }
        
        private void Flight(Vector3 direction)
        {
            _characterController.Move(direction * _speed * Time.deltaTime);
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
            _particleSystem.Play();
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
                _scoreAudioSource.Play();
                _scoreText.text = $"Score: {_score}";
            }
            else
            {
                Debug.LogError("LogError");
            }
        }
    }
}
