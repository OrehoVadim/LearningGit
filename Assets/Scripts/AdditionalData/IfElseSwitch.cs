using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfElseSwitch : MonoBehaviour
{
    // switch - оператор для выбора одного из множества блоков кода для выполнения
    // выражение switch вычисляется один раз
    // знаначение выражения сравнивается со значениями каждого case
    // ghb совпадениях выполняется соответствующий блок кода 
    public void Statements()
    {
        int day = 7;
        switch (day)
        {
            case 1:
                Debug.Log("Monday");
                break;
            case 2:
                Debug.Log("Tuesday");
                break;
            case 3:
                Debug.Log("Wednesday");
                break;
            case 4:
                Debug.Log("Thursday");
                break;
            case 5:
                Debug.Log("Friday");
                break;
            case 6:
                Debug.Log("Saturday");
                break;
            case 7:
                Debug.Log("Sunday");
                break;
        }
    }
}
