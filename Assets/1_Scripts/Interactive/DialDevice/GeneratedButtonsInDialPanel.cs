using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GeneratedButtonsInDialPanel : MonoBehaviour
{

    public GameObject  prefabDialButton;

    List<Vector2> sizeButtons;
    List<Vector3> coordButtons;
    List<Vector3> rotationButtons;


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

        Generate( new RectTransform(), 0 );
        Generate( new RectTransform(), 1 );
        
    }

    private void Generate( RectTransform coord, int count )
    {
        var button = Instantiate( prefabDialButton );
        button.name = "button_" + (count + 1);
        button.transform.parent = transform;

        // Картинка
        button.GetComponent<Image>().sprite = graphicTarget[count].sprite;


        var spr = new SpriteState();
        spr.pressedSprite = graphicPressed[count].sprite;
        spr.highlightedSprite = graphicPressed[count].sprite;
        button.GetComponent<Button>().spriteState = spr;

        // положение на экране
        button.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
        button.GetComponent<RectTransform>().Rotate( rotationButtons[count] );

        button.transform.localPosition = coordButtons[count];
        button.GetComponent<RectTransform>().sizeDelta = sizeButtons[count];
    }

    void FullCoorButtonsList()
    {
        sizeButtons = new List<Vector2>();
        coordButtons = new List<Vector3>();
        rotationButtons = new List<Vector3>();

        //button 1
        coordButtons.Add( new Vector3( -13.9f, 154.6f ) );
        sizeButtons.Add( new Vector2( 51.15f, 49.42f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 2
        coordButtons.Add( new Vector3( 38.3f, 146.7f ) );
        sizeButtons.Add( new Vector2( 50.2f, 49.5f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 352.23f ) );//z 352.23f

    }
}
