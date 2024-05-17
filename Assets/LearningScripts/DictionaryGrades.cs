using System.Collections.Generic;
using UnityEngine;

namespace LearningScripts
{
    public class GradesDictionary
    {
        public Dictionary<char, int> DictionaryWithGrades = new Dictionary<char, int>()
        {
            { 'A', 5 },
            { 'B', 4 },
            { 'C', 3 },
            { 'D', 2 },
            { 'E', 1 }
        };
        
        public void DictionaryOutput()
        {
            foreach (var variable in DictionaryWithGrades)
            {
                    Debug.Log(variable.Key + " = " + variable.Value);
            }
        }
        
        public void AddGrades(char key, int value)
        {
            DictionaryWithGrades[key] = value;
        }
        
        public void Test()
        {
            // 1) Наличие ключа 'A' в словаре:
            //Debug.Log(DictionaryWithGrades.ContainsKey('A') ? "Ключ пресутствует" : "Введите Ключ пресутствует");
            // if (DictionaryWithGrades.ContainsKey('A'))
            // {
            //     Debug.Log("Ключ пресутствует");
            // }
            // else
            // {
            //     Debug.Log("Введите Ключ пресутствует");
            // }
            
            // 2) Соответствие ключей типу char
            // if (DictionaryWithGrades[key].GetType() == char)
            // {
            //     Debug.Log("Ключ типа char");
            // }
            // else
            // {
            //     Debug.Log("Неверный тип ключа");
            // }
            
            // 3) Проверка на соответствие ключа и значения нужнім типам (key == char && value == int), если нет то удалить
            // if (DictionaryWithGrades['A'].GetType() == typeof(char) &&DictionaryWithGrades(5).GetType() == typeof(char))
            // {
            //     Debug.Log("Типы ключей и значений соответствуют стандарту");
            // }
            // else
            // {
            //     Debug.Log("Неверный тип ключа");
            //     DictionaryWithGrades.Remove();
            // }
            
            // 4) Наличие данныз в Dictionary
            // if (DictionaryWithGrades.Count == 0)
            // {
            //     Debug.Log("Dictionary без данных");
            // }
            
            // 5) Какие данные хранит Dictionary
        }
    }
}