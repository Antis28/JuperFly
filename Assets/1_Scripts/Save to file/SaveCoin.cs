using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO; // Используем библиотеку ввода вывода

namespace SaveCoin{

	public class SaveCoin { 

		static string CheckSave(string filename)// Путь сохранения
   		{
			// Если название файла не указанно то пишем по умолчанию
			if (filename != "Data/Save/saveStats.sg") 
			{
				filename = "Data/Save/saveStats.sg";
			}
			if (!Directory.Exists ("Data") || !Directory.Exists ("Data/Save"))
			{
				System.IO.Directory.CreateDirectory ("Data/Save");
				Debug.Log("create \" Data/Save \"");
				Debug.Log("filename == " + filename);
			}			
			return filename;

  		}
   
		static public void SaveInFile(Text text)
		{
			string filename = "";
			filename = CheckSave(filename);
		 
			StreamWriter sw = new StreamWriter(filename); // Создаем файл
			sw.WriteLine(text.text); // Пишем 				
           	sw.Close(); // Закрываем(сохраняем)     
  		}
}
}