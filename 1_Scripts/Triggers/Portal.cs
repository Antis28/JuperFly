using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public Vector3 vec3 = new Vector3 (211f, 87f, 0f); 

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag ("Player") || other.name == "hero") 
		{
			other.gameObject.GetComponent<RectTransform>().position = vec3;
		}
	}
}
