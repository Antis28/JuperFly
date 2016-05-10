using UnityEngine;
using System.Collections;
using System;

public class AddToPool : MonoBehaviour {

    //PoolReference pool;   
	// Use this for initialization
	void Awake () {

        try
        {
            PoolReference.TableScene.Add( name.ToString(), gameObject );
        } catch( NullReferenceException )
        {
            print( "Нет ссылки на объект " );
        } catch
        {
            print( "Такой ключ уже существует: "  + this.name);
        }
    }
}
