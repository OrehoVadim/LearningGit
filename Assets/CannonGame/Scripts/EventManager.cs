namespace CannonGame.Scripts
{
    public class EventManager
    {
        public delegate void EnemyReachedDestructionPoint(int damage);
        public static event EnemyReachedDestructionPoint OnEnemyReachedDestructionPoint;

        public static void TriggerEnemyReachedDestructionPoint(int damage)
        {
            OnEnemyReachedDestructionPoint?.Invoke(damage);
        }
    }
}