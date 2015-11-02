using UnityEngine;
using System.Collections;
using Save;
using Load;



public class Gui : MonoBehaviour {

	void Start()
	{
		if (Load.Load.LoadFromFile() != new Vector3(0,0,0))
			transform.position = Load.Load.LoadFromFile();
	}

	void OnGUI () // Создаем ГУИ элементы, текстовое поле и 2 кнопки
	{
		if ( GUI.Button( new Rect(10,10,60,20),"Write") ) // Нажата кнопка "запись"?
		{
			Save.Save.SaveFromFile(this.transform);
		}

	}
}