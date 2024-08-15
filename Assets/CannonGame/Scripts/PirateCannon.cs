using System.Collections;
using CannonGame.Scripts;
using UnityEngine;

public class PirateCannon : Enemy
{
    private bool _startedShooting = false;
    public static bool IsPirateCannonActive { get; private set; } = false;

    [SerializeField] private float _fireInterval = 1f;
    [SerializeField] private GameObject _pirateCannonCorePrefab;
    [SerializeField] private Vector2 _targetPosition = new Vector2(-82.7f, 4.5f);
    [SerializeField] private Transform _pirateFirePoint;
    private bool _hasReachedShootingPosition = false;

    public void SetPirateFirePoint(Transform pirateFirePoint)
    {
        _pirateFirePoint = pirateFirePoint;
    }

    private void OnEnable()
    {
        IsPirateCannonActive = true;
    }

    private void OnDisable()
    {
        IsPirateCannonActive = false;
    }

    private void Update()
    {
        if (!_hasReachedShootingPosition)
        {
            MoveTowardsPirateFirePoint();
        }
    }

    private void MoveTowardsPirateFirePoint()
    {
        if (_pirateFirePoint == null)
        {
            Debug.LogError("PirateFirePoint is not assigned.");
            return;
        }

        Vector2 target = new Vector2(_pirateFirePoint.position.x, transform.position.y);
        float step = _moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        float distance = Vector2.Distance(transform.position, _pirateFirePoint.position);
        Debug.Log($"Distance to PirateFirePoint: {distance}");

        if (distance < 0.1f)
        {
            _hasReachedShootingPosition = true;
            transform.position = _pirateFirePoint.position;
            Debug.Log("Reached shooting position");

            if (!_startedShooting)
            {
                // StartCoroutine(Shoot());
                _startedShooting = true;
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("PirateFirePoint"))
    //     {
    //         _hasReachedShootingPosition = true;
    //         transform.position = _pirateFirePoint.position;
    //         Debug.Log("Reached shooting position");
    //
    //         if (!_startedShooting)
    //         {
    //             StartCoroutine(Shoot());
    //             _startedShooting = true;
    //         }
    //     }
    // }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (_hasReachedShootingPosition)
            {
                FirePirateCannon();
            }

            yield return new WaitForSeconds(_fireInterval);
        }
    }

    private void FirePirateCannon()
    {
        if (_pirateFirePoint != null && _pirateCannonCorePrefab != null)
        {
            GameObject pirateCannonBall =
                Instantiate(_pirateCannonCorePrefab, _pirateFirePoint.position, Quaternion.identity);
            CannonCore pirateCannonCore = pirateCannonBall.GetComponent<CannonCore>();

            if (pirateCannonCore != null)
            {
                Vector2 direction = (_targetPosition - (Vector2)_pirateFirePoint.position).normalized;
                pirateCannonCore.SetInitialVelocity(direction * pirateCannonCore.GetSpeed());
                // pirateCannonCore.SetDamage(_damage);
            }
            else
            {
                Debug.LogError("PirateCannonCore component not found on cannonBall.");
            }
        }
        else
        {
            Debug.LogError("FirePoint or PirateCannonCorePrefab is not assigned.");
        }
    }
}
