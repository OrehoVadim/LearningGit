using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Memory
// Stack and Heap
// Стек — это область памяти, которая используется для хранения локальных переменных
// Куча — это область памяти, которая используется для хранения объектов
public class ValRolType : MonoBehaviour
{
    public class Human
    {
        public int hp;
    }

    public void Man()
    {
        Human human = new Human();
        human.hp = 10;
        Human human2 = human;
        // human2.hp = 10, human.hp = 10

        human2.hp = 20;
        // human2.hp = 20, human.hp = 20
        // [][][][][][][][object list {1,2,3}][][object human][][], human ---> first byte of [object human]

        int i = 10;
        int i1 = i;
        i += 1;
        // i = 11, i1 = 10

        List<int> _list = new List<int> { 1, 2, 3 };

        Test(i, human, _list);

        // i = 11
        // human2.hp = 30; human.hp = 30
        // _list = {123};
    }

    public void Test(int i, Human human, List<int> list)
    {
        i++;
        human.hp = 30;
        human = new Human();
        //list.Remove(1);
        list = new List<int> { 4, 5 };
    }


    public interface ICreature
    {
        public int Legs { get; set; }

        public void Method()
        {
        }

        public class Creature : Human
        {
            public int Legs1 { get; set; }

            public void Method()
            {
            }
        }

        public class Centipede : Creature
        {
            public int Legs2 { get; set; }
        }
    }
}