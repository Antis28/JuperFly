using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SaveCoin;
using Load;

public class GuiPlatformerControler : MonoBehaviour {

	public Text coinText;
	public Text BonusFlyText;
	void Start()
	{
        /*
        // Загрузка из файла количество монет.
        string coinValue = LoadCoin.LoadCoin.LoadFromFile();
        if (coinValue != "10")
            coinText.text = coinValue;
         */

    }
/*
	void OnGUI () // Создаем ГУИ элементы, текстовое поле и 2 кнопки
	{
		if ( GUI.Button( new Rect(10,10,60,20),"Write") ) // Нажата кнопка "запись"?
		{
			//SaveCoin.SaveCoin.SaveFromFile(coinText);
			Debug.Log("Save Complite");
		}

	}
*/
}