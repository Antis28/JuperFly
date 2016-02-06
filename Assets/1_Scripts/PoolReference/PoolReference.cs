using UnityEngine;
using System.Collections;
using System;

public static  class PoolReference
{
    //public static Hashtable TableScene = new Hashtable(1);
    public static System.Collections.Generic.Dictionary<string, GameObject> TableScene = new System.Collections.Generic.Dictionary<string, GameObject>(1);

    public static System.Collections.Generic.Dictionary<string, Items> items_D;

    


    public static void showPool()
    {
        ICollection keys = TableScene.Keys;       
        int i = 0;
        MonoBehaviour.print("TableScene - TableScene содержит " + TableScene.Count + "  элементов");
        foreach (string key in keys)
        {
            i++;            
            MonoBehaviour.print("Ключ   №" + i + " - " + key + "\n" +
                                "Элемнт №" + i + " - " + TableScene[key]
                                );
            
        }


    }

}
