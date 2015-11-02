using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Xml;
using System;

public class LoadStats : MonoBehaviour {
			
	public Text coinText;   // количество монет

    public int _amountCoin;   // количество монет
    public int _amountOfWings;     // количество крылышек
   

    private PoolR poolr;
	public int numTask = 1; // Номер задания

    void Start()
	{
		poolr = GameObject.Find("PoolReference").GetComponent<PoolR>();        
		LoadFromFile ();
        
                  
            
    }
	void LoadFromFile () {
		string filePatch = "Data/Save/Stats.xml";	


		XmlDocument xmlDoc = new XmlDocument ();
		if (File.Exists (filePatch)) 
		{
			xmlDoc.Load (filePatch);		

			XmlNode findNode = xmlDoc.SelectSingleNode ("Stats/Coin");
			if(findNode != null)
                //coinText.text = findNode.InnerText;
                _amountCoin = System.Int32.Parse(findNode.InnerText);

            findNode = xmlDoc.SelectSingleNode ("Stats/Fly");
			if(findNode != null )///////////////////////////////////////////////
				_amountOfWings = System.Int32.Parse(findNode.InnerText);

			findNode = xmlDoc.SelectSingleNode ("Stats/NumberTask");
			if(findNode != null)
				numTask = System.Int32.Parse(findNode.InnerText);

			findNode = xmlDoc.SelectSingleNode ("Stats/Position");
			if(findNode != null)
			{
				float x = System.Single.Parse(findNode.Attributes["x"].Value);
				float y = System.Single.Parse(findNode.Attributes["y"].Value);
				Vector3 vec3 = new Vector3(x, y, 0f);
				poolr.rectTransform.position = vec3;
			}

			/////////////////////////////////////////////////////////////
			//xmlDoc.Save ("Data/Save/Stats.xml");
		}
	}
}

