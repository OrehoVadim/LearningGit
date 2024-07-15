namespace CannonGame.Scripts
{
    public class EventManager
    {
        public delegate void HealthUpdate(int currentHealth, int maxHealth);

        public static event HealthUpdate OnHealsUpdate;

        public static void TriggerHealthUpdate(int currentHealth, int maxHealth)
        {
            OnHealsUpdate?.Invoke(currentHealth, maxHealth);
        }
    }
}