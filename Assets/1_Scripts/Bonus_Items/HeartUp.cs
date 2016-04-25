using UnityEngine;
using System.Collections;

public class HeartUp : MonoBehaviour
{


    //const string NAME_CLASS = "HeartItems";
    const string NAME_CLASS = "CoinItems";

    void Start()
    {
        //poolr = GameObject.FindGameObjectWithTag("Pool").GetComponent<PoolR>();        
    }


    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.gameObject.CompareTag( "Player" ) )
        {

            // var heart = PoolReference.items_D[NAME_CLASS] as HeartItems;
            var coin = PoolReference.items_D[NAME_CLASS] as CoinItems;
            coin.AddHeart();

            Destroy( gameObject );
        }

    }

    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.CompareTag( "Player" ) )
        {

            // var heart = PoolReference.items_D[NAME_CLASS] as HeartItems;
            var coin = PoolReference.items_D[NAME_CLASS] as CoinItems;
            coin.AddHeart();

            Destroy( this.gameObject );
        }
    }
}
