using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnemiesGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _winnerPanel;
        [SerializeField] private GameObject _restartPanel;

        public void PauseOn()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        public void PauseOff()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 0;
        }
        
        public void Win()
        {
            _winnerPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Restart()
        {
            _restartPanel.SetActive(true);
            // if(_winnerPannel.)
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}