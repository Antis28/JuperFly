using UnityEngine;
using UnityEditor;

public class LookAtWindow : EditorWindow
{
	
	// Регистрируем пункт меню и функцию, выполняющую открытие окна
	[MenuItem("Window/Look At Window")]
	public static void CreateWindow()
	{
		LookAtWindow window = GetWindow<LookAtWindow>();
		window.title = "Look At Window";
	}
	
	// объект для поворота
	public Transform source;
	// цель
	public Transform target;
	
	// Функция отрисовки окна
	public void OnGUI()
	{
		// поле для указания исходного объекта
		GUILayout.BeginHorizontal();
		GUILayout.Label("Source:", GUILayout.Width(120));
		source = (Transform)EditorGUILayout.ObjectField(source, typeof(Transform));
		GUILayout.EndHorizontal();
		
		// поле для указания цели
		GUILayout.BeginHorizontal();
		GUILayout.Label("Target:", GUILayout.Width(120));
		target = (Transform)EditorGUILayout.ObjectField(target, typeof(Transform));
		GUILayout.EndHorizontal();
		
		// запоминаем текущий цвет GUI для восстановления
		Color oldColor = GUI.color;
		
		// проверяем наричие объекта для поворота и цели
		bool flag = false;
		if (source == null || target == null)
		{
			GUI.color = Color.red;
			GUILayout.Label("Selcect Source and Target!");
			flag = true;
			GUI.color = oldColor;
		}
		
		// если цель является объектом
		if ((source == target) && !flag)
		{
			GUI.color = Color.red;
			GUILayout.Label("Source equals Target!");
			GUI.color = oldColor;
		}
		
		// Делаем кнопку неактивной если не выполняется условие
		GUI.enabled = !flag && (source != target);
		
		// свободное место
		GUILayout.FlexibleSpace();
		
		// button, выполняющая действие
		if (GUILayout.Button("Look At"))
		{
			source.LookAt(target);
		}
		
		// снова активируем GUI
		GUI.enabled = true;
		GUILayout.Space(8);
		
	}
}

