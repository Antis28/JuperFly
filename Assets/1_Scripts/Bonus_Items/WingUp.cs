using UnityEngine;
using System.Collections;

public class WingUp : MonoBehaviour
{
    const string NAME_CLASS = "WingsItems";


    void OnTriggerEnter2D( Collider2D other )
    {
        print( "OnTriggerEnter2D" );
        Check( other.gameObject );        
    }

    void OnCollisionEnter2D( Collision2D coll )
    {
        print( "OnCollisionEnter2D" );
        Check( coll.gameObject );        
    }

    void Check(GameObject go)
    {
        print( "000" );
        if( go.CompareTag( "Player" ) )
        {
            print( "1!!!!" );
            var wing = PoolReference.items_D[NAME_CLASS] as WingsItems;
            wing.AddItem();
            Destroy( gameObject );
        }
    }
}
