using System.Collections.Generic;
using UnityEngine;

namespace LearningScripts
{
    public class GradesDictionary
    {
        public Dictionary<char, char> DictionaryWithGrades = new Dictionary<char, char>()
        {
            { 'A', '5' },
            { 'B', '4' },
            { 'C', '3' },
            { 'D', '2' },
            { 'E', '1' }
        };
        
        public void DictionaryOutput()
        {
            foreach (var variable in DictionaryWithGrades)
            {
                    Debug.Log(variable.Key + " = " + variable.Value);
            }
        }
        
        public void AddGrades(char key, char value)
        {
            DictionaryWithGrades[key] = value;
        }
    }
}