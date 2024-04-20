using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
public class parent
{
    public int count = 10;
    public static int id = 1;
    public parent()
    {
        id++;
    }
}

public class Child : MonoBehaviour
{
    void Start()
    {
        parent parent = new parent();
        Debug.Log(parent.id); // 2
        parent parent1 = new parent();
        Debug.Log(parent.id); //3
        parent parent2 = new parent();
        Debug.Log(parent.id); // 4
        parent parent3 = new parent();
        Debug.Log(parent.id); // 5
    }

    // Update is called once per frame
    void Update()
    {
        int count = 10;
        Debug.Log("Local Position " + transform.localPosition);
        Debug.Log("World Position " + transform.position);
    }

     int id = 0;
    static void Test()
    {
        
        int id = 0;
    }

}
