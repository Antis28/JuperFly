using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public  class PoolR : MonoBehaviour {

    

    [HideInInspector] public Image SrollRect;
	[HideInInspector] public TaskManeger	taskManeger;

	[HideInInspector] public Text 	ShopText;
	[HideInInspector] public Text 	coinText;
	[HideInInspector] public Text  	taskText;
	[HideInInspector] public Text 	TaskNumber;
	[HideInInspector] public Text 	BonusFlyText;
	[HideInInspector] public Text  	taskHeaderText;
	[HideInInspector] public Text  	BonusTextTask;

	[HideInInspector] public Image 	PriceImageTask;
	[HideInInspector] public Image 	taskImage;
	[HideInInspector] public Image 	BonusImageTask;

	[HideInInspector] public Button 	newButton;
	[HideInInspector] public Button 	AnswerButton;
	[HideInInspector] public Button 	AnswerTaskButton;
	[HideInInspector] public Button 	exitButton;
	[HideInInspector] public Button 	BackButton;
	public Canvas 	TaskCanvas;
	[HideInInspector] public Canvas 	GameCanvas;
	[HideInInspector] public Text 		FlyTextTask;
	[HideInInspector] public Image 		FlyImageTask;	 
	[HideInInspector] public BonusControler bonusControler;
	[HideInInspector] public LoadStats loadStats;
	[HideInInspector] public SimplePlatformContoroler simplePlatformContoroler;
	[HideInInspector] public Shop shop;
	[HideInInspector] public RectTransform rectTransform ;
	[HideInInspector] public InputField AnswerInputField;
	 public InputField AnswerCeloeInputField;
	[HideInInspector] public InputField AnswerChislitelInputField;
	[HideInInspector] public InputField AnswerZnamenatelInputField;

	void Awake () 
	{
		AnswerCeloeInputField		= GameObject.Find ("CeloeInputField").GetComponent<InputField>();
		AnswerChislitelInputField	= GameObject.Find ("ChislitelInputField").GetComponent<InputField>();
		AnswerZnamenatelInputField	= GameObject.Find ("ZnamenatelInputField").GetComponent<InputField>();
		 
		SrollRect		= GameObject.Find ("SrollRect").GetComponent<Image>();
		rectTransform	= GameObject.FindGameObjectWithTag ("Player").GetComponent<RectTransform> ();
		shop			= GameObject.Find ("Shop (1)").GetComponent<Shop> ();
		ShopText		= GameObject.Find ("ShopText").GetComponent<Text>();
		simplePlatformContoroler = GameObject.FindGameObjectWithTag ("Player").GetComponent<SimplePlatformContoroler>();
		GameCanvas		= GameObject.Find ("GameCanvas").GetComponent<Canvas>();
		loadStats		= GameObject.Find ("DeathLine").GetComponent<LoadStats>();
		bonusControler	= GameObject.Find ("BonusControler").GetComponent<BonusControler>();
		coinText		= GameObject.Find ("CoinText").GetComponent<Text>();
		BonusFlyText	= GameObject.Find ("BonusFlyText").GetComponent<Text>();
		FlyTextTask		= GameObject.Find ("FlyTextTask").GetComponent<Text>();
		FlyImageTask	= GameObject.Find ("FlyImageTask").GetComponent<Image>();
		PriceImageTask 	= GameObject.Find ("PriceImageTask").GetComponent<Image>();
		BonusTextTask	= GameObject.Find ("BonusTextTask").GetComponent<Text>();
		BonusImageTask	= GameObject.Find ("BonusImageTask").GetComponent<Image>();
		AnswerInputField= GameObject.Find ("AnswerInputField").GetComponent<InputField>();

		TaskCanvas		= GameObject.Find ("TaskCanvas").GetComponent<Canvas>();
		TaskNumber		= GameObject.Find ("TaskNumber").GetComponent<Text>();
		taskHeaderText	= GameObject.Find ("TaskHeader").GetComponent<Text>();
		taskText 		= GameObject.Find ("TaskText").GetComponent<Text>();
		taskImage 		= GameObject.Find ("TaskImage").GetComponent<Image>();
		newButton 		= GameObject.Find ("NewTaskButton").GetComponent<Button>();

		AnswerButton 	= GameObject.Find ("AnswerTaskButton").GetComponent<Button>();
		exitButton 		= GameObject.Find ("ExitTaskButton").GetComponent<Button>();
		BackButton 		= GameObject.Find ("BackButton").GetComponent<Button>();
		taskManeger		= GameObject.FindGameObjectWithTag("TaskCanvas").GetComponent<TaskManeger>();

        //previoustButton = GameObject.Find ("PreviousTaskButton").GetComponent<Button>();	        
        //Invoke("showPool", 2);        
    }
    void showPool() { PoolReference.showPool(); }
}


