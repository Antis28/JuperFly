using UnityEngine;
using System.Collections;
using System;

public class DialDeviceCore : MonoBehaviour
{
     GameObject starGate;
    void Start()
    {
        starGate = GetComponent<DialManeger>().starGateVortex.GetComponentInParent<GameObject>();       
    }

    public abstract class ShevronCode
    {
        public const string CAVE_1_SEED_73 = "12337382021",
                            CAVE_2_SEED_25 = "45617161521",
                            CAVE_3_SEED_73 = "52337382021";


        public static ShevronCode Create( string code )
        {
            switch( code )
            {
                case CAVE_1_SEED_73:
                    return new Cave_01_seed_73();
                case CAVE_2_SEED_25:
                    return new Cave_02_seed_25();
                case CAVE_3_SEED_73:
                    return new Cave_03_seed_25();
                default:
                    //throw new Exception( "Incorrect Employee Code" );
                    return null;
            }
        }

        public abstract void SetLocation();
    }

    //ShevronCode location

    class Cave_01_seed_73 : ShevronCode
    {
        public override  void SetLocation()
        {
            //Настройка портала на локацию с названием %метод%
            var mg = PoolReference.TableScene["Map Generator"].GetComponent<MapGenerator>();
            mg.seed = CAVE_1_SEED_73;
            mg.GenerateMap();
        }
    }
    class Cave_02_seed_25 : ShevronCode
    {
        public override void SetLocation()
        {
            //Настройка портала на локацию с названием %метод%
        }
    }
    class Cave_03_seed_25 : ShevronCode
    {
        public override void SetLocation()
        {
            //Настройка портала на локацию с названием %метод%
        }
    }
}
