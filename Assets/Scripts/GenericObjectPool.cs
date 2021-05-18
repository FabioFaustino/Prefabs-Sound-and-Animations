using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> : MonoBehaviour where T : Component
{

    [SerializeField]
    private T prefab;

    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if (objects.Count == 0)
            AddObjects(1);
        return objects.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
    private void AddObjects(int v)
    {
        var newObject = GameObject.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
