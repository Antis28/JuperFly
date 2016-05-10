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

    public Sprite[] graphicPressedAlt;
    public Sprite[] graphicTargetAlt;

    // Use this for initialization
    void Start()
    {
        graphicPressed = new Image[39];
        graphicTarget = new Image[39];
        FullCoordButtonsList();
        for( int i = 0; i < graphicPressed.Length; i++ )
        {
            try
            {
                graphicPressed[i] = (Resources.Load( "DialPanelButtons/" + (i + 1) + "_Pressed" ) as GameObject).GetComponent<Image>(); // Загружаю из Assets\Resources\1_Pressed.psd        
                graphicTarget[i] = (Resources.Load( "DialPanelButtons/" + (i + 1) + "_Target" ) as GameObject).GetComponent<Image>();
            } catch { }
        }
        for( int i = 0; i < graphicPressed.Length; i++ )
        {
            try
            {
                Generate( i );
            } catch (Exception err){ print( err.Message ); }
        }
    }

    private void Generate(int count )
    {        
        var button = Instantiate( prefabDialButton );
        button.name = "button_" + (count + 1);
        button.transform.SetParent( transform );

        // Картинка
        //button.GetComponent<Image>().sprite = graphicTarget[count].sprite;
        button.GetComponent<Image>().sprite = graphicTargetAlt[count];


        var spr = new SpriteState();
        //spr.pressedSprite = graphicPressed[count].sprite;
        //spr.highlightedSprite = graphicPressed[count].sprite;
        spr.pressedSprite = graphicTargetAlt[count];
        spr.highlightedSprite = graphicPressedAlt[count];
        button.GetComponent<Button>().spriteState = spr;

        // положение на экране
        button.GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);
        try
        {
            button.GetComponent<RectTransform>().Rotate( rotationButtons[count] );
            button.transform.localPosition = coordButtons[count];
            button.GetComponent<RectTransform>().sizeDelta = sizeButtons[count];
        } catch { print( "Положение на экране не задано" ); }
    }

    void FullCoordButtonsList()
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

        //button 3
        coordButtons.Add( new Vector3( 82.5f, 125.2f ) );
        sizeButtons.Add( new Vector2( 47.4f, 46.3f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 325.5302f ) );

        //button 4
        coordButtons.Add( new Vector3( 119.6f, 92.8f ) );
        sizeButtons.Add( new Vector2( 52.2f, 52.2f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 308.8645f ) );

        //button 5
        coordButtons.Add( new Vector3( 141.7f, 49f ) );
        sizeButtons.Add( new Vector2( 59.1f, 51f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 291.49f ) );

        //button 6
        coordButtons.Add( new Vector3( 149.9f, -2.25f ) );
        sizeButtons.Add( new Vector2( 48f, 51.5f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 7
        coordButtons.Add( new Vector3( 140.88f, -48.6f ) );
        sizeButtons.Add( new Vector2( 53.658f, 52.4f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 244.1967f ) );

        //button 8
        coordButtons.Add( new Vector3( 118.2f, -92.5f ) );
        sizeButtons.Add( new Vector2( 52.4f, 55.9f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 318.6895f ) );

        //button 9
        coordButtons.Add( new Vector3( 81.9f, -126f ) );
        sizeButtons.Add( new Vector2( 53.377f, 55.8f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 25.0433f ) );

        //button 10
        coordButtons.Add( new Vector3( 35.2f, -146.4f ) );
        sizeButtons.Add( new Vector2( 55.4f, 51.9f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 14.39444f ) );
        
        //button 11
        coordButtons.Add( new Vector3( -16.9f, -149.4f ) );
        sizeButtons.Add( new Vector2( 50.5f, 50.5f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 12
        coordButtons.Add( new Vector3( -61.2f, -137.75f ) );
        sizeButtons.Add( new Vector2( 48.2f, 51.6f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 334.6653f ) );

        //button 13
        coordButtons.Add( new Vector3( -103.4f, -111.1f ) );
        sizeButtons.Add( new Vector2( 50.1f, 50f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 317.09f ) );

        //button 14
        coordButtons.Add( new Vector3( -134.2f, -71.8f ) );
        sizeButtons.Add( new Vector2( 52.6f, 52.6f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 293.3542f ) );

        //button 15
        coordButtons.Add( new Vector3( -153f, -25.5f ) );
        sizeButtons.Add( new Vector2( 53.5f, 51f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 16
        coordButtons.Add( new Vector3( -152.8f, 28.5f ) );
        sizeButtons.Add( new Vector2( 53.9f, 51.6f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 357.392f ) );

        //button 17
        coordButtons.Add( new Vector3( -133f, 73.2f ) );
        sizeButtons.Add( new Vector2( 48.5f, 54.5f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 334.7f ) );

        //button 18
        coordButtons.Add( new Vector3( -102f, 112.2f ) );
        sizeButtons.Add( new Vector2( 47.2f, 53.4f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 314.1741f ) );

        //button 19
        coordButtons.Add( new Vector3( -61.5f, 141.2f ) );
        sizeButtons.Add( new Vector2( 48.8f, 52.1f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 28.48405f ) );

        //button 20
        coordButtons.Add( new Vector3( -11f, 98.8f ) );
        sizeButtons.Add( new Vector2( 31.6f, 46.3f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 21
        coordButtons.Add( new Vector3( 25f, 97f ) );
        sizeButtons.Add( new Vector2( 35.5f, 48f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 353.6294f ) );

        //button 22
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 23
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 24
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 25
        coordButtons.Add( new Vector3( 96.7f, 3.1f ) );
        sizeButtons.Add( new Vector2( 49.2f, 40.8f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 26
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 27
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 28
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 29
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 30
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 31
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 32
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 33
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 34
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 34
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 36
        coordButtons.Add( new Vector3( 0f, 0f ) );
        sizeButtons.Add( new Vector2( 0f, 0f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 0f ) );

        //button 37
        coordButtons.Add( new Vector3( -66.30001f, 76.4f ) );
        sizeButtons.Add( new Vector2( 38f, 48.7f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 41.9403f ) );

        //button 38
        coordButtons.Add( new Vector3( -39.9f, 91.005f ) );
        sizeButtons.Add( new Vector2( 37.4f, 48.29f ) );
        rotationButtons.Add( new Vector3( 0f, 0f, 19.31821f ) );

    }
}
