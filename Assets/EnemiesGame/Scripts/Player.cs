using UnityEngine;

namespace EnemiesGame
{
    public enum WeaponType
    {
        CombatRifle = 1,
        Bazooka = 2,
        FlameThrower = 3,
        LaserGun = 4
    }
    
    public class Player : MonoBehaviour // Класс, представляющий игрока
    {
        [SerializeField] private int _damage; // Урон, наносимый игроком
        [SerializeField] private float _shootInterval;
        [SerializeField] private float _enemyDetectionRadius = 20f;
        [SerializeField] private int _damageBazooka; // Урон, наносимый игроком
        [SerializeField] private float _shootIntervalBazooka;
        
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

        private WeaponType _currentWeapon = WeaponType.CombatRifle;
        private Enemy _enemy;
        private float _time = 0;

        public void Update()
        {
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
                
                _time += Time.deltaTime;
            }
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
                        return enemy;
                    }  
                }
            }

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
        }

        public void ChangeWeapon(int weaponId)
        {
            _currentWeapon = (WeaponType)weaponId;
        }
    }
}
