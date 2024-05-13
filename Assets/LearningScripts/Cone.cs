using System.Collections.Generic;

namespace LearningScripts
{
    public class Task1NoOOP
    {
        public float SumConeVolumes(List<float> radiusList, List<float> heightList) // Метод для вычисления суммы объемов конусов
        {
            float sum = 0;  // Инициализируем переменную sum для хранения суммы объемов конусов

            if (radiusList.Count > heightList.Count) // Проверяем, равны ли списки длины. Если нет, возвращаем 0, так как объемы невозможно вычислить
            {
                return 0;
            }
            
            for (int i = 0; i < radiusList.Count; i++) // Проходим по спискам радиусов и высот
            {
                sum += CalculateConeVolume(radiusList[i], heightList[i]);  // Добавляем объем конуса с текущим радиусом и высотой к общей сумме
            }

            return sum; //Возвращаем общую сумму объемов конусов
        }
        
        private float CalculateConeVolume(float radius, float height) // Приватный метод для вычисления объема конуса по заданным радиусу и высоте
        {
            return 1f / 3f * 3.1415f * (radius * radius) * height; // Формула для вычисления объема конуса
        }
    }

    //----------------------------------------------------------
    
    public class Task1_OOP
    {
        /// <summary>
        /// 1.1) Усовершенствовать задачу 1.
        /// Написать метод для подсчета общего объёма списка конусов.
        /// Добавить проверки на неправильные данные (как сможешь).
        /// Входные данные:
        /// Алгоритм:
        /// Результат:
        /// </summary>
        public float SumConeVolumesOOP(List<Cone> cones) // Метод для вычисления суммы объемов конусов с использованием объектов Cone
        {
            float sum = 0; // Инициализируем переменную sum для хранения суммы объемов конусов

            foreach (var cone in cones) // Проходим по списку объектов Cone
            {
                sum += cone.CalculateConeVolume(); // Добавляем объем текущего конуса к общей сумме
            }

            return sum; // Возвращаем общую сумму объемов конусов
        }
    }

    public class Cone
    {
        public float Radius { get; private set; } // Свойство для радиуса конуса
        public float Height { get; private set; } // Свойство для высоты конуса

        public Cone(float radius, float height) // Конструктор класса Cone, принимающий радиус и высоту конуса
        {
            Radius = radius; // Присваиваем значения радиусу
            Height = height; // Присваиваем значения высоте
        }
        
        /// <summary>
        /// 1) Написать метод для подсчета объёма конуса. Аргументы - радиус и высота. Возвращает посчитанный объём.
        /// Входные данные: конус, радиус, высота
        /// Алгоритм: добавить данные в формулу для подсчета объёма
        /// Результат: объём конуса
        /// </summary>
        public float CalculateConeVolume() // Метод для вычисления объема конуса
        {
            return 1f / 3f * 3.1415f * (Radius * Radius) * Height; // Формула для вычисления объема конуса
        }
    }
}