using UnityEngine;
using System.Collections;
using System.IO;

namespace LoadCoin
{
	public class LoadCoin {
			
		// Use this for initialization
		static public string LoadFromFile () {
			string coin = "0";

			if (File.Exists ("Data/Save/NumCoins.sg")) {
				StreamReader streamReader = new StreamReader ("Data/Save/NumCoins.sg"); // Открываем файл
				if (streamReader != null) {
					while (!streamReader.EndOfStream) { // Читаем строки пока они не закончатся
						coin = streamReader.ReadLine ();
						Debug.Log ("LoadcCoin");
					}
			
					return coin.ToString ();
				}
				streamReader.Close();
			}
			return coin;
		}
			
		
	}
}

