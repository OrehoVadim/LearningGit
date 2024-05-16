using System.Collections.Generic;
using UnityEngine;

namespace LearningScripts
{
    public class Assessment
    {
        List<char> GradesList = new List<char>();

        /// <summary>
        /// 3) Написать метод для обработки списка оценок. Оценки получаем в американском стиле - A,B,C,D,E, для каждой оценки вывести в консоль ее аналог цифрой: A =5, B = 4 и т.д.
        /// Входные данные: список оценок, оценки буквы, оценки цифры
        /// Алгоритм: Добавить буквы в список, буквам присвоить цифры, вывести в консоль
        /// Результат: в консоле буква равна соответствующей цифре
        /// </summary>
        public void AddGrade(char grade)
        {
            GradesList.Add(grade);
        }
        
        public void AssigningValueEstimate()
        {
            foreach (var letter in GradesList)
            {
                switch (letter)
                {
                    case 'A':
                        Debug.Log("5");
                        break;
                    case 'B':
                        Debug.Log("4");
                        break;
                    case 'C':
                        Debug.Log("3");
                        break;
                    case 'D':
                        Debug.Log("2");
                        break;
                    case 'E':
                        Debug.Log("1");
                        break;
                }
            }
        }
    }
}