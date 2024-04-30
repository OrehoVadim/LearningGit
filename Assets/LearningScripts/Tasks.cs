using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    //Cone
    public int radius = 50;
    public int height = 20;
    
    //Invert
    public int[] array = { 1, 3, 5, 7, 9, 11, 13 };

    //TODO put variables here, do not copy awake method. Use 1 awake method
    //TODO Uncomment all methods and classes
    //TODO use /// before each method or class and put task description there
    //TODO correct method name everywhere. Name rule - What will it do "The method will ..." ?
    //TODO all public field starts with Capital letter

    public void Awake()
    {
        // var coneVolume = CalculateConeVolume(radius, height);
        // Debug.Log(coneVolume);
    }
    

    /// <summary>
    /// 1) Написать метод для подсчета обьема конуса. Аргументы - радиус и высота. Возвращает посчитанный обьем
    /// </summary>
    public float CalculateConeVolume(int radius, int height)
    {
        return 3f / 4f * 3.1415f * (radius * radius) * height;
    }
    
    
// 1.1) Усовершенствовать задачу 1.
// Написать метод для подсчета общего объёма набора конусов.
// Добавить проверки на неправильные данные (как сможешь).   




// 1.2) Усовершенствовать задачу 1.1.
// Написать метод для подсчета обьема фигуры, в зависимости от ее типа (конус, цилиндр, шар, квадрат).
// Добавить всевозможные проверки.

    
// 2) Написать метод, который принимает аргументом массив чисел и возвращает “перевернутый массив”, +++
// то есть массив такого же размера, но с числами в обратном порядке.
    // public void Awake()
    // {
    //     int[] array = { 1, 3, 5, 7, 9, 11, 13 };
    //     int[] array2 = new int[array.Length];     //TODO return an array, use proper naming
    //     InvertedArray(array, array2);
    //     Debug.Log(string.Join(", ", array2));
    // }
    //
    // public int[] InvertedArray(int[] array, int[] array2)  // TODO Use proper naming  
    // {
    //     for (int i = 0; i < array.Length; i++)
    //     {
    //         array2[i] = array[array.Length - 1 - i];     
    //     }
    //     return array2;
    // }
    
    // Option 2:  -MK +++
    // public void Awake()
    // {
    //     int[] array = { 1, 3, 5, 7, 9, 11, 13 };  
    //     InvertedArray(array);
    //     Debug.Log(string.Join(", ", array));
    // }
    //
    // public int[] InvertedArray(int[] array)
    // {
    //     for (int i = 0; i < array.Length / 2; i++)
    //     {
    //         int value = array[i];
    //         array[i] = array[array.Length - 1 - i];
    //         array[array.Length - 1 - i] = value;
    //     }
    //     return array;
    // }
    
    
// 2.1) Решить задачу № 2 про “перевернутый массив” всеми тремя циклами -
// while, for, foreach    
    
    
// 3) Написать метод для обработки списка оценок.
// Оценки получаем в американском стиле - A,B,C,D,E,
// для каждой оценки вывести в консоль ее аналог цифрой: A =5, B = 4 и т.д.
    // public void Awake()
    // {
    //     List<char> evaluations = new List<char> {'A', 'B', 'C', 'D', 'E' };
    //     evaluations = ProcessingListRatings(evaluations);   //TODO Why? You changed nothing and return the same array
    //     Debug.Log(evaluations); //{'A', 'B', 'C', 'D', 'E' };
    // }
    //
    // public List<char> ProcessingListRatings(List<char> evaluations)
    // {
    //     foreach (var value in evaluations)
    //     {
    //         switch (value)
    //         {
    //             case 'A':
    //             {
    //                 Debug.Log("5");
    //                 break;
    //             }
    //             case 'B':
    //             {
    //                 Debug.Log("4");
    //                 break;
    //             }
    //             case 'C':
    //             {
    //                 Debug.Log("3");
    //                 break;
    //             }
    //             case 'D':
    //             {
    //                 Debug.Log("2");
    //                 break;
    //             }
    //             case 'E':
    //             {
    //                 Debug.Log("1");
    //                 break;
    //             }
    //         }
    //     }
    //     return evaluations;
    // }

    
