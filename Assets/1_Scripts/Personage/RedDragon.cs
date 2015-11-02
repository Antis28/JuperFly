using UnityEngine;
using System.Collections;

public class RedDragon : IVital, IExperience
{
    int _experience;
    int _remainToUp = 100; // осталось до следующего уровня?

    public int Intellect
    { get; set; }

    public int Strength
    { get; set; }

    public int Speed
    { get; set; }

    public int Experience
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

    public int Level
    { get; set; }



    #region Методы



    public void LevelUp() {
        Level++;
        MonoBehaviour.print("LevelUp для RedDragon.\nLevel = " + Level);
    }
    #endregion
}
