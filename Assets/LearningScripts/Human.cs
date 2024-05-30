namespace LearningScripts
{
    public partial class Human
    {
        public int Age { get; private set; }
        public float Weight;

        public Human(int age)
        {
            Age = age;
        }
        
        
        /// <summary>
        /// метод у человека, где мы кушаем яблоко и вес увеличивается на вес этого яблока
        /// </summary>
        public void Eat(AppleList.Apple apple) // тип + название
        {
            Weight += apple.Weight;
        }

        public void LiveOneYear()
        {
            Age += 1;
        }
    }
}