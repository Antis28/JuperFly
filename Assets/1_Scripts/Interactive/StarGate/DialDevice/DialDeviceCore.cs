using UnityEngine;
using System.Collections;
using System;

public class DialDeviceCore : MonoBehaviour
{

    public const string     HOME           = "19181716151413",
                            CAVE_1_SEED_73 = "12337382021",
                            CAVE_2_SEED_25 = "45617161521",
                            CAVE_3_SEED_73 = "52337382021";



    string mainGate = "StarGateArea/StarGateMain/Vortex";
    static GameObject SGMain;

    string otherGate = "OtherWorlds/OtherGate/CaveStarGate/Vortex";
    static GameObject SGOther;

    static DialManeger dialManeger;

    void Start()
    {
        SGMain = GameObject.Find( mainGate );
        SGOther = GameObject.Find( otherGate );
        dialManeger = GetComponent<DialManeger>();
        //print( dialManeger );
    }
    public ShevronCode CreateShevronCode( string code )//из строки в объект
    {
        switch( code )
        {
            case HOME:
                return new GoHome();
            case CAVE_1_SEED_73:
                return new Cave_01_seed_73();
            case CAVE_2_SEED_25:
                return new Cave_02_seed_25();
            case CAVE_3_SEED_73:
                return new Cave_03_seed_25();
            default:
                return null;
        }
    }



    public abstract class ShevronCode
    {
        public abstract void CreateWorld();
    }
    //ShevronCode location
    class GoHome : ShevronCode
    {
        void SetUpGate()
        {
            SGOther.GetComponent<InPortal>().exitPortal = SGMain.transform;
            dialManeger.animatorMainGate = SGOther.GetComponent<Animator>();
            dialManeger.animatorOtherGate = SGMain.GetComponent<Animator>();
        }

        public override void CreateWorld()
        {
            SetUpGate();
        }
    }
    class Cave_01_seed_73 : ShevronCode
    {
        public override void CreateWorld()
        {
            SetLocation();
            SetUpGate();
        }

        void SetLocation()
        {
            //Настройка портала на локацию с названием %метод%
            var mg = PoolReference.TableScene["Map Generator"].GetComponent<MapGenerator>();
            mg.seed = CAVE_1_SEED_73;
            mg.GenerateMap();
        }

        void SetUpGate()
        {
            SGMain.GetComponent<InPortal>().exitPortal = SGOther.transform;
            dialManeger.animatorMainGate = SGMain.GetComponent<Animator>();
            dialManeger.animatorOtherGate = SGOther.GetComponent<Animator>();
            SGOther.transform.parent.transform.localPosition = new Vector3( -191f, -71.4f, 0 );
            print( SGOther.transform.parent.name );
        }
    }
    class Cave_02_seed_25 : ShevronCode
    {
        public override void CreateWorld()
        {
            SetLocation();
            SetUpGate();
        }

        void SetLocation()
        {
            //Настройка портала на локацию с названием %метод%
            var mg = PoolReference.TableScene["Map Generator"].GetComponent<MapGenerator>();
            mg.seed = CAVE_2_SEED_25;
            mg.GenerateMap();
            
        }

        void SetUpGate()
        {
            SGMain.GetComponent<InPortal>().exitPortal = SGOther.transform;
            dialManeger.animatorMainGate = SGMain.GetComponent<Animator>();
            dialManeger.animatorOtherGate = SGOther.GetComponent<Animator>();
            SGOther.transform.parent.transform.localPosition = new Vector3( -113.9f, 31.1f, 0 );
        }
    }
    class Cave_03_seed_25 : ShevronCode
    {
        public override void CreateWorld()
        {
            SetLocation();
            SetUpGate();
        }

        void SetLocation()
        {
            //Настройка портала на локацию с названием %метод%
            var mg = PoolReference.TableScene["Map Generator"].GetComponent<MapGenerator>();
            mg.seed = CAVE_3_SEED_73;
            mg.GenerateMap();           
        }

        void SetUpGate()
        {
            SGMain.GetComponent<InPortal>().exitPortal = SGOther.transform;
            dialManeger.animatorMainGate = SGMain.GetComponent<Animator>();
            dialManeger.animatorOtherGate = SGOther.GetComponent<Animator>();
            SGOther.transform.parent.transform.localPosition = new Vector3( -126.61f, -64.26f, 0 );
        }
    }


    
}
