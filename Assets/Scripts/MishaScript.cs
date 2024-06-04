// using System;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
//
// public class Game : MonoBehaviour
// {
//     [SerializeField] private Enemy _enemyPrefab;
//     
//     private float time = 0.0f;
//     public float interpolationPeriod = 3;
//
//     public void Update () 
//     {
//         time += Time.deltaTime;
//
//         if (time >= interpolationPeriod) 
//         {
//             time = 0;
//             Instantiate(_enemyPrefab);
//             // execute block of code here
//         }
//     }
// }
//
// public class Player
// {
//     public int Damage;
//     
//     // public void Shoot(Enemy enemy)
//     // {
//     //     enemy.GetDamage(Damage);
//     // }
// }
//
// public partial class Enemy : MonoBehaviour
// {
//     public Vector3 InitialPosition;
//     public float Speed;
//     
//     public int HP { get; protected set; }
//     public int Armor;
//     public float ChanceToEvade;
//
//     public void Update()
//     {
//         transform.Translate(Vector3.forward * Time.deltaTime * Speed);
//     }
//
//     public void GetDamage(int damage)
//     {
//         if (ChanceToEvade <= 0)
//         {
//             if (Random.Range(1,100) > ChanceToEvade)
//             {
//                 return;
//             }
//         }
//         
//         if (Armor > 0)
//         {
//             damage =- Armor;
//         }
//         
//         HP =- damage;
//     }
// }
//
//
// public class MishaScript : MonoBehaviour
// {
// //     int apple1 = 100;
// //     int apple2 = 150;
// //     
// //     public int WeightApples(int apple1, int apple2)
// //     {
// //         int result = apple1 + apple2;
// //         return result;
// //     }
// //     
// //     private void Awake()
// //     {
// //         int result = WeightApples(apple1, apple2);
// //         Debug.Log(result);
// //     }
// //     
//     // public void Test()
//     // {
//     //     List<int> array = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
//     //
//     //     if (array[0] < 100)
//     //     {
//     //         array.Remove(array[0]);
//     //     }
//     //
//     //     if (array[1] < 100)
//     //     {
//     //         array.Remove(array[1]);
//     //     }
//     //
//     //     if (array[2] < 100)
//     //     {
//     //         array.Remove(array[2]);
//     //     }
//     //
//     //     var i = 0;
//     //     while (i < array.Count) // 8
//     //     {
//     //         if (array[i] < 100)
//     //         {
//     //             array.Remove(array[i]);
//     //         }
//     //
//     //         i++;
//     //     }
//
//     
//         // array.Count = 8
//         // for (i = 0; i < array.Count; i++)
//         // {
//         //     var item = array[i];
//         //     if (item < 100)
//         //     {
//         //         array.Remove(item);
//         //     }
//         //
//         //     break;
//         // }
//
//         
//         // for (i = 0; i < array.Count; i++)
//         // {
//         //     var item = array[i]
//         // }
//         // foreach (var item in array)
//         // {
//         //     if (item < 100)
//         //     {
//         //         array.Remove(item);
//         //     }
//         // }
//     
// }
//
