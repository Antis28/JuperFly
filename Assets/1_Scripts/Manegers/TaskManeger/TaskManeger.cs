using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System.IO;

public class TaskManeger : MonoBehaviour
{

    public LoadStats LS;

    public Vector3 exitPosition;
    public string answer;
    public string AnswerCeloe;
    public string AnswerChislitel;
    public string AnswerZnamenatel;

    public int numTask;
    public bool isAnswer;
    private int costTask;
    private int loadNumTask;


    public Image panelImage;
    public Sprite panelImageOriginal;
    public Image panelImageAnswer;
    public Image panelImageNoAnswer;
    public string putTaskBase = "Data/Save/TaskBase.xml";

    public PoolR poolr;

    void Start()
    {
        costTask = 10;
        poolr = GameObject.Find("PoolReference").GetComponent<PoolR>();

        poolr.TaskCanvas.gameObject.SetActive(false);
        poolr.TaskNumber.enabled = false;

        if (!File.Exists(putTaskBase))
        {
            TaskGenerator tg = new TaskGenerator();
            tg.GenerationXML();
        }
        ReadXML();
        loadNumTask = poolr.loadStats.numTask;
        if (numTask < loadNumTask)
            numTask = loadNumTask;


        poolr.BonusTextTask.text = poolr.coinText.text;
        VisibleTask();
        //Debug.Log ("EndStart");
    }

    private void amountOfBonusesAddTwo()
    {
        poolr.bonusControler.amountOfBonuses += 2;
        PoolReference.items_D["WingsItems"].AddItem(2);
    }

    void OnEnable()
    {
        if (poolr.AnswerCeloeInputField != null)
        {
            poolr.AnswerCeloeInputField.ActivateInputField();
            StartCoroutine(ChekKey());
        }

        if (numTask < 1)
            numTask = 1;

    }
    void OnDisable()
    {
        StopCoroutine(ChekKey());
    }

    private void Answer()
    {
        if (!isAnswer)
        {
            //panelImageOriginal = panelImage.sprite;
            if (AnswerZnamenatel == "")
            {
                if (answer == poolr.AnswerInputField.text)
                    RightAnswer();
                else
                    panelImage.sprite = panelImageNoAnswer.sprite;

            }
            else if (AnswerZnamenatel == poolr.AnswerZnamenatelInputField.text &&
                     AnswerChislitel == poolr.AnswerChislitelInputField.text &&
                     AnswerCeloe == poolr.AnswerCeloeInputField.text
                     )
                RightAnswer();
        }

    }

    IEnumerator ChekKey()
    {
        while (true)
        {
            Tabulation();
            yield return null;
        }

    }

