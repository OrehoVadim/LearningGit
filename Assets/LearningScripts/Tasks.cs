using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    private void Awake() // 1) Unity вызвал метод Awake, при загрузке в сцену объекта со скриптом
    { // 2) первым выполниться метод Awake()
        ApplesWeight(); // 3) вызывается метод для подсчета веса яблок
    } // 4) завершение выполнения метода Awake()

    public class Apples // 5) определение публичного класса Apples, представляющий структуру объекта яблока
    {
        public int Weight; // 6) переменная представляющая вес яблока
    } // 7) определение публичного класса Apples, представляющий структуру объекта яблока

    public void ApplesWeight() // 8) начало выполнения метода для подсчета веса яблок
    { 

        List<Apples> apples = new List<Apples>();      // 9) создается новый список, который будет содержать (хранить) объекты класса Apples
                                                       // кампилятов видит определение класса Apples и использует его для создания списка
                                                    
                                                       // 10) Добавление объектов Apples с разным весом в список apples
        apples.Add(new Apples { Weight = 85 });
        apples.Add(new Apples { Weight = 100 });
        apples.Add(new Apples { Weight = 130 });
        apples.Add(new Apples { Weight = 70 });
        apples.Add(new Apples { Weight = 65 });
        apples.Add(new Apples { Weight = 180 });
        apples.Add(new Apples { Weight = 125 });
        apples.Add(new Apples { Weight = 195 });
        apples.Add(new Apples { Weight = 75 });
        apples.Add(new Apples { Weight = 70 });

        // 10) цыкл с итерации по элементам списка apples с конца к началу
        for (int i = apples.Count - 1; i >= 0; i--) // определение переменной i;
                                                    // условие цыкла - пока значение переменной i больше или равно 0
                                                    // после каждой итерации i уменьшается на 1 - перемещения по элементам списка в обратном порядке.
        {
            if (apples[i].Weight < 100) // 11) Удаление яблок с весом менее 100 из списка apples
            {
                apples.Remove(apples[i]);
            }
        } // 12) конец цыкла удаления яблок

        // 13) цыкл для вывода веса оставшихся яблок 
        for (int i = 0; i < apples.Count; i++)
        {
            Debug.Log(apples[i].Weight); // 14) Вывод веса яблок в консоль Unity
        } // 15) конец цыкла удаления яблок
        
    } // 16. Завершение выполнения метода ApplesWeight()
}
