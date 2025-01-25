using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest1
{
    private static SingletonTest1 instance = null;
    private static object lockObj = new object();
    public static SingletonTest1 _Instance
    {
        get
        {
            if (instance==null)
            {
                lock(lockObj)
                {
                    if (instance==null)
                    {
                        instance = new SingletonTest1();
                    }
                }
            }
            return instance;
        }
    }

    private SingletonTest1()
    {
        Debug.Log("SingletonTest1¹¹Ôìº¯Êý");
    }
}
