using UnityEngine;
using System.Collections;

public class Chekpoint : MonoBehaviour {

//	private PoolR poolr;

	public RectTransform RT;
	// Use this for initialization

	void Start()
	{
		//poolr = GameObject.Find ("PoolReference").GetComponent<PoolR>();


	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player") )
		{
//			Debug.Log("Save Position");
			RT = other.gameObject.GetComponentInChildren<RectTransform>();
			SaveStats savePosition = new SaveStats();
			savePosition.SaveStatistik(RT.position);
			if(gameObject.GetComponent<SpawnManeger>())
			gameObject.GetComponent<SpawnManeger>().enabled = true;
			if(gameObject.GetComponent<SpawnManeger1>())
				gameObject.GetComponent<SpawnManeger1>().enabled = true;
		}

	}
}
