using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ArrayCS : MonoBehaviour
{
    public Text text;

    public void Button()
    {
        // Массивы-Arrays - для хранения нескольких значений в одной переменной
        int[] elements = { 30, 5, 1, 42, 85, 75, 45, 72, 28, 32 };
        
        // int[,] elements2 = { { 30, 5, 1, 42, 85, 75, 45, 72, 28, 32 }, {30, 5, 1, 42, 85, 75, 45, 72, 28, 32 }};
        
        {
            text.text = Convert.ToString(elements.Max());
        }
    }
}



//...[1][2][3][4][5][6][7][8]...

// public int[] Arr; // null
// public int i; // 0

// public void ChangeName(Array human)
// {
//     Arr = new int[5]; // ...[1][2][3][4][5]...
//     Arr[0] = 1;
//     Arr[1] = 2;
//     Arr[2] = 3;
//     Arr[3] = 4;
//     Arr[4] = 5;
//
//     Arr = new[] { 1, 2, 3, 4, 5 };
//
//     var i = Arr[2]; //3
//     // human.Name = "new name";
//     
//     
// }