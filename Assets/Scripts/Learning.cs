using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learning : MonoBehaviour
{
    public Text text;
    
    /*
    public void Button()

    {
        text.text = "I love C#";
    }
     */
    
    
    
/*if/else
    public void Button()
    {
        int drivingIsAllowed = 18;
        int driverAge = 19;

        if (driverAge == drivingIsAllowed)
        {
            text.text = "You can driving";
        }
        else if (driverAge > 18)
        {
            text.text = "You have been able to drive\nfor a long time";
        }
        
        else
        {
            text.text = "You can not driving!\nDriving a car is allowed from the age of 18";
        }
    }
*/


    public void Button()
    
    {
        var time = 9;
        var result = time < 18 ? "Good day." : "Good evening.";
        text.text = "I love C#";
    }
    
    
}