using UnityEngine;
using System.Collections;

public class CoinsSpawn : MonoBehaviour {

	public Transform[] coinSpawns;
    public int[] num;
	public GameObject coin;

	// Use this for initialization
	void Start () 
	{
		Spawn ();
	}
	void Spawn()
	{
        num = new int[coinSpawns.Length];
        for (int i = 0; i < coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            num[i] = coinFlip;
            if (coinFlip != 0 & coin != null)
            {
                
                var go = Instantiate(coin, coinSpawns[i].position, Quaternion.identity) as GameObject;
                go.transform.parent = coinSpawns[i].transform;

            }
		}
	}

}
