using UnityEngine;

namespace LearningScripts
{
    public class FirstProgramming : MonoBehaviour
    {
        private void OutputVariables()
        {
            string name = "Mario";
            int lifes = 3;
            int coins = 0;
            char connector = '&';
            bool hasLives = true;
            
            Debug.Log("Name: " + name);
            Debug.Log("Lifes: " + lifes);
            Debug.Log("Coins: " + coins);
            Debug.Log($"Name: {name} {connector} Lifes: {lifes} {connector} Coins: {coins}");
            
           coins = 50;

            bool itRains = false;
            
            if (itRains == true)
            {
                Debug.Log("Take an umbrella, it's rainy outside");
            }
            
            Debug.Log("Coins: " + coins);
            
        }

        public void Awake()
        {
            OutputVariables();
        }
    }
}