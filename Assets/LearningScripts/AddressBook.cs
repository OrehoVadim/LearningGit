using System.Collections.Generic;

namespace LearningScripts
{
    public class AddressBook
    {
        public List<Abonent> AbonentsList = new List<Abonent>();
        
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
            // public string AccessToSurname // Свойство для доступа к приватному имени
            // {
            //     get { return Surname; }
            //     set { Surname = value; }
            // }
            // public int AccessToPhoneNumber // Свойство для доступа к приватному имени
            // {
            //     get { return PhoneNumber; }
            //     set { PhoneNumber = value; }
            // }
        }
    }
}