// 3.1) Переделать задачу 3,
// заменить switch на Dictionary.
// Добавить проверки на неправильные данные (как сможешь).    
    
    
// 4) Есть List, в котором хранятся яблоки, у каждого яблока свой вес.
// В начале кода просто добавить в лист 10 яблок с разным весом.
// Потом нужно найти в этом листе яблоки, у которых вес < 100 грамм и выкинуть их из листа.
    // public void Awake()
    //  {
    //      List<Apples> apples = ApplesWeight();     //TODO Remove arguments initialization outside of the method
    //      foreach (var apple in apples)
    //      {
    //          Debug.Log(apple.weight);
    //      }
    //  }
    //  public class Apples    //TODO Naming
    //  {
    //      public int weight;   //TODO Naming
    //  }
    //
    //  public List<Apples> ApplesWeight()
    //  {
    //
    //      List<Apples> apples = new List<Apples>();
    //
    //      apples.Add(new Apples { weight = 85 });   //TODO wrong
    //      apples.Add(new Apples { weight = 100 });
    //      apples.Add(new Apples { weight = 130 });
    //      apples.Add(new Apples { weight = 70 });
    //      apples.Add(new Apples { weight = 65 });
    //      apples.Add(new Apples { weight = 180 });
    //      apples.Add(new Apples { weight = 125 });
    //      apples.Add(new Apples { weight = 195 });
    //      apples.Add(new Apples { weight = 75 });
    //      apples.Add(new Apples { weight = 70 });
    //
    //      for (int i = apples.Count - 1; i >= 0; i--)
    //      {
    //          if (apples[i].weight < 100)
    //          {
    //              apples.Remove(apples[i]);
    //          }
    //      }
    //      return apples;
    //  } 


// 5) Написать метод, который принимает аргументом строку и возвращает количество гласных в ней    
    // public void Awake()
    // {
    //     string text = "Strings are used for storing text.";
    //     int vowels = NumberVowelsStrings(text);
    //     Debug.Log(vowels);
    // }
    //
    // public int NumberVowelsStrings(string text)
    // {
    //     int vowels = 0;
    //     
    //     char[] vowelsArray = { 'a', 'e', 'i', 'o', 'u', 'y' };
    //     foreach (var values in vowelsArray)   //TODO illogical loop, you need to check your string for vowels, not vowels for string
    //     {
    //         for (int i = 0; i < text.Length; i++)
    //         {
    //             if (text [i] == values)
    //             {
    //                 vowels++;
    //             }
    //         } 
    //     }
    //     return vowels;
    // }


// 6) Создать логику Адресной Книги      //TODO Incorrect and incomplete. Use OOP to define a class with all needed logic

    // public void Awake()
    // {
    //     List<AddressBook> addressBook = DataInput();
    //     foreach (var address in addressBook)
    //     {
    //         Debug.Log($"Name: {address.name} \n Number: {address.phoneNumber} \n Address: {address.city}");
    //     }
    // }
    //
    //
    // public List<AddressBook> DataInput()
    // {
    //     List<AddressBook> addressBook = new List<AddressBook>();
    //     addressBook.Add(new AddressBook { name = "Victor", phoneNumber = 7920995, city = "London" });
    //     addressBook.Add(new AddressBook { name = "Jerry", phoneNumber = 9656235, city = "Berlin" });
    //     addressBook.Add(new AddressBook { name = "Tom", phoneNumber = 1560826, city = "Tokyo" });
    //     addressBook.Add(new AddressBook { name = "Mary", phoneNumber = 5550826, city = "NY" });
    //     
    //     return addressBook;
    // }


// 7) Создать игру
// “Угадай Номер”    


// 8) Описать класс
// “Человек”


// 9) Написать метод,
// который принимает аргументом строку
// и возвращает сумму отдельных чисел в ней

}
