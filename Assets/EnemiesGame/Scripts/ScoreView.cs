using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EnemiesGame
{
    public class ScoreView : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private int _score = 0;
        // private Enemy _enemy;
        
        private GameObject _player;
        public AudioClip audioClip;
        private AudioSource _audioSource;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            EventManager.EnemyDied += OnEnemyDied; // Подписка на ивент
            // _enemy.Died += OnDied;

            _player = GameObject.FindGameObjectWithTag("Player");
            if (_player != null)
            {
                _audioSource = _player.GetComponent<AudioSource>();
            }
            else
            {
                Debug.Log("Player object not found or does not have AudioSource component");
            }
        }

        private void OnDestroy()
        {
            EventManager.EnemyDied -= OnEnemyDied; // Отписка от ивента
        }

        private void OnEnemyDied()
        {
            _audioSource.PlayOneShot(audioClip);
            _score++;
            _scoreText.text = "Score: " + _score;
        }
    }
}