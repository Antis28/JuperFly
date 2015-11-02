using UnityEngine;
using System.Collections;

public class CoinUp : MonoBehaviour {

    const string NAME_CLASS = "CoinItems";


    void Start()
	{

    }
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
            var coin = PoolReference.items_D[NAME_CLASS] as CoinItems;            

            if (coin != null)            
                coin.AddItem();
            else
                print("coin == null!!!!!!!!!!!!");

            Destroy(gameObject);
		}
        

	}
    
}


