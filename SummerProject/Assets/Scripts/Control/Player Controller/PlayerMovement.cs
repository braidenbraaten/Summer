using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //the rotating and translation will be based off of the ships center of mass
    public GameObject centerOfMass;
    public GameObject CursorInGame;

    public Vector2 shipZ_AxisSpeed;
    public Vector2 shipY_AxisSpeed;
    public Vector2 shipX_AxisSpeed;
    
    //sensativity
    public Vector2 MouseSpeed;
    private Vector2 MousePosition;

    //to tell if the player's mouse is idle and if so, then dont add a rotation
    private static Vector3 prevMousePos;

	// Use this for initialization
	void Start () {

	
	}

    void FixedUpdate()
    {
        centerOfMass.GetComponent<Rigidbody>().MoveRotation(centerOfMass.transform.localRotation);
        UpdateMovement();
    }

    // Update is called once per frame
    void Update () {
        prevMousePos = MousePosition;
        GetMousePos();

        //updates all of the player movement
        UpdateMovement();

    }


    Vector2 GetMousePos()
    {
        MousePosition.x = Input.GetAxis("Mouse X");
        MousePosition.y = Input.GetAxis("Mouse Y");
        return MousePosition;
    }

    
    void UpdateMovement()
    {
        UpdatePosition();
        UpdatePitch();
        UpdateYaw();
        UpdateRoll();
    }

    // x y z position

        //                                   NEED TO FIX ADDING FORCE IS GOING BASED OFF OF WORLD AXIE NOT LOCAL SHIP AXES
    void UpdatePosition()
    {
        // W (forwards), and S (backwards) keys for changing the Z position
        if (Input.GetKey(KeyCode.W)) { centerOfMass.GetComponent<Rigidbody>().AddForce(0, 0,  shipZ_AxisSpeed.y * 10); }
        if (Input.GetKey(KeyCode.S)) { centerOfMass.GetComponent<Rigidbody>().AddForce(0, 0, -shipZ_AxisSpeed.y * 10); }

        // left_ctrl (down), and space (up) keys for changing the Y position
        if (Input.GetKey(KeyCode.LeftControl)) { centerOfMass.GetComponent<Rigidbody>().AddForce(0,-shipY_AxisSpeed.y * 10,0); }
        if (Input.GetKey(KeyCode.Space))       { centerOfMass.GetComponent<Rigidbody>().AddForce(0, shipY_AxisSpeed.x * 10,0); }

        // Q (left) and E (right) keys for changing the X position
        if (Input.GetKey(KeyCode.Q)) { centerOfMass.GetComponent<Rigidbody>().AddForce(-shipX_AxisSpeed.x * 10,0,0); }
        if (Input.GetKey(KeyCode.E)) { centerOfMass.GetComponent<Rigidbody>().AddForce( shipX_AxisSpeed.y * 10,0,0); }
    }

    // X axis rotation
    void UpdatePitch()
    {

        // Mouse Y
        //centerOfMass.GetComponent<Transform>().Rotate();

    }

    // Y axis rotation
    void UpdateYaw()
    {
        // Mouse X

        if (prevMousePos != Input.mousePosition)
        {

        }
        
    }

    // Z axis rotation
    void UpdateRoll()
    {
        // A and D keys to roll
        if (Input.GetKeyDown(KeyCode.A)) { }
        if (Input.GetKeyDown(KeyCode.D)) { }

    }





}
