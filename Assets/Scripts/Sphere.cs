using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public string sphereName;
    void Awake()
    {
        Debug.Log("Awake sphere");
        sphereName = "Vadim";
    }
}
