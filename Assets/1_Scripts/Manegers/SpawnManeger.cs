using UnityEngine;
using System.Collections;

public class SpawnManeger : MonoBehaviour {

	public int maxPlatforms = 20;
	public GameObject platformLow;
	public GameObject platformMed;
	public GameObject platformHigh;
	public GameObject chekpoint;
	public float horizontalMin = 6.5f;
	public float horizontalMax = 14f;
	public float verticalMin = -6f;
	public float verticalMax = 6f;

	private Vector2 OriginPosition;

	// Use this for initialization
	void Start () {
		OriginPosition = transform.position;
		StartCoroutine(SpawnCoroutine());
	}
	
	// Update is called once per frame
	IEnumerator SpawnCoroutine()
	{
		for(int i = 0; i < maxPlatforms; i++)
		{
			float rx = Random.Range(horizontalMin,horizontalMax);
			float ry = Random.Range(verticalMin,verticalMax);
			Vector2 randomPosition = OriginPosition + new Vector2(rx, ry);                                               
																 
			//platform = Random.Range()
			//Debug.Log("x = " + Mathf.Abs(rx));
			//Debug.Log("y = " + Mathf.Abs(ry));
			//Debug.Log("=======================");
			if(i < maxPlatforms - 1){
				if( Mathf.Abs(ry) > 5f || rx > 13f)
					Instantiate(platformHigh, randomPosition, Quaternion.identity);
				else if( Mathf.Abs(ry) > 3f || rx > 10f)
					Instantiate(platformMed, randomPosition, Quaternion.identity);
				else 
					Instantiate(platformLow, randomPosition, Quaternion.identity);
			}
			else
				Instantiate(chekpoint, randomPosition, Quaternion.identity);

			OriginPosition = randomPosition;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
