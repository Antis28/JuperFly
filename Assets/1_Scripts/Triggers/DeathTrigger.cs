using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DeathTrigger : MonoBehaviour
{
    public GameObject hero;
    bool isSave = true;
    public InputManeger IM;

    void Start()
    {
        try
        {
           // IM = PoolReference.TableScene[EnumInPool.InputManeger.ToString()].GetComponent<InputManeger>();
        } catch { print( "!!!!!!!!!! + PoolReference.TableScene[EnumInPool.InputManeger.ToString()].GetComponent<InputManeger>()" ); }
    }

    void OnTriggerEnter2D( Collider2D other )
    {

        if( other.gameObject.CompareTag( "Player" ) )//|| other.name == "hero"
        {
            if( isSave )
            {

                IM.SaveStatus();
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
                
            }
        }
        if( other.gameObject.CompareTag( "Ground" ) )
        {
            GameObject.Destroy( other.gameObject );
        }

    }

}
