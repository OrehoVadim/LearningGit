using TMPro;
using UnityEngine;

namespace EnemiesGame
{
    public class ScoreView : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private int _score = 0;
        
        private GameObject _player;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            EventManager.EnemyDied += OnEnemyDied; // Подписка на ивент
        }

        private void OnDestroy()
        {
            EventManager.EnemyDied -= OnEnemyDied; // Отписка от ивента
        }

        private void OnEnemyDied()
        {
            _score++;
            _scoreText.text = "Score: " + _score;
        }
    }
}