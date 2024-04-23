using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MishaScript : MonoBehaviour
{
    private void Awake()
    {

        // Test();
        
        float radius = 10;
        float height = 20;
        float result = CalculateConeVolume(radius, height);
        Debug.Log(result);
    }
    
    public float CalculateConeVolume(float radius, float height)
    {
        return (1f / 3f) * 3.1415f * (radius * radius) * height;
    }
    


    // public void Test()
    // {
    //     List<int> array = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
    //
    //     if (array[0] < 100)
    //     {
    //         array.Remove(array[0]);
    //     }
    //
    //     if (array[1] < 100)
    //     {
    //         array.Remove(array[1]);
    //     }
    //
    //     if (array[2] < 100)
    //     {
    //         array.Remove(array[2]);
    //     }
    //
    //     var i = 0;
    //     while (i < array.Count) // 8
    //     {
    //         if (array[i] < 100)
    //         {
    //             array.Remove(array[i]);
    //         }
    //
    //         i++;
    //     }

        // array.Count = 8
        // for (i = 0; i < array.Count; i++)
        // {
        //     var item = array[i];
        //     if (item < 100)
        //     {
        //         array.Remove(item);
        //     }
        //
        //     break;
        // }

        // for (i = 0; i < array.Count; i++)
        // {
        //     var item = array[i]
        // }
        // foreach (var item in array)
        // {
        //     if (item < 100)
        //     {
        //         array.Remove(item);
        //     }
        // }
    
}

