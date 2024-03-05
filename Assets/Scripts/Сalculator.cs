using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text Output;
    public string calculator1;
    public string x1;

    public void Button_Click()
    {
        Output.text += calculator1;
    }

    public void Button_Click_Delete()
    {
        Output.text = "";
    }

    public void Button_Click_Equals()
    {
        var dt = new DataTable();
        x1 = (dt.Compute(Output.text, " ")).ToString();
        Output.text = x1;
    }
    
    public class Quit : MonoBehaviour
    {
        public void ExitCalculator()
        {
            Application.Quit();
        }
    }
}