using UnityEngine;

namespace EnemiesGame
{
    public class Player : MonoBehaviour // Класс, представляющий игрока
    {
        [SerializeField] private int _damage; // Урон, наносимый игроком
        [SerializeField] private float _shootInterval;
        [SerializeField] private float _enemyDetectionRadius = 20f;
        [SerializeField] private EnemiesManager _manager;

        private Enemy _enemy;
        private float _time = 0;

        public void Update()
        {
            if (_enemy == null)
            {
                _enemy = FindNewTargetByDistance();
            }
            else
            {
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

                if (_time > _shootInterval)
                {
                    Shoot(_enemy);
                    _time = 0;
                } 
            }
        }

        private Enemy FindNewTargetByDistance()
        {
            foreach (Enemy enemy in _manager._enemies)
            {
                var distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance <= _enemyDetectionRadius)
                {
                    return enemy;
                }
            }

            return null;
        }

        private Enemy FindNewTargetByColliders()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _enemyDetectionRadius);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Enemy>();
                var distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance <= _enemyDetectionRadius)
                {
                    return enemy;
                }
            }

            return null;
        }

        private void Shoot(Enemy enemy) // Метод, вызываемый при выстреле игрока (Player)
        {
            enemy.GetDamage(_damage); // Метод нанесения урона врагу (Enemy)
            if (enemy.IsDead)
            {
                _manager._enemies.Remove(enemy);
                Destroy(enemy.gameObject);
            }
        }
    }
}
