using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsCS : MonoBehaviour
{
    // while - блок кода выполняется пока достигнет указанного условия
    // цикл проходит по блоку кода, пока указанное условие True
    private void Loop1()
    {
        int i = 0;
        
        while (i < 5)
        {
            Debug.Log(i);
            i++;
        }
    }

    private void Loop2()
    {
    // do/while - выполнит блок кода один раз,прежде чем проверять, истинно ли условие,
    // а затем цикл будет повторяться до тех пор, пока условие истинно
        int j = 0;
        
        do
        {
            Debug.Log(j);
            j++;
        } 
        while (j < 5);
    }
    
    private void Loop3()
    {
        // for - используется, когда известно, сколько раз нужно пройти блок кода
        string[] bicycles = {"Specialized", "Scott", "Santa Cruz", "Canyon"};
        for (int i = 0; i < bicycles.Length; i++)
        {
            Debug.Log(bicycles[i]);
        }
    }
    
    private void Loop4()
    {
        // foreach - используется исключительно для перебора элементов массива
        // foreach метод проще писать
        // не требует счетчика (с использованием Length свойства) 
        // он более читабелен
        string[] bicycles = {"Specialized", "Scott", "Santa Cruz", "Canyon"};
        foreach (string i in bicycles)
        {
            Debug.Log(i);
        }
    }
}
