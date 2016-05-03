using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GeneratedButtonsInDialPanel : MonoBehaviour
{

    public GameObject  prefabDialButton;

    List<Vector2> sizeButtons;
    List<Vector3> coordButtons;


    public Image[] graphicPressed;
    public Image[] graphicTarget;

    // Use this for initialization
    void Start()
    {
        graphicPressed = new Image[39];
        graphicTarget = new Image[39];
        FullCoorButtonsList();
        for( int i = 0; i < graphicPressed.Length; i++ )
        {
            try
            {
                graphicPressed[i] = (Resources.Load( "DialPanelButtons/" + (i + 1) + "_Pressed" ) as GameObject).GetComponent<Image>(); // Загружаю из Assets\Resources\1_Pressed.psd        
                graphicTarget[i] = (Resources.Load( "DialPanelButtons/" + (i + 1) + "_Target" ) as GameObject).GetComponent<Image>();
            } catch { }
        }


        Generate( new RectTransform(), 36 );
    }

    private void Generate( RectTransform coord, int count )
    {
        var button = Instantiate( prefabDialButton );
        button.name = "button_" + (count+1);
        button.transform.parent = transform;

        // Картинка
        button.GetComponent<Image>().sprite = graphicTarget[count].sprite;
        button.GetComponent<Button>().targetGraphic = graphicTarget[count];

        var spr = new SpriteState();
        spr.pressedSprite = graphicPressed[count].sprite;
        button.GetComponent<Button>().spriteState = spr;

        // положение на экране
        button.GetComponent<RectTransform>().localScale = new Vector3( 1f, 1f, 1f );

        button.transform.localPosition = coordButtons[0];
        button.GetComponent<RectTransform>().sizeDelta = sizeButtons[0];


    }

    void FullCoorButtonsList()
    {
        sizeButtons = new List<Vector2>();
        coordButtons = new List<Vector3>();

        //button 1
        coordButtons.Add( new Vector3( -11.9f, 151.7f ) );
        sizeButtons.Add( new Vector2( 58.1f, 50.3f ) );

    }
}
