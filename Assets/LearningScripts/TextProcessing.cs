using System;

namespace LearningScripts
{
    public class TextProcessing
    {
        /// <summary>
        /// 5) Написать метод, который принимает аргументом строку и возвращает количество гласных в ней
        /// Входные данные: строка с текстом
        /// Алгоритм: подсчет гласных в тексте
        /// Результат: количество гласных в тексте
        /// </summary>    
        public int NumberVowelsStrings(string text)
        {
            int vowels = 0;
            char[] vowelsArray = { 'a', 'e', 'i', 'o', 'u', 'y' };
            foreach (var values in vowelsArray) 
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == values)
                    {
                        vowels++;
                    }
                }
            }
            return vowels;
        }

        /// <summary>
        /// 9) Написать метод,
        /// который принимает аргументом строку и возвращает сумму отдельных чисел в ней
        /// Нужно найти все числа в строке и просуммировать их.
        /// Просто каждое отдельное число, от 0 до 9
        // - задача со звездой, любые числа (т,е, и 9 и 99 и 999 и так далее)
        /// Входные данные: Текст с цифрами
        /// Алгоритм: Найти и просуммировать цифры в тексте
        /// Результат: Общая сумма цифр
        /// </summary>
        public int IndividualSumInString(string textWithNumbers)
        {
            int sum = 0;
            char[] numbersArray = {'1','2','3','4','5','6','7','8','9','0'};
            foreach (char value in numbersArray)
            {
                for (int i = 0; i < textWithNumbers.Length; i++)
                {
                    if (textWithNumbers[i] == value)
                    {
                        sum += Convert.ToInt32(textWithNumbers[i].ToString());    
                    }
                }
            }
            return sum;
        }
    }
}