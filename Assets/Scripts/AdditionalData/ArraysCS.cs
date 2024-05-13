using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ArrayCS : MonoBehaviour
{
    // ...[1][2][3][4][5][6][7][8]...

    public int[] Arr; // null
    public int i; // 0

    public void ChangeName(Array human)
    {
        Arr = new int[5]; // ...[1][2][3][4][5]...
        Arr[0] = 1;
        Arr[1] = 2;
        Arr[2] = 3;
        Arr[3] = 4;
        Arr[4] = 5;

        Arr = new[] { 1, 2, 3, 4, 5 };

        var i = Arr[2]; //3
    }
    
    public Text text;
    
    public void Button()
    {
        // Массивы-Arrays - для хранения нескольких значений в одной переменной
        int[] elements = {30, 5, 1, 42, 85, 75, 45, 72, 28, 32, 50, 563, 1, 42, 85, 75, 45, 72, 28, 32};
        int max = elements[0];

        // if (elements[0] < elements[1])
        // {
        //     max = elements[1];
        // }
        // else
        // {
        //     max = elements[0];
        // }
        
        for (int j = 1; j < elements.Length; j++)
        {
            if (elements[j] > max)
            {
                max = elements[j];
            }
        }
        
        // int[,] elements2 = {{ 30, 5, 1, 42, 85, 75, 45, 72, 28, 32 }, {30, 5, 1, 42, 85, 75, 45, 72, 28, 32 }};
        
        text.text = max.ToString();
    }
}