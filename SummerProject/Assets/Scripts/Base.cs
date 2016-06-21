using UnityEngine;
using System.Collections;

/// <summary>
/// The class that all base things should derive from
/// </summary>
/// 
//namespace will be gameObject for all G.O. like things



    // types of bases you can build within a home base
   

    public class Base : MonoBehaviour
    {
    protected Base myBase;
    //the base GO, using greybox at first
        public GameObject BaseGameObject;
       protected enum BASE_TYPE { EMPTY, HOME, RESOURCE, BARRACKS, AIR, RESEARCH, VEHICLE };

        //rally point for units to go to when the are finished building
        private Transform base_rallyPoint;
        
    //protected static BASE_TYPE type;
       protected BASE_TYPE type = BASE_TYPE.EMPTY;
        protected int base_health;

    // Use this for initialization

    void Start()
    {
        myBase = new Base();
    }

        // Update is called once per frame
        protected Base()
        {

        }

        protected Base(int HP,  int baseType)
        {
            base_health = HP;
            type = (BASE_TYPE)baseType;
        }


        int getBaseHp()
        {
            return base_health;
        }

        void setBaseHp(int newHP)
        {
            base_health = newHP;
        }
    }


