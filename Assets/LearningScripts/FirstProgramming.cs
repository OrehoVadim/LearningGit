using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using Random = System.Random;

namespace LearningScripts
{
    public class FirstProgramming : MonoBehaviour
    { 
// 1) В корзине 2 яблока, 3 груши и 2 банана+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      // Сколько фруктов в корзине?
      // public void Awake()
      // {
      //     int apples = 2;
      //     int pears = 3;
      //     int bananas = 2;
      //     
      //     int result = FruitAmount(apples , pears, bananas);
      //     Debug.Log(result);
      // }
      //   public int FruitAmount(int a, int b, int c)      
      //   {
      //       return a + b + c;
      //   }
        
// 2) Написать метод для поиска индекса элемента массива++++++++++++++++++++++++++++++++++++++++++++++
      // (тип элементов в массиве -int),
      // метод должен вернуть индекс первого найденного элемента (если он будет найден).

        // public void Awake()
        // {
        //     int[] array = { 5, 8, 6, 26, 3, 8, 45, 7 };
        //     int hiddenElement = 7;
        //     int elementIndex = GuessElement(array, hiddenElement);
        //     Debug.Log(elementIndex);
        // }
        //
        // public int GuessElement(int[] array, int hiddenElement)
        // {
        //     for (int i = 0; i < array.Length; i++)
        //     {
        //         if (array[i] == hiddenElement)
        //         {
        //             return i;
        //         }
        //     }
        //     return 0;
        // }
        
