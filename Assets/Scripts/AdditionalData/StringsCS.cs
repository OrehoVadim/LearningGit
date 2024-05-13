using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StringsCS : MonoBehaviour
{
    public void Strings()
    {
        string brandName = "Santa Cruz";
        Debug.Log(brandName.ToUpper());
        Debug.Log(brandName.ToLower());
        Debug.Log(brandName.Length);
        Debug.Log(brandName[3]);
        Debug.Log(brandName.IndexOf("z"));
    }

    // Конкатенация - объединение строк оператором "+"
    public void ConStrings ()
    {
        string firstName = "Santa ";
        string lastName = "Cruz";
        //string name = firstName + lastName;
        string name = string.Concat(firstName, lastName);
        Debug.Log(name);
    }

    // Интерполяция - объединение строк, конкатенации
    // значения переменных заменяются заполнителями в строке
    // не нужно беспокоиться о пробелах, как при конкатенации
    // необходимо использовать знак доллара "$"
    public void IntStrings()
    {
        string firstName = "Santa";
        string lastName = "Cruz";
        string name = $"Brand name is: {firstName} {lastName}";
        Debug.Log(name);
    }
}