    private void Tabulation()
    {
        //Debug.Log ("Tabulation()");
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (poolr.AnswerCeloeInputField.isFocused)
                poolr.AnswerChislitelInputField.ActivateInputField();
            else if (poolr.AnswerChislitelInputField.isFocused)
                poolr.AnswerZnamenatelInputField.ActivateInputField();

            else if (!poolr.AnswerCeloeInputField.isFocused)
            {
                poolr.AnswerCeloeInputField.ActivateInputField();
                Debug.Log("ActivateCeloe");
            }
        }

    }

    private void RightAnswer()
    {
        panelImage.sprite = panelImageAnswer.sprite;
        amountOfBonusesAddTwo(); 
        isAnswer = !isAnswer;
        ++numTask;
    }    


    public void TakeTask()
    {
        if (System.Int32.Parse(poolr.coinText.text) > costTask)
        {


            poolr.newButton.enabled = ReadXML();
            if (ReadXML())
            {
                poolr.coinText.text = (System.Int32.Parse(poolr.coinText.text) - costTask).ToString();
                poolr.TaskNumber.enabled = true;
                poolr.TaskNumber.text = numTask.ToString();


                VisibleTaskMainMenu();
                VisibleTask();
            }

        }
    }
    public void BackMenu()
    {
        VisibleTaskMainMenu();
        VisibleTask();
        panelImage.sprite = panelImageOriginal;
        poolr.TaskNumber.enabled = false;

        // Чистим поля ответов
        poolr.AnswerChislitelInputField.text = "";
        poolr.AnswerZnamenatelInputField.text = "";
        poolr.AnswerCeloeInputField.text = "";
        poolr.AnswerInputField.text = "";

        answer = "";
        AnswerChislitel = "";
        AnswerZnamenatel = "";
        AnswerCeloe = "";
    }
    public void TakeExit()
    {
        if (numTask > 1)
        {
            SaveStats ss = new SaveStats();
            ss.SaveStatistik(numTask.ToString(), "NumberTask");
        }
        Shop shop = poolr.shop;
        shop.simplePC.enabled = !shop.simplePC.enabled;

        poolr.GameCanvas.gameObject.SetActive(!poolr.GameCanvas.gameObject.activeSelf);
        poolr.TaskCanvas.gameObject.SetActive(!poolr.TaskCanvas.gameObject.activeSelf);
        //Debug.Log ("TakeExit()");

    }

    bool ReadXML()
    {
        //Многоугольник и его периметр. Равные фигуры.
        //Сумма всех сторон многоугольника называется периметром многоугольника.
        //Две фигуры называются равными, если они совмещаются наложением.

        if (File.Exists("Data/Save/TaskBase.xml"))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Data/Save/TaskBase.xml");
            foreach (XmlElement element in xml.GetElementsByTagName("Task_" + numTask))
            {
                foreach (XmlElement e in element)
                {
                    if (e.Name == "Header")
                        poolr.taskHeaderText.text = e.InnerText;
                    if (e.Name == "Question")
                        poolr.taskText.text = e.InnerText;
                    if (e.Name == "Answer")
                        answer = e.InnerText;

                    if (e.Name == "AnswerCeloe")
                        AnswerCeloe = e.InnerText;
                    if (e.Name == "AnswerChislitel")
                        AnswerChislitel = e.InnerText;
                    if (e.Name == "AnswerZnamenatel")
                        AnswerZnamenatel = e.InnerText;

                    if (e.Name == "IsAnswer")
                    {
                        isAnswer = System.Boolean.Parse(e.InnerText);
                    }
                }
                //Debug.Log("Есть задание №" + numTask);
                return true;
            }
        }
        //Debug.Log("Нет задания №" + numTask);
        return false;
    }


    void VisibleTask()
    {
        poolr.taskHeaderText.enabled = !poolr.taskHeaderText.enabled;
        poolr.taskText.enabled = !poolr.taskText.enabled;
        poolr.taskImage.enabled = !poolr.taskImage.enabled;

        poolr.SrollRect.enabled = !poolr.SrollRect.enabled;
        //Debug.Log ("poolr.SrollRect.enabled = " + poolr.SrollRect.enabled);

        poolr.AnswerButton.gameObject.SetActive(!poolr.AnswerButton.gameObject.activeSelf);
        //Debug.Log ("poolr.AnswerButton.gameObject.SetActive = " + poolr.AnswerButton.gameObject.activeSelf);

        if (AnswerZnamenatel != "")
        {
            poolr.AnswerCeloeInputField.gameObject.SetActive(!poolr.AnswerCeloeInputField.gameObject.activeSelf);
            poolr.AnswerChislitelInputField.gameObject.SetActive(!poolr.AnswerChislitelInputField.gameObject.activeSelf);
            poolr.AnswerZnamenatelInputField.gameObject.SetActive(!poolr.AnswerZnamenatelInputField.gameObject.activeSelf);
            poolr.AnswerInputField.gameObject.SetActive(false);
        }
        else
        {
            poolr.AnswerInputField.gameObject.SetActive(!poolr.AnswerInputField.gameObject.activeSelf);
            poolr.AnswerCeloeInputField.gameObject.SetActive(false);
            poolr.AnswerChislitelInputField.gameObject.SetActive(false);
            poolr.AnswerZnamenatelInputField.gameObject.SetActive(false);
        }
        poolr.BackButton.gameObject.SetActive(!poolr.BackButton.gameObject.activeSelf);
        poolr.BonusTextTask.text = poolr.coinText.text;
    }
    void VisibleTaskMainMenu()
    {
        poolr.newButton.gameObject.SetActive(!poolr.newButton.gameObject.activeSelf);
        poolr.exitButton.gameObject.SetActive(!poolr.exitButton.gameObject.activeSelf);
        poolr.BonusTextTask.text = poolr.coinText.text;
        poolr.PriceImageTask.gameObject.SetActive(!poolr.PriceImageTask.gameObject.activeSelf);
        //Debug.Log ("VisibleTaskMainMenu()");		
    }
}


