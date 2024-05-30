using System.Collections.Generic;
using LearningScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Tasks : MonoBehaviour
{
    //TODO put variables here, do not copy awake method. Use 1 awake method
    //TODO Uncomment all methods and classes
    //TODO use /// before each method or class and put task description there
    //TODO correct method name everywhere. Name rule - What will it do "The method will ..." ?
    //TODO all public field starts with Capital letter

    public void Awake()
    {
        // Player player = new Player();
        // Enemy[] enemyInfo = { new Bot(), new Tank(), new Airplane() };
        // foreach (var enemy in enemyInfo)
        // {
        //     player.CheckInfo(enemy);
        //     Debug.Log(enemy);
        // }
        
        
        // Task №1
        Cone cone = new Cone(50f, 20f);
        float radius = cone.Radius;
        float height = cone.Height;
        var volume = CalculateConeVolume(radius, height);
        Debug.Log(volume);
        
        // Task №2, Option 1
        int[] arrayNew = InvertArray(Arrays.Array); //TODO return an array, use proper naming
        Debug.Log(string.Join(", ", arrayNew));
        
        // Task №2, Option 2
        InvertArray2(Arrays.Array2);
        Debug.Log(string.Join(", ", Arrays.Array2));
        
        //Task №2.1
        //Написать метод, который принимает аргументом массив чисел и возвращает “перевернутый массив”,
        //то есть массив такого же размера, но с числами в обратном порядке using System;
        //через while
        InvertArray3(Arrays.Array3);
        Debug.Log(string.Join(", ", Arrays.Array3));

        // Task №3
        Assessment assessment = new Assessment();
        assessment.AssignmentGrade('A');
        assessment.AssignmentGrade('B');
        assessment.AssignmentGrade('C');
        assessment.AssignmentGrade('D');
        assessment.AssignmentGrade('E');
        assessment.AssignmentGrade('C');
        assessment.AssignmentGrade('A');
        assessment.AssignmentGrade('E');
        assessment.AssigningValueEstimate();
        
        
        // Task №4, AppleList                    //TODO Remove arguments initialization outside of the method
        AppleList appleList = new AppleList(); //Создал экземпляр класса AppleList
        // AddAppleWeight(appleList);               //Вызвал метод добавления яблок в список
        ApplesWeightControl(appleList); //Вызвал метод контроля веса яблок
        foreach (var apples in appleList.AppleWeightList)
        {
            Debug.Log(apples.Weight);
        }

        // Task №5
        TextProcessing textProcessing = new TextProcessing();
        int vowels = textProcessing.NumberVowelsStrings("Strings are used for storing text.");
        Debug.Log(vowels);

        // Task №6
        AddressBook addressBook = new AddressBook();
        addressBook.AddAbonent("Jerry", "Jersey", "+1(438)5687999");
        addressBook.AddAbonent("Tom", "Scott", "+1(289)3527877");
        addressBook.AddAbonent("Jerry", "Jersey", "+1(438)5687999");
        addressBook.AddAbonent("Mary", "Petty", "+1(437)9653875");
     
        addressBook.DeleteAbonent("Jerry", "Jersey", "+1(438)5687999");
        addressBook.SeachAbonent("Mary");
        addressBook.PrintAbonent();

        // Task №8 (Human)
        Human human = new Human(35);
        human.Weight = 100f;

        // Task №9
        int sumNumbers = textProcessing.IndividualSumInString(
            "This is a Class 2 e-bike system limited to 20 mph with a throttle.");
        Debug.Log(sumNumbers);
    }



    /// <summary>
    /// 1) Написать метод для подсчета объёма конуса. Аргументы - радиус и высота. Возвращает посчитанный объём.
    /// Входные данные: конус, радиус, высота
    /// Алгоритм: добавить данные в формулу для подсчета объёма
    /// Результат: объём конуса
    /// </summary>
    public float CalculateConeVolume(float radius, float height)
    {
        return 1f / 3f * 3.1415f * (radius * radius) * height;
    }
    
    
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
    public void InvertArray2(int[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            int value = array[i];
            array[i] = array[array.Length - 1 - i];
            array[array.Length - 1 - i] = value;
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
    public void InvertArray3(int[] array)
    {
        int i = 0;
        while (i < array.Length / 2)
        {
            int value = array[i];
            array[i] = array[array.Length - 1 - i];
            array[array.Length - 1 - i] = value;
            i++;
        }
    }
    
    /// <summary>
    /// 4) Есть List, в котором хранятся яблоки, у каждого яблока свой вес.
    /// В начале кода просто добавить в лист 10 яблок с разным весом.
    /// Потом нужно найти в этом листе яблоки, у которых вес - 100 грамм
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
    
}

