using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

// Основные характеристики
public interface IVital
{
    int Intellect { get; }
    int Strength { get; }
    int Speed { get; }
}
// Опыт
public interface IExperience
{
    int Experience { get; set; }    // колличество текущего опыта
    int Level { get; set; }          // текущий уровень

    void LevelUp();
}

public interface IPointSkils
{
    int Point { get; set; }
}

public abstract class Skills : IVital, IExperience, IPointSkils
{
    protected int _experience;
    protected int _remainToUp = 100; // осталось до следующего уровня?   


    protected int _strength;
    protected int _speed;
    protected int _intellect;
    protected int _point;

    public Text PointExpText;      //Поле для оставшихся поинтов распределения
    protected Text strengthNumText; //Поле для увеличение силы
    protected Text intellectNumText;
    protected Text speedNumText;


    protected Button speedNumButton;
    protected Button strengtNumButton;
    protected Button intellectNumButton;

    public int Intellect { get{ return _intellect;  } set { intellectNumText.text = (_intellect = value).ToString(); } }
    public int Strength { get { return _strength;   } set { strengthNumText.text =  (_strength  = value).ToString(); } }
    public int Speed    { get { return _speed;      } set { speedNumText.text =     (_speed     = value).ToString(); } }
    public int Point {
        get { return _point; }
        set
        {
            if (PointExpText != null) PointExpText.text = (_point = value).ToString();
        }
    }

    public abstract int Experience { get; set; }
    public abstract int Level { get; set; }

    public abstract void LevelUp();
}
