using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInit : MonoBehaviour
{
    public string cubeName;
    public Sphere sphere;
    
    /// <Awake>
    /// для инициализации переменных или состояния игры перед тем как игра будет загружена
    /// вызывается только один раз за все время жизни скрипта
    /// вызывается после инициализации всех объектов
    /// вызывается для всех объектов в сцене до вызова функции Start любого объекта
    /// </Awake>
    void Awake()
    {
        Debug.Log("Awake cube");
    }
    
    
    
    /// <OnEnable>
    /// вызывается, когда объект становится включенным и активным
    /// будет выполняться при каждом входе в режим воспроизведения (с включенным объектом)
    /// </OnEnable>
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    
    
    /// <Start>
    /// вызывается в кадре, когда скрипт включается перед первым вызовом любого из методов Update
    /// вызывается только один раз за все время жизни скрипта
    /// не может быть вызван в том же кадре, что и Awake, если скрипт не включен во время инициализации
    /// </Start>
    void Start()
    {
        Debug.Log("Start");
        cubeName = sphere.sphereName;
    }
    

    /// <Update>
    /// вызывается каждый кадр, если MonoBehaviour включен
    /// использовать Time.deltaTime
    /// </Update>
    void Update()
    {
        Debug.Log("Update");
    }
    
    
    /// <OnDisable>
    /// вызывается, когда behaviour становится отключенным-disabled
    /// вызывается, когда объект уничтожается
    /// может использоваться для любого кода очистки
    /// Когда сценарии перезагружаются после завершения компиляции, будет вызван OnDisable, а затем OnEnable после загрузки сценария
    /// </OnDisable>
    void OnDisable()
    {
        Debug.Log("OnDisable");
    }
}
