using System.Collections.Generic;
using UnityEngine;

namespace LearningScripts
{
    public class AddressBook
    {
        public List<Abonent> AbonentsList = new List<Abonent>();
        
        /// <summary>
        /// 6) Создать логику Адресной Книги 
        /// Входные данные: список с именем, фамилией и номером телефона
        /// Алгоритм: создать логику Адресной Книги
        /// Результат: добавление новых абонентов, удаление абонентов, поиск абонента по имени, вывод информации о всех абонентах в книге
        /// </summary>
        
        public void AddAbonents(string name, string surname, string phoneNumber)
        {
            AbonentsList.Add(new Abonent(name, surname, phoneNumber));
        }
        
        public void DeleteAbonents(string name, string surname, string phoneNumber)
        {
            for (int i = AbonentsList.Count -1; i >= 0 ; i--)
            {
                Abonent abonent = AbonentsList[i];
                if (abonent.Name == name && abonent.Surname == surname && abonent.PhoneNumber == phoneNumber)
                {
                    AbonentsList.Remove(abonent);
                }
            }
        }

        public void SeachAbonents(string name)
        {
            for (int i = 0; i < AbonentsList.Count; i++)
            {
                Abonent abonent = AbonentsList[i];
                if (abonent.Name == name)
                    Debug.Log(abonent.Name + abonent.Surname + abonent.PhoneNumber);
            }
        }
        
        public void PrintAbonents()
        {
            foreach (var abonents in AbonentsList)
            {
                Debug.Log($"{abonents.Name} {abonents.Surname}, {abonents.PhoneNumber}");
            }
        }
    }
    
    public class Abonent
    {
        public string Name; // поле (переменная) будет хранить имя абонента
        public string Surname;
        public string PhoneNumber;


        public Abonent(string name, string surname, string phoneNumber) // Конструктор инициализирует объект, принимает три параметра, использует параметры для установки значений полей 
        {
            Name = name; // строка устанавливает значение поля Name
            Surname = surname;
            PhoneNumber = phoneNumber;
        }
        // public string AccessToName // Свойство для доступа к приватному имени
        // {
        //     get { return Name; }
        //     set { Name = value; }
        // }
    }
}