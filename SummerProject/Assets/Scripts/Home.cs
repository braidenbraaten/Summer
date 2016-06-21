using UnityEngine;
using System.Collections;

/// <summary>
/// The Home Base will be where all of the other base types can be built from .
/// It can hold 7 slots in total
/// </summary>

   

public class Home : Base {
    protected Home home;

    //holds 7 slots for base types, holds 4 turret slots, 


	// Use this for initialization
	void Start () {
        home = new Home();
	}
	
	// Update is called once per frame
	void Update () {
	
        

	}


    Home()
    {

    }
}
