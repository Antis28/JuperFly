using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestCoroutines : MonoBehaviour {

	public Text TimeTextNum;
	int t;

	void Start()
	{
		StartCoroutine(TestCoroutine());
	}
	
	IEnumerator TestCoroutine()
	{
		while(true)
		{
			t++;
			TimeTextNum.text = t.ToString();
			yield return new WaitForSeconds(1f);;

		}
	}
}
