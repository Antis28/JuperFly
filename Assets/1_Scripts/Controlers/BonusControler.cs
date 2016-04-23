using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BonusControler : MonoBehaviour {

    //public int amountOfBonuses;    

    private const int NUMBER_ITEMS = 3;

    private WingsItems WI;

    //public Hashtable items_HT = new Hashtable(NUMBER_ITEMS);
    public System.Collections.Generic.Dictionary<string,Items> items_D = new System.Collections.Generic.Dictionary<string, Items>();
    //Bonus Coin
    //public int coinValue = 0;   
    public Image coinImage;     // для класса CoinItem
    public Text numCoinGameText;    // для класса CoinItem
    public Text numCoinTaskText;    // для класса CoinItem

    // Use this for initialization
    void Start () {
        //while (items_D == null)
        {
            try
            {
                items_D.Add("CoinItems", new CoinItems(numCoinGameText, numCoinTaskText, coinImage));
                WI = new WingsItems();
                items_D.Add("WingsItems", WI);
            }
            catch (ArgumentException)
            {
                print( "Oбъект CoinItems уже добавлен " );
            }
        }
        PoolReference.items_D = items_D;
        //InvokeRepeating("ShowMeRepeat", 2f, 2f);
    }

    // Update is called once per frame
    void Update () 
	{
        try
        {
            //if(amountOfBonuses != 0)
               // WI.Amount = amountOfBonuses;
            WI.FlyEnabled();
            //amountOfBonuses = WI.Amount;
        }
        catch(NullReferenceException)
        {
            print(" WI == null");
        }
        

    }

    void ShowMeRepeat()
    {
        var items = items_D["CoinItems"];
        
        items.Show();
    }
    
}
