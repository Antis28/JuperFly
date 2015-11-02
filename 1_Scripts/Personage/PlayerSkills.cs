using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PlayerSkills : Skills
{
    const int POINT = 2;        // доп. очки при достижении нового уровня

    public override int Experience
    {
        get
        { return _experience; }

        set
        {
            if (_experience > _remainToUp)
                LevelUp();
            else
                _experience = value;
        }
    }

    public override int Level
    { get; set; }  

    public PlayerSkills()
    {
        Inicialization(); // Запускается перед первым обращением к Amount
        Point = 5;
        Level = 1; 
    }

    void Inicialization()
    {
        while (PointExpText == null)
        {
            try {
                strengthNumText  = PoolReference.TableScene["strengthNumText"].GetComponent<Text>();
                intellectNumText = PoolReference.TableScene["intellectNumText"].GetComponent<Text>();
                speedNumText     = PoolReference.TableScene["speedNumText"].GetComponent<Text>();


                PointExpText = PoolReference.TableScene["PointExpText"].GetComponent<Text>();
                PointExpText.text = Point.ToString();
            }
            catch(KeyNotFoundException)
            { MonoBehaviour.print("Inicialization в PlayerSkills не удалась. \nпроверьте ссылки в TableScene.\nПроверить addToPool на объектах.\n"); break; }
        }

    }

    #region Методы


    public override void LevelUp()
    {
        Level++;
        RevertEnabledButton();
        Point = POINT; 
        MonoBehaviour.print("LevelUp для PlayerSkills.\nLevel = " + Level);
       
    }
    public void addIntellect()  { if (Point > 0) { Intellect++; Point--; }  else RevertEnabledButton(); }
    public void addSpeed() {    if (Point > 0) { Speed++; Point--;          }  else RevertEnabledButton(); }
    public void addStrength() { if (Point > 0) { Strength++; Point--;    }  else RevertEnabledButton(); }

    public void removeIntellect()   { if (Intellect > 0) {    Intellect--; Point++; } else RevertEnabledButton(); }
    public void removeSpeed()       { if (Speed > 0)     {    Speed--; Point++; } else RevertEnabledButton(); }
    public void removeStrength()    { if (Strength > 0)  {    Strength--; Point++; } else RevertEnabledButton(); }



    void RevertEnabledButton()
    {
        //speedNumButton.enabled = !speedNumButton.enabled;
        //strengtNumButton.enabled = !strengtNumButton.enabled;
        //intellectNumButton.enabled = !intellectNumButton.enabled;
    }
    #endregion
}
