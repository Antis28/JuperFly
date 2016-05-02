using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{   
    public GameObject hero;   
    bool isSave = true;

    void OnTriggerEnter2D( Collider2D other )
    {

        if( other.gameObject.CompareTag( "Player" ) )//|| other.name == "hero"
        {
            if( isSave )
            {
                PoolReference.TableScene[EnumInPool.InputManeger.ToString()].GetComponent<InputManeger>().SaveStatus();                
                Application.LoadLevel( Application.loadedLevel );
            }
        }
        if( other.gameObject.CompareTag( "Ground" ) )
        {
            GameObject.Destroy( other.gameObject );
        }

    }
   
}
