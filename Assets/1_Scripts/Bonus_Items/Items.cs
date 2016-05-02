using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public abstract class Items //: MonoBehaviour
{
    protected System.Int32 _itemAmount; // колличество предметов
    protected string modAmount = "D"; // "D" - до 1000 ; "K" - свыше 1000
    public Image itemImage;      // иконка предмета
    public Text itemTextGC;     // текстовое поле в gameCanvas связаное с предметом
    public Text itemTextTC;     // текстовое поле в taskCanvas связаное с предметом(количество крыльев отображаемых в задании)


    public abstract int Amount { get; set; }

    public virtual void AddItem()
    { Amount++; }
    public virtual void AddItem(int _amount)
    {
        Amount += _amount;
    }

    public abstract void Show();
}

public class CoinItems : Items
{
    //Конструктор для объекта принимающий ссылку текстового поля и каринки из канваса
    public CoinItems(Text gText, Text tText, Image cImage)
    {
        itemTextGC = gText;
        itemTextTC = tText;
        itemImage = cImage;        
        //System.Int32.TryParse(itemTextGC.text, out _itemAmount);
        LoadAmount();        
    }
    public CoinItems(CoinItems CI) // для HeartItrms
    {
        itemTextGC = CI.itemTextGC;
        itemImage = CI.itemImage;
        Amount = CI._itemAmount;
    }
    /////////////////////////////////////////////////////////////////////////////////////////   
    public override int Amount
    {
        get
        {
            return _itemAmount;
        }

        set
        {
            if (value >= 0 & value < 1000)
            {
                if (modAmount == "K")
                {
                    modAmount = "D";
                    _itemAmount = value * 1000;
                }
                _itemAmount = value;
            }
            else if (value > 1000)
            {
                if (modAmount == "D")
                {
                    _itemAmount = value / 1000;
                    modAmount = "K";
                }
                _itemAmount = value;
            }
            itemTextGC.text = itemTextTC.text = _itemAmount.ToString();
        }
    }


    public void AddHeart()
    {
        Amount += 10;
        itemTextGC.text = Amount.ToString();

    }

    public override void Show()
    {
        MonoBehaviour.print("CoinItems = " + Amount);
    }
    void LoadAmount()
    {
        Amount = PoolReference.TableScene["DeathLine"].GetComponent<LoadStats>()._amountCoin;
    }
}

public class HeartItems : CoinItems
{
    // 1 HeartItems = 10 CoinItems
    public HeartItems(CoinItems coinItems) : base(coinItems) { }

    new public void AddItem()
    {
        Int32.TryParse(itemTextGC.text, out _itemAmount);
        Amount += 10;
        itemTextGC.text = Amount.ToString();

    }
    public override void Show()
    {
        MonoBehaviour.print("HeartItems = " + Amount);
    }
}


public class WingsItems : Items
{
    #region Поля
    public bool isFly = false;      // разрешено ли летать
    public float flyValue = 1.8f;    // значение веса персонажа?
    public float flyTime = 3f;       // время действия
    public float flyTimeValue = 3f;  // текущее время действя
    public GameObject flyImage;           // картинка предмета?


    public Text numFlyText;         // колличество предметов

    GameObject hero;
    SimplePlatformContoroler simplePlatformContoroler;


    private GameObject _visibleItem; //???
    #endregion

    public override int Amount
    {
        get
        { return _itemAmount; }

        set
        {
            if (value >= 0)
            {
                itemTextGC.text = itemTextTC.text = (_itemAmount = value).ToString();
                               
            }
        }
    }
    #region Конструкторы
    public WingsItems(int amount)
    {
        Initialization();
        Amount = amount;
    }
    public WingsItems()
    {
        Initialization();
    }
    #endregion

    #region Методы
    //[Obsolete("Временно используется глобальный amountOfBonuses")]
    void Initialization()
    {
        GameObject goTemp;
        try
        {
            hero = PoolReference.TableScene["hero"] as GameObject;
            _visibleItem = PoolReference.TableScene["BonusFlyImage"];
            flyImage = GameObject.FindGameObjectWithTag("Wing");
            
            goTemp = PoolReference.TableScene["BonusFlyText"];
            if (goTemp != null) itemTextGC = goTemp.GetComponent<Text>();

            goTemp = PoolReference.TableScene["FlyTextTask"];
            if (goTemp != null) itemTextTC = goTemp.GetComponent<Text>();

            simplePlatformContoroler = hero.GetComponent<SimplePlatformContoroler>();

            _visibleItem.SetActive(false);
            flyImage.SetActive(false);

            LoadAmount();
        }
        catch (MissingReferenceException)
        {
            MonoBehaviour.print("Initialization() - MissingReferenceException!!!!");
        }
    }

    public void FlyEnabled()
    {
        if (Amount > 0)
        {
           // MonoBehaviour.print("FlyEnabled() в Amount > 0");
            _visibleItem.SetActive(true);
            itemTextGC.text = Amount.ToString();
            if (Input.GetKeyDown(KeyCode.F) && !PoolReference.TableScene[EnumInPool.TaskCanvas.ToString()].activeSelf )
                isFly = true;
            Fly();
        }
        else
        {
            //MonoBehaviour.print("FlyEnabled() в else" + "\n Amount = " + Amount);
            _visibleItem.SetActive(false);
        }     
    }

    void Fly()
    {
        //MonoBehaviour.print("Fly");
        var rb2d = hero.GetComponent<Rigidbody2D>();
        if (isFly)
        {
            if (Input.GetButtonDown("Jump"))
            {
                simplePlatformContoroler.jump = true;
            }


            rb2d.mass = flyValue;
            flyImage.SetActive(true);
            if (flyTime > 0)
            {
                flyTime -= Time.deltaTime;
                ;
            }
            else
            {
                simplePlatformContoroler.grounded = false;
                isFly = false;
                flyTime = flyTimeValue;
                itemTextGC.text = (--Amount).ToString();
                flyImage.SetActive(false);
            }

        }
        else
            rb2d.mass = 2f;
    }

    public override void Show()
    {
        MonoBehaviour.print("WingsItems = " + Amount);
    }

    void LoadAmount()
    {
        Amount = PoolReference.TableScene["DeathLine"].GetComponent<LoadStats>()._amountOfWings;        
    }

    
    #endregion
}