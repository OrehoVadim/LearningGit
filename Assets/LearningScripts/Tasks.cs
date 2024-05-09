using System.Collections.Generic;
using LearningScripts;
using Unity.VisualScripting;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    //Invert (Task №2)
    public int[] array = { 1, 3, 5, 7, 9, 11, 13 };
    public int[] array2 = { 2, 4, 6, 8, 10, 12, 14 };
    public int[] array3 = { 3, 6, 9, 12, 15, 18};

    //Text (Task №5)
    string text = "Strings are used for storing text.";
    

    //TODO put variables here, do not copy awake method. Use 1 awake method
    //TODO Uncomment all methods and classes
    //TODO use /// before each method or class and put task description there
    //TODO correct method name everywhere. Name rule - What will it do "The method will ..." ?
    //TODO all public field starts with Capital letter


    public void Awake()
    {
        // Task №1
        Cone cone = new Cone(50f, 20f);
        float radius = cone.Radius;
        float height = cone.Height;
        var coneVolume = CalculateConeVolume(radius, height);
        Debug.Log(coneVolume);
        
        // Task №1.1
        // CalculateTotalConeVolume();
        // Task №1.2
        // CalculateFigureVolume();

        // Task №2, Option 1
        int[] arrayNew = InvertArray(array); //TODO return an array, use proper naming
        Debug.Log(string.Join(", ", arrayNew));
        // Task №2, Option 2
        InvertArray2(array2);
        Debug.Log(string.Join(", ", array2));
        
        //Task №2.1
        //Написать метод, который принимает аргументом массив чисел и возвращает “перевернутый массив”,
        //то есть массив такого же размера, но с числами в обратном порядке using System;
        //через while
        InvertArray3(array3);
        Debug.Log(string.Join(", ", array3));

        // Task №3
        List<char> GradesList = new List<char>();
        RatingsListHandler(GradesList);

        // Task №4, AppleList                    //TODO Remove arguments initialization outside of the method
        AppleList appleList = new AppleList(); //Создал экземпляр класса AppleList
        // AddAppleWeight(appleList);               //Вызвал метод добавления яблок в список
        ApplesWeightControl(appleList); //Вызвал метод контроля веса яблок
        foreach (var apples in appleList.AppleWeightList)
        {
            Debug.Log(apples.Weight);
        }

        // Task №5
        int vowels = NumberVowelsStrings(text);
        Debug.Log(vowels);

        // Task №6
        AddressBook addressBook = new AddressBook();
        AddAbonents(addressBook);
        // foreach (var abonents in addressBook.AbonentsList)
        // {
        //     Debug.Log($"{abonents.Name} {abonents.Surname}, {abonents.PhoneNumber}");
        // }
        DeleteAbonents(addressBook);
        // foreach (var abonents in addressBook.AbonentsList)
        // {
        //     Debug.Log($"{abonents.Name} {abonents.Surname}, {abonents.PhoneNumber}");
        // }
        string searchAbonentName = "Tom";
        // SearchAbonents(addressBook);
        // foreach (var abonents in addressBook.AbonentsList)
        // {
        //     Debug.Log($"{abonents.Name} {abonents.Surname}, {abonents.PhoneNumber}");
        // }
        AllAbonents(addressBook);

        // Task №8 (Human)
        Human human = new Human(35);
        human.Weight = 100f;

        // Task №9
        // IndividualSumInString();
    }



    /// <summary>
    /// 1) Написать метод для подсчета объёма конуса. Аргументы - радиус и высота. Возвращает посчитанный объём.
    /// Входные данные: конус, радиус, высота
    /// Алгоритм: добавить данные в формулу для подсчета объёма
    /// Результат: объём конуса
    /// </summary>
    public float CalculateConeVolume(float radius, float height)
    {
        return 3f / 4f * 3.1415f * (radius * radius) * height;
    }
    
    /// <summary>
    /// 1.1) Усовершенствовать задачу 1.
    /// Написать метод для подсчета общего объёма списка конусов.
    /// Добавить проверки на неправильные данные (как сможешь).
    /// Входные данные:
    /// Алгоритм:
    /// Результат:
    /// </summary>
    // public void CalculateTotalConeVolume()
    // {
    // }
    
    /// <summary>
    /// 1.2) Усовершенствовать задачу 1.1.
    /// Написать метод для подсчета обьема фигуры,
    /// в зависимости от ее типа (конус, цилиндр, шар, квадрат).
    /// Добавить всевозможные проверки.
    /// Входные данные: 
    /// Алгоритм: 
    /// Результат: 
    /// </summary>
    // public void CalculateFigureVolume()
    // {
    // }


    /// <summary>
    /// 2) Написать метод, который принимает аргументом массив чисел и возвращает “перевернутый массив”, +++
    /// то есть массив такого же размера, но с числами в обратном порядке.
    /// Входные данные: масив чисел
    /// Алгоритм: перевернуть массив чисел
    /// Результат: перевернутый массив
    /// </summary>   

    // Option 1:
    public int[] InvertArray(int[] array) // TODO Use proper naming  
    {
        int[] ArrayNew = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            ArrayNew[i] = array[array.Length - 1 - i];
        }
        return ArrayNew;
    }

    // Option 2:  -MK +++
    public void InvertArray2(int[] array2)
    {
        for (int i = 0; i < array2.Length / 2; i++)
        {
            int value = array2[i];
            array2[i] = array2[array2.Length - 1 - i];
            array2[array2.Length - 1 - i] = value;
        }
    }


    /// <summary>
    /// 2.1) Написать метод, который принимает аргументом массив чисел и возвращает “перевернутый массив”,
    /// то есть массив такого же размера, но с числами в обратном порядке using System,
    /// через while
    /// Входные данные: масив
    /// Алгоритм: перевернуть массив чисел через while
    /// Результат: перевернутый массив
    /// </summary>
    public void InvertArray3(int[] array3)
    {
        int i = 0;
        while (i < array3.Length / 2)
        {
            int value = array3[i];
            array3[i] = array3[array3.Length - 1 - i];
            array3[array3.Length - 1 - i] = value;
            i++;
        }
    }

    
    /// <summary>
    /// 3) Написать метод для обработки списка оценок. Оценки получаем в американском стиле - A,B,C,D,E, для каждой оценки вывести в консоль ее аналог цифрой: A =5, B = 4 и т.д.
    /// Входные данные: список оценок, оценки буквы, оценки цифры
    /// Алгоритм: Добавить буквы в список, буквам присвоить цифры, вывести в консоль
    /// Результат: в консоле буква равна соответствующей цифре
    /// </summary>      
    public void RatingsListHandler(List<char> GradesList)
    {
        GradesList.Add('A');
        GradesList.Add('B');
        GradesList.Add('C');
        GradesList.Add('D');
        GradesList.Add('E');
        GradesList.Add('C');
        GradesList.Add('A');
        GradesList.Add('E');

        foreach (var value in GradesList)
        {
            switch (value)
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


    /// <summary>
    /// 4) Есть List, в котором хранятся яблоки, у каждого яблока свой вес.
    /// В начале кода просто добавить в лист 10 яблок с разным весом.
    /// Потом нужно найти в этом листе яблоки, у которых вес < 100 грамм
    /// и выкинуть их из листа
    /// Входные данные: список, яблоки, вес, количество
    /// Алгоритм: добавить, взвесить и удалить яблоки
    /// Результат: выборка яблок по весу
    /// </summary>      
    public void AddAppleWeight(AppleList appleList)
    {
        appleList.AppleWeightList.Add(new AppleList.Apple(85));
        appleList.AppleWeightList.Add(new AppleList.Apple(100));
        appleList.AppleWeightList.Add(new AppleList.Apple(130));
        appleList.AppleWeightList.Add(new AppleList.Apple(70));
        appleList.AppleWeightList.Add(new AppleList.Apple(65));
        appleList.AppleWeightList.Add(new AppleList.Apple(180));
        appleList.AppleWeightList.Add(new AppleList.Apple(125));
        appleList.AppleWeightList.Add(new AppleList.Apple(195));
        appleList.AppleWeightList.Add(new AppleList.Apple(75));
        appleList.AppleWeightList.Add(new AppleList.Apple(70));
    }

    public void ApplesWeightControl(AppleList appleList)
    {
        for (int i = appleList.AppleWeightList.Count - 1; i >= 0; i--)
        {
            if (appleList.AppleWeightList[i].Weight < 100)
            {
                appleList.AppleWeightList.Remove(appleList.AppleWeightList[i]);
            }
        }
    }


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
        foreach (var values in
                 vowelsArray) //TODO illogical loop, you need to check your string for vowels, not vowels for string
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
    /// 6) Создать логику Адресной Книги      //TODO Incorrect and incomplete. Use OOP to define a class with all needed logic
    /// Входные данные: список с именем, фамилией и номером телефона
    /// Алгоритм: создать логику Адресной Книги
    /// Результат: добавление новых абонентов, удаление абонентов, поиск абонента по имени, вывод информации о всех абонентах в книге
    /// </summary>
    public void AddAbonents(AddressBook addressBook)
    {
        addressBook.AbonentsList.Add(new AddressBook.Abonent("Jerry", "Jersey", "+1(438)5687999"));
        addressBook.AbonentsList.Add(new AddressBook.Abonent("Tom", "Scott", "+1(289)3527877"));
        addressBook.AbonentsList.Add(new AddressBook.Abonent("Jerry", "Jersey", "+1(438)5687999"));
        addressBook.AbonentsList.Add(new AddressBook.Abonent("Mary", "Petty", "+1(437)9653875"));
    }

    public void DeleteAbonents(AddressBook addressBook)
    {
        for (int i = addressBook.AbonentsList.Count -1; i >= 0 ; i--)
        {
            AddressBook.Abonent abonent = addressBook.AbonentsList[i];
            if (abonent.Name == "Jerry" && abonent.Surname == "Jersey" && abonent.PhoneNumber == "+1(438)5687999")
            {
                addressBook.AbonentsList.Remove(abonent);
            }
        }
    }

    // public void SearchAbonents(AddressBook addressBook, string searchAbonentName)
    // {
    //     for (int i = 0; i < addressBook.AbonentsList.Count; i++)
    //     {
    //         AddressBook.Abonent abonent = addressBook.AbonentsList[i]; //для проверки каждого абонента из списка 
    //         if (abonent.Name == searchAbonentName)
    //         {
    //             Debug.Log($"{abonent.Name} {abonent.Surname}, {abonent.PhoneNumber}");
    //         }
    //     }
    // }
    
    public void AllAbonents(AddressBook addressBook)
    {
        foreach (var abonents in addressBook.AbonentsList)
        {
            Debug.Log($"{abonents.Name} {abonents.Surname}, {abonents.PhoneNumber}");
        }
    }


    /// <summary>
    /// 9) Написать метод, который принимает аргументом строку и возвращает сумму отдельных чисел в ней
    /// Нужно найти все числа в строке и просумировать их. Просто каждое отдельное число, от 0 до 9
    // - задача со звездой, любые числа (т,е, и 9 и 99 и 999 и так далее)
    /// Входные данные: 
    /// Алгоритм: 
    /// Результат: 
    /// </summary>
    public void IndividualSumInString()
    {
    }
}

