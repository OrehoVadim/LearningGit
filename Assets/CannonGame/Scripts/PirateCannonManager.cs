// using CannonGame.Scripts;
// using UnityEngine;
//
// public class PirateCannonManager : MonoBehaviour
// {
//     public static bool IsPirateCannonActive { get; private set; } = false;
//     
//     [SerializeField] private float _moveSpeed;
//     [SerializeField] private float _fireInterval = 1f;
//     [SerializeField] private Transform _firePoint;
//     [SerializeField] private GameObject _pirateCannonCorePrefab;
//     [SerializeField] private Vector2 _shootingPosition = new Vector2(31f, -29.5f);
//     [SerializeField] private Vector2 _targetPosition = new Vector2(-82.7f, 4.5f); 
//     [SerializeField] private int _damage = 15;
//     private bool _hasReachedShootingPosition = false;
//     private float _fireTimer = 0f;
//
//     private void OnEnable()
//     {
//         IsPirateCannonActive = true;
//     }
//     
//     private void OnDisable()
//     {
//         IsPirateCannonActive = false;
//     }
//     
//     private void Update()
//     {
//         if (!_hasReachedShootingPosition)
//         {
//             MoveTowardsShootingPosition();
//         }
//         else
//         {
//             _fireTimer += Time.deltaTime;
//
//             if (_fireTimer >= _fireInterval)
//             {
//                 FirePirateCannon();
//                 _fireTimer = 0f;
//             }
//         }
//     }
//
//     private void MoveTowardsShootingPosition()
//     {
//         if (_firePoint == null)
//         {
//             Debug.LogError("FirePoint is not assigned.");
//             return;
//         }
//         
//         Vector2 target = new Vector2(_shootingPosition.x, transform.position.y);
//         float step = _moveSpeed * Time.deltaTime;
//         transform.position = Vector2.MoveTowards(transform.position, target, step);
//
//         if (Vector2.Distance(transform.position,target) < 0.1f)
//         {
//             _hasReachedShootingPosition = true;
//             transform.position = target;
//         }
//     }
//
//     private void FirePirateCannon()
//     {
//         if (_firePoint != null && _pirateCannonCorePrefab != null)
//         {
//             GameObject pirateCannonBall = Instantiate(_pirateCannonCorePrefab, _firePoint.position, Quaternion.identity);
//             CannonCore pirateCannonCore = pirateCannonBall.GetComponent<CannonCore>();
//             
//             if (pirateCannonCore != null)
//             {
//                 Vector2 direction = (_targetPosition - (Vector2)_firePoint.position).normalized;
//                 pirateCannonCore.SetInitialVelocity(direction * pirateCannonCore.GetSpeed());
//                 // pirateCannonCore.SetDamage(_damage);
//             }
//             else
//             {
//                 Debug.LogError("PirateCannonCore component not found on cannonBall.");
//             }
//         }
//         else
//         {
//             Debug.LogError("FirePoint or PirateCannonCorePrefab is not assigned.");
//         }
//     }
//     
//     // private void OnTriggerEnter2D(Collider2D other)
//     // {
//     //     if (other.CompareTag("PirateCannon"))
//     //     {
//     //     }
//     // }
// }
