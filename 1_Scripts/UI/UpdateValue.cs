using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateValue : MonoBehaviour {

	public Text text;
	public Slider slider;

	public void UpdateText()
	{
		text.text = slider.value.ToString ();
	}
}
