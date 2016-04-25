using UnityEngine;
using System.Collections;
using System;

public class ChestOpen : MonoBehaviour
{
    public GameObject bonus;
    public int countBonus = 5;
    public float forceUp = 1;
    //public bool isEmpty;



    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.tag == "Player" )//&& !isEmpty )
        {
            SpawnBonus();
            //isEmpty = true;
            
        }
    }

    private void SpawnBonus()
    {

        StartCoroutine( "DelayBonus");
        
    }
    IEnumerator DelayBonus()
    {
        for( var i = 0; i < countBonus; i++ )
        {
            GameObject go = (GameObject)Instantiate( bonus, this.transform.position + new Vector3(0,3), Quaternion.identity );
            Rigidbody2D rBonus = go.GetComponent<Rigidbody2D>();
            rBonus.AddForce( new Vector2( 0, forceUp * 1000f ) );
            yield return new WaitForSeconds(0.5f);
        }
        Destroy( this.gameObject );
    }
}
