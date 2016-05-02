
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(Transform))] //Сообщаем редактору, что это класс для кастомизации вкладки инспектора, компонента "Test"
class TestCustomize : Editor{ //Наследуем наш класс кастомизации, от редактора Юнити
	/*	
	public override void OnInspectorGUI(){ //Сообщаем редактору, что этот инспектор заменит прежний (встроеный)
		DrawDefaultInspector();//отрисовка содержимого инспектора по умолчанию

		EditorGUILayout.Space();
		if(GUILayout.Button("Наша кнопка")){
			
			Debug.Log(1);
		}
		GUILayout.Space(5);
		if(GUILayout.Button("Наша кнопка 2")){
			
			Debug.Log(2);
		}
	*/
	}
}
