using System.Collections.Generic;

namespace LearningScripts
{
    public class AppleList
    {
        public List<Apple> AppleWeightList = new List<Apple>();

        // public AppleList()
        // {
        //     AppleWeightList.Add(new Apple (85));
        //     AppleWeightList.Add(new Apple (100));
        //     AppleWeightList.Add(new Apple (130));
        //     AppleWeightList.Add(new Apple (70));
        //     AppleWeightList.Add(new Apple (65));
        //     AppleWeightList.Add(new Apple (180));
        //     AppleWeightList.Add(new Apple (125));
        //     AppleWeightList.Add(new Apple (195));
        //     AppleWeightList.Add(new Apple (75));
        //     AppleWeightList.Add(new Apple (70));
        // }
        
        public class Apple
        {
            public float Weight { get; private set; }

            public Apple(float weight)
            {
                Weight = weight;
            }
        }
    }
}