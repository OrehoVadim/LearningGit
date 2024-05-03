using System.Collections.Generic;
using LearningScripts;
using Unity.VisualScripting;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    //Cone
    public int radius = 50;
    public int height = 20;

    //Invert
    public int[] array = { 1, 3, 5, 7, 9, 11, 13 };

    //Entering Grades
    public class EnteringGrade //TODO Naming
    {
        public char Grade; //TODO Naming
    }

    public class GradesClass
    {
        public List<EnteringGrade> GradesList = new List<EnteringGrade>();
        // public void Grades(List<EnteringGrade> GradesList)
        // {
        //     GradesList.Add(new EnteringGrade { Grade = 'A' });
        //     GradesList.Add(new EnteringGrade { Grade = 'B' });
        //     GradesList.Add(new EnteringGrade { Grade = 'C' });
        //     GradesList.Add(new EnteringGrade { Grade = 'D' });
        //     GradesList.Add(new EnteringGrade { Grade = 'E' });
        // }
    }

    //Apple Weight
    public class Apple //TODO Naming
    {
        public int Weight; //TODO Naming
    }

    public class AppleWeightClass
    {
        public List<Apple> ApplesList = new List<Apple>();

        public void AddAppleWeight(List<Apple> ApplesList)
        {
            ApplesList.Add(new Apple { Weight = 85 }); //TODO wrong
            ApplesList.Add(new Apple { Weight = 100 });
            ApplesList.Add(new Apple { Weight = 130 });
            ApplesList.Add(new Apple { Weight = 70 });
            ApplesList.Add(new Apple { Weight = 65 });
            ApplesList.Add(new Apple { Weight = 180 });
            ApplesList.Add(new Apple { Weight = 125 });
            ApplesList.Add(new Apple { Weight = 195 });
            ApplesList.Add(new Apple { Weight = 75 });
            ApplesList.Add(new Apple { Weight = 70 });
        }
    }

    //Text   
    string text = "Strings are used for storing text.";


    //AddressBook    


    public class Abonent
    {
        private string Name; // поле (переменная) будет хранить имя абонента
        private string Surname;
        private int PhoneNumber;


        public Abonent(string name, string surname, int phoneNumber) // Конструктор инициализирует объект
            // Принимает три параметра
            // Использует параметры для установки значений полей 
        {
            this.Name = name; // строка устанавливает значение поля Name
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
        }

        public string AccessToName // Свойство для доступа к приватному имени
        {
            get { return Name; }
            set { Name = value; }
        }

        public string AccessToSurname // Свойство для доступа к приватному имени
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public int AccessToPhoneNumber // Свойство для доступа к приватному имени
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

        public List<Abonent> AbonentsList = new List<Abonent>();
    }

    // public class AddressBook
    // {
    //     public void AllAbonents(List<Abonent> AbonentsList) // Метод для вывода всех абонентов
    //     {
    //         
    //     }
    //     public void AddAbonent(List<Abonent> AbonentsList) // Метод для добавления абонентов
    //     {
    //         .Add();
    //     }
    //     public void DeleteAbonent(List<Abonent> AbonentsList) // Метод для удаления абонентов
    //     {
    //         .Remove();
    //     }
    // }


    // public Abonent SearchAbonent(string name)
    // {
    //     return ;
    // }


    //Human


    //TODO put variables here, do not copy awake method. Use 1 awake method
    //TODO Uncomment all methods and classes
    //TODO use /// before each method or class and put task description there
    //TODO correct method name everywhere. Name rule - What will it do "The method will ..." ?
    //TODO all public field starts with Capital letter



    public void Awake()
    {
        // 1
        var coneVolume = CalculateConeVolume(radius, height);
        Debug.Log(coneVolume);

        // 2, Option 1
        int[] array2 = InvertArray(array); //TODO return an array, use proper naming
        Debug.Log(string.Join(", ", array2));

        // 2, Option 2
        InvertArray2(array);
        Debug.Log(string.Join(", ", array));

        // 4
        // WeighingApples();     //TODO Remove arguments initialization outside of the method
        // foreach (var apple in )
        // {
        //     Debug.Log();
        // }
        // 5
        int vowels = NumberVowelsStrings(text);
        Debug.Log(vowels);

        // 6

        Human human = new Human(35);
        human.Weight = 100f;



    }



    /// <summary>
    /// 1) Написать метод для подсчета объёма конуса. Аргументы - радиус и высота. Возвращает посчитанный объём.
    /// </summary>
    public float CalculateConeVolume(float radius, float height)
    {
        return 3f / 4f * 3.1415f * (radius * radius) * height;
    }


    /// <summary>
    /// 2) Написать метод, который принимает аргументом массив чисел и возвращает “перевернутый массив”, +++
    /// то есть массив такого же размера, но с числами в обратном порядке.
    /// </summary>   

    // Option 1:
    public int[] InvertArray(int[] Array) // TODO Use proper naming  
    {
        int[] Array2 = new int[Array.Length];
        for (int i = 0; i < Array.Length; i++)
        {
            Array2[i] = Array[Array.Length - 1 - i];
        }

        return Array2;
    }

    // Option 2:  -MK +++
    public void InvertArray2(int[] Array)
    {
        for (int i = 0; i < Array.Length / 2; i++)
        {
            int value = Array[i];
            Array[i] = Array[Array.Length - 1 - i];
            Array[Array.Length - 1 - i] = value;
        }
    }


    /// <summary>
    /// 3) Написать метод для обработки списка оценок. Оценки получаем в американском стиле - A,B,C,D,E, для каждой оценки вывести в консоль ее аналог цифрой: A =5, B = 4 и т.д.
    /// </summary>      
    public void RatingOutput(List<char> GradesList)
    {
        GradesClass gradesClass = new GradesClass();
    }


    /// <summary>
    /// 4) Есть List, в котором хранятся яблоки, у каждого яблока свой вес.
    /// В начале кода просто добавить в лист 10 яблок с разным весом.
    /// Потом нужно найти в этом листе яблоки, у которых вес < 100 грамм
    /// и выкинуть их из листа.
    /// </summary>      
    public void WeighingApples(List<Apple> ApplesList)
    {
        for (int i = ApplesList.Count - 1; i >= 0; i--)
        {
            if (ApplesList[i].Weight < 100)
            {
                ApplesList.Remove(ApplesList[i]);
            }
        }
    }


    /// <summary>
    /// 5) Написать метод, который принимает аргументом строку и возвращает количество гласных в ней 
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
    /// </summary>
    public void NewAbonent(Abonent abonent)
    {
        Abonent abonent1 = new Abonent("Jerry", "Jersy", 45687999);
        Abonent abonent2 = new Abonent("Tom", "Scott", 3527877);
        Abonent abonent3 = new Abonent("Mary", "Petty", 9653875);
        
    }
}


