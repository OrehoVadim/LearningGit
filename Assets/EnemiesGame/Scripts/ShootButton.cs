using System;
using EnemiesGame;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.interactable = false;
    }

    private void Update()
    {
        if (!_button.interactable && _player.CanShoot)
        {
            _button.interactable = true;
        }
    }

    public void Shoot()
    {
        if (_player.CanShoot)
        {
            _player.Shoot();
            _button.interactable = false;
        }
    }
}
