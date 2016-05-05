using UnityEngine;
using System.Collections;
using System;

public class AddToPoolCanvas : MonoBehaviour
{

    //PoolReference pool;   
    public Canvas   GameCanvas;
    public Canvas   TaskCanvas;
    public Canvas   SkillsCanvas;
    public Canvas   FightCanvas;
    public Canvas   DialCanvas;

    // Use this for initialization
    void Awake()
    {

        try
        {
            try
            {
                PoolReference.TableScene.Add( name.ToString(), gameObject );
            } catch( ArgumentException )
            {
                print( "Такой ключ уже существует: " + this.name );
            }
            try
            {
                PoolReference.TableScene.Add( GameCanvas.name, GameCanvas.gameObject );
                //print( TaskCanvas.name );
            } catch( ArgumentException ) { print( "Такой ключ уже существует: " + TaskCanvas.name ); } 
            catch( Exception ) { print( "Проверь у скриптов наличие ссылок на объекты" ); }

            try
            {
                PoolReference.TableScene.Add( TaskCanvas.name, TaskCanvas.gameObject );
                //print( TaskCanvas.name );
            } catch( ArgumentException ) { print( "Такой ключ уже существует: " + TaskCanvas.name ); }
            try
            {
                PoolReference.TableScene.Add( SkillsCanvas.name, SkillsCanvas.gameObject );
                //print( SkilsCanvas.name );
            } catch( ArgumentException ) { print( "Такой ключ уже существует: " + SkillsCanvas.name ); }
            try
            {
                PoolReference.TableScene.Add( FightCanvas.name, FightCanvas.gameObject );
               // print( FightCanvas.name );
            } catch( ArgumentException ) { print( "Такой ключ уже существует: " + FightCanvas.name ); }
            try
            {
                PoolReference.TableScene.Add( DialCanvas.name, DialCanvas.gameObject );
                // print( FightCanvas.name );
            } catch( ArgumentException ) { print( "Такой ключ уже существует: " + DialCanvas.name ); }


    } catch( NullReferenceException )
        {
            print( "Нет ссылки на объект " );
        }
    }
}
