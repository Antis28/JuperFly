using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO; // Используем библиотеку ввода вывода
using System.Xml;


public class SaveStats { 

	string filePatch = "Data/Save/Stats.xml";

	public void SaveStatistik(string statText, string name)
	{
		CheckFile ();
		// Создаем корневой элемент
		XmlDocument xmlDoc = new XmlDocument ();
		if(File.Exists(filePatch))
			xmlDoc.Load (filePatch);

		XmlNode xRoot; 
		XmlNode findNode = xmlDoc.SelectSingleNode ("Stats"); // найти корневой элемент
		if ( findNode == null)
			xRoot = xmlDoc.CreateElement ("Stats"); 	// Создать корневой элемент
		else
			xRoot = findNode;	
		
		xmlDoc.AppendChild (xRoot);
		
		//Временные преременные для дочерних элементов и атрибутов
		XmlElement taskElement1; //Элемент 1-го уровня

		findNode = xmlDoc.SelectSingleNode ("Stats/" + name);
		if ( findNode == null) {
			taskElement1 = xmlDoc.CreateElement (name);
			taskElement1.InnerText = statText;
			xRoot.AppendChild (taskElement1);
		} else {
			findNode.InnerText = statText;
		}
		
		/////////////////////////////////////////////////////////////
		xmlDoc.Save ("Data/Save/Stats.xml");		
	}
	public void SaveStatistik(Vector3 vec3, string name)
	{
		CheckFile ();
		// Создаем корневой элемент
		XmlDocument xmlDoc = new XmlDocument ();
		if(File.Exists(filePatch))
			xmlDoc.Load (filePatch);
		
		XmlNode xRoot; 
		XmlNode findNode = xmlDoc.SelectSingleNode ("Stats"); // найти корневой элемент
		if ( findNode == null)
			xRoot = xmlDoc.CreateElement ("Stats"); 	// Создать корневой элемент
		else
			xRoot = findNode;	
		
		xmlDoc.AppendChild (xRoot);
		
		//Временные преременные для дочерних элементов и атрибутов
		XmlElement taskElement1; //Элемент 1-го уровня
		XmlAttribute posAtr;

		findNode = xmlDoc.SelectSingleNode ("Stats/" + name);
		if (findNode == null) {
			taskElement1 = xmlDoc.CreateElement (name);

			posAtr = xmlDoc.CreateAttribute ("z");
			posAtr.Value = vec3.z.ToString ();
			taskElement1.Attributes.Append (posAtr);

			posAtr = xmlDoc.CreateAttribute ("y");
			posAtr.Value = vec3.y.ToString ();
			taskElement1.Attributes.Append (posAtr);

			posAtr = xmlDoc.CreateAttribute ("x");
			posAtr.Value = vec3.x.ToString ();
			taskElement1.Attributes.Append (posAtr);

			xRoot.AppendChild (taskElement1);
		}
		else
		{
			findNode.Attributes["x"].Value = vec3.x.ToString ();
			//XmlNode pos = findNode;
			//string ns = pos.GetNamespaceOfPrefix("x");
			//XmlNode attr = xmlDoc.CreateNode(XmlNodeType.Attribute, "x", ns);
			//attr.Value = vec3.x.ToString ();
			//pos.Attributes.SetNamedItem(attr);

			findNode.Attributes["y"].Value = vec3.y.ToString ();
			//attr = xmlDoc.CreateNode(XmlNodeType.Attribute, "y", ns);
			//attr.Value = vec3.y.ToString ();
			//pos.Attributes.SetNamedItem(attr);
		}


		xmlDoc.Save ("Data/Save/Stats.xml");	
	}


	void CheckFile()
	{
		XmlDocument xmlDoc = new XmlDocument ();
		XmlElement  xRoot = xmlDoc.CreateElement("Stats"); // Корневой элемент
		xmlDoc.AppendChild (xRoot);
		
		if (!Directory.Exists ("Data/Save")) {
			Directory.CreateDirectory ("Data/Save");
			Debug.Log ("Do not found Directory \"Data/Save\"");
		}

	}
}