                // public class Exception : Exception
                // {
                //     public Exception(string message) : base(message)
                //     {
                //     }
                // } 
        
// 3) Найти минимальный элемент массива ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // public void Awake()
        // {
        //     int minValue = FindMinElement();
        //     Debug.Log(minValue);
        // }
        // public int FindMinElement()
        // {
        //     int[] array = { 5, 8, 6, 26, 3, 8, 45, 7 };
        //     int min = array[0];
        //     
        //     for (int i = 1; i < array.Length; i++) 
        //     {
        //         if (array[i] < min)
        //         {
        //             min = array[i];
        //         }
        //     }
        //     return min;
        // }

// 4) Найти два наибольших элемента массива -----------------------------------------------------------
//         public void Awake()
//         {
//             int[] array = { 5, 8, 6, 26, 3, 8, 45, 7 };
//             (int, int) twoLargestElements = FindTwoLargestElements(array);
//             Debug.Log(twoLargestElements);
//         }
//         public (int, int) FindTwoLargestElements(int[] array)
//         {
//             int max1 = array[0];
//             int max2 = 0;
//             // int twoMaxElements = max1, max2;
//             
//             for (int i = 1; i < array.Length; i++) 
//                 
//             {
//                 if (max1 < array[i])
//                 {
//                     max1 = array[i];
//                     max2 = max1;
//                 }
//             }
//             
//             for (int i = 1; i < array.Length; i++) 
//             {
//                 if (array[i] == max2)
//                 {
//                     continue;
//                 }
//                 if (max1 < array[i])
//                 {
//                     max1 = array[i];
//                 }
//             }
//             return (max1, max2);
//         }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
         // public void Awake()
         // {
         //     int[] array = { 5, 8, 6, 26, 3, 8, 45, 7 };
         //     (int max1, int max2) twoLargestElements = FindTwoLargestElements(array);
         //     Debug.Log(twoLargestElements);
         // }
         // public (int, int) FindTwoLargestElements(int[] array)
         // {
         //     int max1 = array[0];
         //     int max2 = array[1];
         //     if (max2 > max1)
         //     {
         //         max1 = max2;
         //         max2 = array[0];
         //     }
         //     
         //     for (int i = 1; i < array.Length; i++) 
         //     {
         //         if (max1 < array[i])
         //         {
         //             max1 = array[i];
         //         }
         //     }
         //     
         //     for (int i = 1; i < array.Length; i++) 
         //     {
         //         if (array[i] == max1)
         //         {
         //             continue;
         //         }
         //         if (max2 < array[i])
         //         {
         //             max2 = array[i];
         //         }
         //     }
         //     return (max1, max2);
         // }

// 5) Посчитать сумму элементов массива
         //     public void Awake()
         // {
         //     int[] array = { 5, 8, 6, 26, 3, 8, 45, 7 };
         //     int sumElements = SumElements(array);
         //     Debug.Log(sumElements);
         // }
         // public int SumElements(int[] array)
         // {
         //     int sum = 0;
         //     for (int i = 0; i < array.Length; i++)
         //     {
         //           sum += array[i];
         //           //sum = sum + array[i];
         //     }
         //     return sum;
         // }

// 6) Заполнить массив по возростанию от 1 до 100
        // public void Awake() 
        // {
        //     int[] array = new int [100];
        //     array = FillingArray(array);
        //     foreach (int element in array)
        //     {
        //         Debug.Log(element);
        //     }
        // }
        // public int[] FillingArray(int[] array)
        // {
        //     for (int i = 0; i < 100; i++)
        //     {
        //         array[i] = i + 1;
        //     }
        //     return array;
        // }

// 7) Создать и заполнить массив случайными целыми числами
    // - пример вызова генератора случайных чисел:
    // Random random = new Random();
    // int random = random.Next(1,10) - случайное число от 1 до 10
        // public void Awake() 
        // {
        //     int[] array = new int [10];
        //     array = FillingRandomNubers(array);
        //     foreach (int element in array)
        //     {
        //         Debug.Log(element);
        //     }
        // }
        // public int[] FillingRandomNubers(int[] array)
        // {
        //     Random random = new Random();
        //     
        //     for (int i = 0; i < 10; i++)
        //     {
        //         int rand = random.Next(1, 10);
        //         array[i] = rand;
        //     }
        //     return array;
        // }       

// 8) Проверить в массиве наличие одинаковых чисел
            // public void Awake()
            // {
            //         int[] array = { 5, 8, 6, 26, 3, 8, 5, 45, 7 };
            //         bool values = SameNumbers(array);
            //         Debug.Log(values);
            // }
            //
            // public bool SameNumbers(int[] array)
            // {
            //         bool result = false;
            //
            //         for (int i = 0; i < array.Length; i++)
            //         {
            //                 for (int j = i+1; j < array.Length; j++)
            //                 {
            //                         if (array[i] == array[j])
            //                         {
            //                                 result = true;
            //                                 break;
            //                         }
            //                 }
            //                 if (result)
            //                 {
            //                         break;
            //                 }
            //         }
            //         return result;
            // }

// 9) Переставить элементы массива в обратном порядке используя вспомогательный массив
            // public void Awake()
            // { 
            //         int[] array = { 5, 8, 6, 26, 3, 8, 5, 45, 7 };
            //         int[] array2 = new int[array.Length];
            //         ReverseElements(array, array2);
            //         Debug.Log(string.Join(", ", array2));
            // }
            //
            // public int[] ReverseElements(int[] array, int[] array2)
            // {
            //         for (int i = 0; i < array.Length; i++)
            //         {
            //                 array2[array2.Length - i - 1] = array[i];
            //         }
            //         return array2;
            // }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // public void Awake()
            // { 
            //         int[] array = { 5, 8, 6, 26, 3, 8, 5, 45, 7 };
            //         int[] array2 = new int[array.Length];
            //         ReverseElements(array, array2);
            //         Debug.Log(string.Join(", ", array2));
            // }
            //
            // public int[] ReverseElements(int[] array, int[] array2)
            // {
            //         for (int i = 0; i < array.Length; i++)
            //         {
            //                 array2[array2.Length - i - 1] = array[i];
            //         }
            //         return array2;
            // }

// 10) Переставить элементы массива в обратном порядке Не используя вспомогательный массив
            //  public void Awake()
            // { 
            //         int[] array = { 5, 8, 6, 26, 3, 8, 5, 45, 7 };
            //         ReverseElements(array);
            //         Debug.Log(string.Join(", ", array));
            // }
            //
            // public int[] ReverseElements(int[] array)
            // {
            //         for (int i = 0; i < array.Length / 2; i++)
            //         {
            //                 int value = array[i];
            //                 array[i] = array[array.Length - 1 - i];
            //                 array[array.Length - 1 - i] = value;
            //         }
            //         return array;
            // }


// 11) Посчитать сумму чисел в двухмерном массиве

