using System;

namespace EnemiesGame
{
    public class EventManager
    {
        public static event Action EnemyDied;

        public static void OnEnemyDied()
        {
            EnemyDied?.Invoke(); // вызов ивента при hp = 0
        }
    }
}