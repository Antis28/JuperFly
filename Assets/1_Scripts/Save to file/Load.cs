using UnityEngine;
using System.Collections;
using System.IO;

namespace Load
{
	public class Load {
	
		static private float x;
		static private float y;
		static private float z;
			
		// Use this for initialization
		static public Vector3 LoadFromFile () {

        StreamReader streamReader = new StreamReader("Data/Save/Position.sg"); // Открываем файл
			if(streamReader != null) {
         	while (!streamReader.EndOfStream) // Читаем строки пока они не закончатся
         	 {
				x = System.Convert.ToSingle(streamReader.ReadLine());
				y = System.Convert.ToSingle(streamReader.ReadLine());
				z = System.Convert.ToSingle(streamReader.ReadLine());
        	 }
			
				return new Vector3(x, y, z);
			}
			return new Vector3(0, 0, 0);
		}
			
		
	}
}

