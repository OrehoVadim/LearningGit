using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LearningScripts
{
    public class Dictionary : MonoBehaviour
    {
        // Написать метод для обработки списка оценок.
        // Оценки получаем в американском стиле - A,B,C,D,E, 
        // для каждой оценки вывести в консоль ее аналог цифрой: A =5, B = 4 и т.д.

        // Входные данные:
        // 1-9 ключи-номера студентов (key)
        // Буква ~ Значение (value)
        // Словарь с данными для сравнения (константные данные)
        // Словарь для ввода оценок (dictionary)
        // Мелод для заполнения словаря
        // Метод для обработки словаря с последующим выводом результатов обработки
        // Алгоритм: добавить, обработать и вывести данные
        // Результат: в консоле цифровой аналог оценки

        public void Awake()
        {
            GradesDictionary gradesDictionary = new GradesDictionary();

            gradesDictionary.AddGrade("First", 'A');
            gradesDictionary.AddGrade("Second", 'D');
            gradesDictionary.AddGrade("Third", 'A');
            gradesDictionary.AddGrade("Fourth", 'B');
            gradesDictionary.AddGrade("Fifth", 'j');
            gradesDictionary.AddGrade("Sixth", 'C');
            gradesDictionary.AddGrade("Seventh", 'E');
            gradesDictionary.AddGrade("Eighth", 'A');
            gradesDictionary.AddGrade("Ninth", 'D');
            gradesDictionary.AddGrade("Tenth", 'D');

            gradesDictionary.ProcessingAndOutputGrades();
            gradesDictionary.DataEntryVerification();

            // gradesDictionary.AddGrade('10', 'C'); ???

            // gradesDictionary.AddGrade('A');
            // gradesDictionary.AddGrade('D');
            // gradesDictionary.AddGrade('A');
            // gradesDictionary.AddGrade('B');
            // gradesDictionary.AddGrade('j');
            // gradesDictionary.AddGrade('C');
            // gradesDictionary.AddGrade('E');
            // gradesDictionary.AddGrade('E');
            // gradesDictionary.AddGrade('E');
            // gradesDictionary.AddGrade('5');

            LearningDictionary learningDictionary = new LearningDictionary();
            learningDictionary.Dict[3] = "Three";
            learningDictionary.Dict[4] = "Four";
            learningDictionary.Dict[1] = "One";
            learningDictionary.Dict[2] = "Two";
            learningDictionary.Dict[2] = "2";
            learningDictionary.AssigningValues();

            
            PhoneBook phoneBook = new PhoneBook();
            
            phoneBook.AddAbonent("+3(600)2823456", new Contact("Kate", "Jones"));
            phoneBook.PrintAbonent();

            // PhoneBook2 phoneBook2 = new PhoneBook2();
            // phoneBook2.AddAbonent("+1(300)2536223)", "Romeo", "Sanchez");
            // phoneBook.PrintAbonent();  
        }
    }



    public class GradesDictionary
    {
        Dictionary<char, int> GivenValues = new()
        {
            { 'A', 5 },
            { 'B', 4 },
            { 'C', 3 },
            { 'D', 2 },
            { 'E', 1 }
        };

        Dictionary<string, char> ProcessedGrades = new();

        public void AddGrade(string key, char value) // добавление данных в словарь
        {
            ProcessedGrades.Add(key, value); //???
            // AssigningGrades[key] = value;
            // AssigningGrades.Remove("Tenth");
            // AssigningGrades.Clear();
        }

        public void ProcessingAndOutputGrades()
        {
            foreach (char grade in ProcessedGrades.Values)
            {
                if (GivenValues.ContainsKey(grade))
                {
                    Debug.Log($"{grade} = {GivenValues[grade]}");
                }
                else
                {
                    Debug.Log($"Grade {grade} not found");
                }
            }
        }

        public void DataEntryVerification()
        {
            foreach (KeyValuePair<string, char> pair in ProcessedGrades)
            {
                // Debug.Log($"{pair.Key} - {pair.Value}");

                if (!GivenValues.ContainsKey(pair.Value))
                {
                    Debug.Log($"The grade letter ( {pair.Value} ) is in the wrong format");
                }
            }
        }
    }

    // private Dictionary<char, int> Assessments = new Dictionary<char,int>();
    //
    // public void AddGrade(char key) // добавление данных в словарь
    // {
    //     Assessments[key] = key;
    // }
    //
    // public void ProcessingAndOutputGrades()
    // {
    //     
    //     foreach (var key in Assessments.Keys)
    //     {
    //         if (GivenValues.ContainsKey(key))
    //         {
    //             Debug.Log($"{key} = {GivenValues[key]}");
    //         }
    //         else
    //         {
    //             Debug.Log($"incorrect rating input - {key}");
    //         }
    //     }
    // }

    // public class GradesDictionary
    // {
    //     public Dictionary<char, int> GivenKeyValues = new()
    //     {
    //         { 'A', 5 },
    //         { 'B', 4 },
    //         { 'C', 3 },
    //         { 'D', 2 },
    //         { 'E', 1 }
    //     };
    //
    //     public Dictionary<char, int> DictionaryWithGrades = new ();
    //     
    //     public void AddGrade(char key) // добавление данных в словарь
    //     {
    //         if (GivenKeyValues.ContainsKey(key))
    //         {
    //             DictionaryWithGrades[key] = GivenKeyValues[key]; 
    //         }
    //         else
    //         {
    //             Debug.Log($"Grade {key} not found");
    //         }
    //     }
    //     
    //     public void DictionaryOutput()
    //     {
    //         foreach (var key in DictionaryWithGrades)
    //         {
    //             Debug.Log(key.Key + " = " + key.Value);
    //         }
    //     }
    //
    //     public void Assessment(List<char> ratings)
    //     {
    //         foreach (var letter in ratings)
    //         {
    //             var dictionaryWithGrade = DictionaryWithGrades[letter];
    //             Debug.Log(dictionaryWithGrade);
    //         }
    //     }
    //     
    //     public void Test()
    //     {
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
    // }
    // }

    public class LearningDictionary
    {
        public Dictionary<int, string> Dict = new();

        public void AssigningValues()
        {
            foreach (var data in Dict)
            {
                Debug.Log($"{data.Key} = {data.Value}");
            }

            foreach (var data in Dict)
            {
                Debug.Log(data);
            }
        }
    }

    public class Contact 
    {
        public string FirstName { get; set; } // свойство для хранения имени контакта
        public string LastName { get; set; } // get - получение значения свойства, set - установка

        public Contact(string firstName, string lastName) // Конструктор для установки имени и фамилии контакта

        {
            FirstName = firstName; // инициализация объекта contact при его создании
            LastName = lastName;
        }
        
        public override string ToString() // переопределение метода ToString() из базового класса Object
        {
            return $"{FirstName}, {LastName}"; // при вызове ToString() для объекта класса Contact возвращается строка с именем и фамилией контакта
        }
    }

    public class PhoneBook
    {
        public Dictionary<string, Contact> PhoneBookDictionary = new Dictionary<string, Contact>(); // Словарь для хранения контактов, ключом является номер телефона, значением - объект класса Contact

        public void AddAbonent(string phoneNumber, Contact contact)
        {
            PhoneBookDictionary.Add(phoneNumber, contact); 
        }
        
        public void PrintAbonent()
        {
            foreach (var abonents in PhoneBookDictionary)
            {
                Debug.Log(abonents);
            }
        }
    }


    // public class PhoneBook2 : Dictionary<string, Contact> // PhoneBook2 наследуется от Dictionary
    // {
        // public void AddAbonent(string phoneNumber, string fName, string lName) // новая перегрузка метода Add
        // {
            // this[phoneNumber] = new Contact()
            // {
                // FirstName = fName,
                // LastName = lName
            // };
        // }
    // }
    
}