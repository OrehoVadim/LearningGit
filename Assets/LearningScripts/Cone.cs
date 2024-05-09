namespace LearningScripts
{
    public class Cone
    {
        public float Radius { get; private set; }
        public float Height { get; private set; }

        public Cone(float radius, float height)
        {
            Radius = radius;
            Height = height;
        }
    }
}