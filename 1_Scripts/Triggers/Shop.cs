using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour {

	public Text shopText;
	private GameObject shopTextGO;
	private Canvas TaskCanvas;
	private Canvas GameCanvas;
	public SimplePlatformContoroler simplePC;
	private bool isActive = false;
	private PoolR poolr;

	void Start()
	{
		poolr = GameObject.Find("PoolReference").GetComponent<PoolR>();
		simplePC		= poolr.simplePlatformContoroler;
		GameCanvas		= poolr.GameCanvas;
		TaskCanvas		= poolr.TaskCanvas;
		shopTextGO = poolr.ShopText.gameObject;
		shopTextGO.SetActive (false); 


	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			shopTextGO.SetActive (true); 
			poolr.ShopText.text = "Enter to shop \n Press key \" Enter \"";
			if(Input.GetKeyDown(KeyCode.Return))
			{
				simplePC.enabled = false;
				GameCanvas.gameObject.SetActive (isActive);
				TaskCanvas.gameObject.SetActive (!isActive);
//				Debug.Log ("if(Input.GetKey(KeyCode.E))");
			}
		}

	}
	void OnTriggerExit2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Player"))
		{
			shopTextGO.SetActive (false);
		}
	}

}
