using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    public Text text;


    public void Button()
    {
        
        
        //     text.text = "I love C#";
        // }
        //  */

        
//if/else
    // {
    //     int drivingIsAllowed = 18;
    //     int driverAge = 19;
    //
    //     if (driverAge == drivingIsAllowed)
    //     {
    //         text.text = "You can driving";
    //     }
    //     else if (driverAge > 18)
    //     {
    //         text.text = "You have been able to drive\nfor a long time";
    //     }
    //
    //     else
    //     {
    //         text.text = "You can not driving!\nDriving a car is allowed from the age of 18";
    //     }
    // }


        // {
        //     for (var driverAge = 0; driverAge < 18; driverAge ++)
        //     {
        //         if (driverAge == 16)
        //         {
        //             continue;
        //         }
        //         text.text = Convert.ToString(driverAge);
        //     }
        // }
        

            // var driverAge = 0;
            // while (driverAge < 19)
            // {
            //     text.text = Convert.ToString(driverAge);
            //     driverAge++;
            //     if (driverAge == 4)
            //     {
            //         break;
            //     }
            // }

            // string[] bicycles = {"Specialized","Scott","Canyon","Santa Cruz"};
            
            // for (var i = 0; i < bicycles.Length; i++) 
            // Array.Sort(bicycles);
            // foreach (var i in bicycles)
            
            string[,] bicycles = { {"Specialized","Scott","Canyon"}, {"Cannondale","Cube","Santa Cruz"} };
            {
                text.text = Convert.ToString(bicycles[0, 0]);
            }


    }
}