using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EnemiesGame
{
    // 10) У нас есть один игрок
    //     На него постоянно идут враги, враги разного типа: бот, танк, самолет.
    //     Игрок может стрелять по врагам и наносить им некоторый урон
    //     Бот ничем не выделяется, у него есть только здоровье. 
    //     У танка есть броня, Которая уменьшает прямо урон на количество очков брони.
    //     У самолета есть 33 процента шанс увернуться от урона и не получить его вообще.
    //     Брони у самолета нет.

    // 10.1) Создаем класс, который раз в x секунд создает врага
    //       - x выбирается случайно от 1 до 3
    //       - Враг начинает двигаться по прямой всегда в одном направлении
    //       - Когда враг проходит x метров, он самоуничтожается
    //       Добавляем логику “смерти”. При смерти обьект врага уничтожается. Смерть наступает, когда заканчивается HP

    // 10.2) На пути врага куда-нибудь ставим обьект “игрока”, он находится в одном месте и не двигается.
    //       Игрок постоянно “ищет” врагов. Как только враг найдет, 
    //       игрок поворачивается в сторону найденного врага и “смотрит” на него до тех пор, 
    //       пока враг не умрет или не самоуничтожится, после этого игрок фокусируется на новом враге.
    //       По нажатию на кнопку игрок “стреляет” во врага, на котором он сфокусирован, нанося ему урон.

    // 10.3) Добавляем индикатор здоровья врагам. Можно сделать любым способом, какой захочется.
    //       Добавляем возможность настраивать здоровье противников, их скорость и урон игрока из Юнити.
    //       Добавляем индикатор очков, игрок зарабывает 1 очко за убийство врага
    //       Игра заканчивается через 60 секунд, появляется окно с поздравлением о победе, если мы набрали больше 10 очков или проигрыше, если нет.
    //       Добавляем любую анимацию/систему частиц/индикацию выстрела игрока.


    public class GameManager : MonoBehaviour // класс управляющий игровой логикой
    {

        [SerializeField] private Enemy _enemyPrefab; // Префаб врага, который будет создаваться
        [SerializeField] private Player _playerPrefab; // Префаб игрока, экземпляр объекта с настройками и компонентами
        [SerializeField] private GameObject _panelSettings;
        
        public float timeStart;
        public Text timerText;
        
        private float _time = 0.0f; // Переменная для отслеживания времени
        public float InterpolationPeriod = 3; // Переменная интервала между созданиями врагов
        
        public void Start() // Инициализация объекта Player в момент его активации
        {
            if (_panelSettings != null)
            {
                _panelSettings.SetActive(false);
            }

            // _playerPrefab.transform.localPosition = new Vector3(0f, 0f, 0f); // Позиция игрока на поле (transform - компонент объекта с позицией, поворотом и масштабом)
            
            // timerText.text = timeStart.ToString();
        }
        
        public void Update()
        {
            timeStart -= Time.deltaTime;
            // timerText.text = Mathf.Round(timeStart).ToString();
        }

        public void Play()
        {
            SceneManager.LoadScene("EnemiesGameScene");
            // SceneManager.LoadScene(1);
        }

        public void GameMenu()
        {
            SceneManager.LoadScene("GameMenu");
            // SceneManager.LoadScene(0);
        }

        // public void Settings()
        // {
        //     if (_panelSettings.activeSelf == false)
        //     {
        //         _panelSettings.SetActive(true);
        //     }
        //     else if (_panelSettings.activeSelf == true)
        //     {
        //         _panelSettings.SetActive(false);
        //     }
        // }
        
        public void Exit()
        {
            Application.Quit();
        }
    }
}