using UnityEngine;
using System.Collections;
using System.IO; // Используем библиотеку ввода вывода

namespace Save{

public class Save { 
   
	static string CheckSave(string filename)// Путь сохранения
   {
	// Если название файла не указанно то пишем по умолчанию
				
      if ( filename == "" ) 
				return "Data/Save/Position.sg"; 
			return filename;
      
   }
   
		static public void SaveFromFile(Transform transform)
		{
			string filename = "";
			filename = CheckSave(filename);
        	StreamWriter sw = new StreamWriter(filename); // Создаем файл
            	sw.WriteLine(transform.position.x); // Пишем координаты
				sw.WriteLine(transform.position.y);
				sw.WriteLine(transform.position.z);
				Debug.Log("Save" + transform.position);
           	 	sw.Close(); // Закрываем(сохраняем)
      
  		}
}
}