            // public void Awake()
            // {
            //         int[,] array = new int[,] {{11,22,31},{4,53,6},{7,81,90}};
            //         int sum = 0;
            //         int height = array.GetLength(0);
            //         int width = array.GetLength(1);
            //         
            //         for (int i = 0; i < height; i++)
            //         {
            //                 for (int j = 0; j < width; j++)
            //                 {
            //                         sum += array[i, j];
            //                 }
            //         }
            //         Debug.Log(sum);
            // }
   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`
                // public void Awake()
                // {
                //         int[,] array = new int[,] {{11,22,31},{4,53,6},{7,81,90}};
                //         int sum = SumNumbers(array);
                //         Debug.Log(sum);
                // }
                //
                // public int SumNumbers(int[,] array)
                // { 
                //         int sum = 0;
                //         int height = array.GetLength(0);
                //         int width = array.GetLength(1);
                //                 
                //                 for (int i = 0; i < height; i++)
                //         {
                //                 for (int j = 0; j < width; j++)
                //                 {
                //                         sum += array[i, j];
                //                 }
                //         }
                //         return sum;
                // }

// 12) Заполнить двумерный массив 10 на 10 случайными числами от 1 до 9
            // public void Awake()
            // {
            //     int[,] array = new int[10,10];
            //     int height = array.GetLength(0);
            //     int width = array.GetLength(1);
            //     Random random = new Random();
            //         
            //     for (int i = 0; i < height; i++)
            //     {
            //         for (int j = 0; j < width; j++)
            //         {
            //             int rand = random.Next(1, 10);
            //             array[i, j] = rand;
            //         }
            //     }
            //
            //     for (int i = 0; i < height; i++)
            //     {
            //         for (int j = 0; j < width; j++)
            //         {
            //             Debug.Log(array[i,j]);
            //         }
            //     }
            // }
   // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // public void Awake()
            // {
            //     int size = 10;
            //     int[,] array = new int[size, size];
            //     array = FillingValues(array);
            //     
            //     int height = array.GetLength(0);
            //     int width = array.GetLength(1);
            //     for (int i = 0; i < height; i++)
            //     {
            //         for (int j = 0; j < width; j++)
            //         {
            //             Debug.Log(array[i,j]);
            //         } 
            //     }
            // }
            //
            // public int[,] FillingValues(int[,] array)
            // { 
            //     int height = array.GetLength(0);
            //     int width = array.GetLength(1);
            //     Random random = new Random();
            //          
            //     for (int i = 0; i < height; i++)
            //     {
            //         for (int j = 0; j < width; j++)
            //         {
            //             int rand = random.Next(1, 10);
            //             array[i, j] = rand;
            //         }
            //     }
            //     return array;
            // }
            
// 13) Двумерный массив скопировать в одномерный
            // public void Awake()
            // {
            //      int[,] array2 = new int[,] {{13,24,31},{7,53,6},{7,85,99}};
            //      int[] array1 = new int[array2.Length];
            //      array1 = CopyingArray(array2, array1);
            //      Debug.Log(string.Join(", ", array1));
            // }
            //
            // public int[] CopyingArray(int[,] array2, int[] array1)
            // {
            //     int x = array2.GetLength(0);
            //     int y = array2.GetLength(1);
            //     int value = 0;
            //     
            //     for (int i = 0; i < x; i++)
            //     {
            //         for (int j = 0; j < y; j++)
            //         {
            //             array1[value] = array2[i, j];
            //             value++;
            //         }
            //     }
            //     return array1;
            // }

// 14) Заполнить двумерниы массив 10 на 10 случайными числами от 1 до 99 и определить количество четных чисел в массиве
// int = 4 % 2;
        // public void Awake()
        // {
        //      int[,] array = new int[10,10];
        //      CopyingArray(array);
        //      int value = Counter(array);
        //      Debug.Log(value);
        //      
        //      // int height = array.GetLength(0);
        //      // int width = array.GetLength(1);
        //      // for (int i = 0; i < height; i++)
        //      // {
        //      //     for (int j = 0; j < width; j++)
        //      //     {
        //      //         Debug.Log(array[i,j]);
        //      //     } 
        //      // }
        // }
        //
        // public int[,] CopyingArray(int[,] array)
        // {
        //     Random random = new Random();
        //     int height = array.GetLength(0);
        //     int width = array.GetLength(1);
        //     
        //     for (int i = 0; i < height; i++)
        //     {
        //         for (int j = 0; j < width; j++)
        //         {
        //             int rand = random.Next(1, 50);
        //             array[i, j] = rand;
        //         }
        //     }
        //     return array;
        // }
        //
        // public int Counter(int[,] array)
        // {
        //     int quantityEvenNumbers = 0;
        //     int x = array.GetLength(0);
        //     int y = array.GetLength(1);
        //     
        //     for (int i = 0; i < x; i++)
        //     {
        //         for (int j = 0; j < y; j++)
        //         {
        //             if (array[i, j] % 2 == 0)
        //             {
        //                 quantityEvenNumbers++;
        //             }
        //         }
        //     }
        //
        //     return quantityEvenNumbers;
        // }

// 14) Одномерный массив скопировать в двумерный 4 на 4
        // public void Awake()
        // {
        //         int size = 4;
        //         int[] array1 = {12,55,65,84,22,961,52,541,51,42,35,68,75,23,45,78};
        //         int[,] array2 = new int[size, size];
        //         array2 = CopyingArray(array1, array2);
        //
        //         int height = array2.GetLength(0);
        //         int width = array2.GetLength(1);
        //         for (int i = 0; i < height; i++)
        //         {
        //                  for (int j = 0; j < width; j++)
        //                  {
        //                          Debug.Log(array2[i,j]);
        //                  } 
        //         }
        // }
        //
        // public int[,] CopyingArray(int[] array1, int[,] array2)
        // {
        //         int x = array2.GetLength(0);
        //         int y = array2.GetLength(1);
        //         int f = 0;
        //         for (int i = 0; i < x; i++)
        //         {
        //                 for (int j = 0; j < y; j++)
        //                 {
        //                         array2[i, j] = array1[f]
        //                         f++;
        //                 }        
        //         }
        //         return array2;
        // }
        
        
        
// Метод для приветствия:
// Напиши метод,который принимает имя пользователя как аргумент и печатает приветствие с этим именем.
        // public void Awake()
        // {
        //     string name = "Vadim";
        //     Greetings(name);
        // }
        //
        // public void Greetings(string name)
        // {
        //     Debug.Log("Welcome to this code, " + name);
        // }
        
// Метод для расчёта:
// Создай метод, который принимает два аргумента (цена товара и количество), возвращает общую стоимость.
        // public void Awake()
        // {
        //         float price = 45.50f;
        //         int quantity = 5;
        //         float totalCost = Calculation( price, quantity);
        //         Debug.Log(totalCost);
        // }
        //
        // public float Calculation(float price, int quantity)
        // {
        //         return price * quantity;
        // }

// Метод возвращающий булево значение:
// Напиши метод, который проверяет, является ли переданное ему число четным, и возвращает true или false.
        // public void Avake()
        // {
        //     int number = 77;
        //     bool result = ReturningBooleanValue(number);
        //     Debug.Log(result);
        // }
        //
        // public bool ReturningBooleanValue(int number)
        // {
        //     if(number % 2 == 0)
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
            
// Метод с несколькими параметрами:
// Напиши метод, который принимает три числа и возвращает их среднее арифметическое.
        // public void Awake()
        // {
        //         float a = 34.5f;
        //         float b = 12.3f;
        //         float c = 47.4f;
        //         float value = ReturnsArithmeticValue(a, b, c);
        //         Debug.Log(value);
        // }
        //
        // public float ReturnsArithmeticValue(float a, float b, float c)
        // {
        //         return (a + b + c) / 3;
        // }

// Метод для работы со строками:
// Напиши метод, который принимает строку и
// Напиши метод, который принимает строку,
// но с первой заглавной буквой каждого слова.
            // public void Awake()
            // {
            //     string text = "Arrays are used to store multiple values in a single variable, " +
            //                       "instead of declaring separate variables for each value.";
            //     string result = TextStrings(text);
            //     Debug.Log(result);
            // }
            //
            //     public string TextStrings(string text)
            //     {
            //         string[] words = Input.Split('');
            //
            //         for (int i = 0; i < words.Length; i++)
            //         {
            //             words[i] =
            //         }
            //         
            //         return;
            //     }
            
            
            
            
            // public class Content
        // {
        //     public int Money;
        // }
        //
        // public class Cell
        // {
        //     public Content Wallet;
        // }
        //
        // public Content GetElement(Cell[] array, int cellIndex)
        // {
        //     Cell ourCell = array[cellIndex];
        //     Content wallet = ourCell.Wallet;
        //     return wallet;
        //     // подхожу к ячейке
        //     // Открываю ячейку
        //     // Забираю вместимое
        // }



        // public class Apple
        // {
        //     public int Weight = 0;
        // }
        //
        // //входные данные - два яблока
        // //беру первое яблоко
        // //взвешиваю
        // //беру второе яблоко
        // //взвешиваю
        // //суммирую вес
        // public int CalculateWeight(Apple firstApple, Apple secondApple)
        // {
        //     var firstAppleWeight = firstApple.Weight;
        //     var secondAppleWeight = secondApple.Weight;
        //     var result = firstAppleWeight + secondAppleWeight;
        //
        //     return result;
        // }
        //
        // public int CalculateWeight(int firstAppleWeight, int secondAppleWeight)
        // {
        //     //
        //     var result = (firstAppleWeight + secondAppleWeight) * 2 + (firstAppleWeight + secondAppleWeight) * 2;
        //     return result;
        // }



        // private void OutputVariables()
        // {
        //     string name = "Mario";
        //     int lifes = 3;
        //     int coins = 0;
        //     char connector = '&';
        //     bool hasLives = true;
        //     
        //     Debug.Log("Name: " + name);
        //     Debug.Log("Lifes: " + lifes);
        //     Debug.Log("Coins: " + coins);
        //     Debug.Log($"Name: {name} {connector} Lifes: {lifes} {connector} Coins: {coins}");
        //     
        //    coins = 50;
        //
        //     bool itRains = false;
        //     
        //     if (itRains == true)
        //     {
        //         Debug.Log("Take an umbrella, it's rainy outside");
        //     }
        //     
        //     Debug.Log("Coins: " + coins);
        //     
        // }
    }
}