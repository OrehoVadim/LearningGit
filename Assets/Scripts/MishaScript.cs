using System;
using System.Collections.Generic;
using UnityEngine;

public class MishaScript : MonoBehaviour
{
    private void Awake()
    {
        Test();
    }

    public void Test()
    {
        List<int> array = new List<int> { 1, 2, 3};

        if (array[0] < 100)
        {
            array.Remove(array[0]);
        }
        
        if (array[1] < 100)
        {
            array.Remove(array[1]);
        }
        
        if (array[2] < 100)
        {
            array.Remove(array[2]);
        }

        var i = 0;
        while (i < 3)
        {
            if (array[i] < 100)
            {
                array.Remove(array[i]);
            }

            i++;
        }

        for (i = 0; i < 3; i++)
        {
            if (array[i] < 100)
            {
                array.Remove(array[i]);
            }
        }
    }
}
