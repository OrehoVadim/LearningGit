using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesGetSet : MonoBehaviour
{
    // поля - field
    private string _name;
    private int _number1;
    private int _number2;
    private int _number3;
    
    // свойства - property
    public string Name
    {
        // Метод get возвращает значение переменной
        // ООП set - public
        get
        {
            if (string.IsNullOrEmpty(_name))
            {
                return "Default";
            }

            return null;
        }

        // Метод set присваивает значение переменной
        // ООП set - private
        set
        {
            Debug.Log("Test");
            if (string.IsNullOrEmpty(_name))
            {
                _name = "Default";
            }

            _name = value;
        }
    }

// #1
    public int Number1 { get; set; }
    
// #2
    public int Number2
    {
        get { return _number2; }
        set { _number2 = value; }
    }
    
// #3
    // public int Number3
    // {
    //     get
    //     {
    //         if (int.IsNullOrEmpty(_number3))
    //         {
    //             return "Default";
    //         }
    //         return _number3;
    //     }
    //     
    //     set
    //     {
    //         if (int.IsNullOrEmpty(_number3))
    //         {
    //             _number3 = "Default";
    //         }
    //         _number3 = value;
    //     }
    // }

}
