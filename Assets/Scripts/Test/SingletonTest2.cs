using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest2
{
    //private static SingletonTest2 instance = new SingletonTest2();
    //public static SingletonTest2 _Instance { get { return instance; } }

    //private SingletonTest2() { Debug.Log("SingletonTest2���캯��"); }

    private SingletonTest2() { }

    private static readonly SingletonTest2 _instance = new SingletonTest2();

    public static SingletonTest2 Instance
    {
        get { return _instance; }
    }

    public void DoSomething()
    {
        Console.WriteLine("����ʽ����ģʽ.");
    }
}
