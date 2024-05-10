using System.Collections.Generic;

namespace LearningScripts
{
    public class Task1NoOOP
    {
        public float SumConeVolumes(List<float> radiusList, List<float> heightList)
        {
            float sum = 0;

            if (radiusList.Count > heightList.Count)
            {
                return 0;
            }
            
            for (int i = 0; i < radiusList.Count; i++)
            {
                sum += CalculateConeVolume(radiusList[i], heightList[i]);
            }

            return sum;
        }
        
        private float CalculateConeVolume(float radius, float height)
        {
            return 3f / 4f * 3.1415f * (radius * radius) * height;
        }
    }

    //----------------------------------------------------------
    
    public class Task1_OOP
    {
        public float SumConeVolumesOOP(List<Cone> cones)
        {
            float sum = 0;

            foreach (var cone in cones)
            {
                sum += cone.CalculateConeVolume();
            }

            return sum;
        }
    }

    public class Cone
    {
        public float Radius { get; private set; }
        public float Height { get; private set; }

        public Cone(float radius, float height)
        {
            Radius = radius;
            Height = height;
        }
        
        public float CalculateConeVolume()
        {
            return 3f / 4f * 3.1415f * (Radius * Radius) * Height;
        }
    }
}