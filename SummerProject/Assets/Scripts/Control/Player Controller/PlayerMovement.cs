using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //the rotating and translation will be based off of the ships center of mass
    public GameObject centerOfMass;
    public GameObject CursorInGame;
    new Transform transform;
    Rigidbody rigid;

    CursorLockMode wantedMode;
    
    public float RollSpeed;

      //the vectors are set up for a "Left to right" way of determination (ex. Z axis.x = forwards, Z axis.y = backwards
    public Vector2 shipZ_AxisSpeed;
    public Vector2 shipY_AxisSpeed;
    public Vector2 shipX_AxisSpeed;

    //sensativity
    public Vector2 MouseSpeed;
    private Vector2 MousePosition;

    //to tell if the player's mouse is idle and if so, then dont add a rotation
    private static Vector3 prevMousePos;

    // Use this for initialization
    void Start()
    {
        transform = centerOfMass.GetComponent<Transform>();
        rigid = centerOfMass.GetComponent<Rigidbody>();
        wantedMode = CursorLockMode.Confined;
        
    }

    void FixedUpdate()
    {
        //rigid.
        UpdateMovement();
    }

    // Update is called once per frame
    void Update()
    {
        prevMousePos = MousePosition;
        GetMousePos();

        

        //updates all of the player movement
        //UpdateMovement();

    }

    void OnGUI()
    {
        UpdateCursorState();
    }

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        //makes the cursor invis when locked
        //Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void UpdateCursorState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            wantedMode = CursorLockMode.None;
        }

        SetCursorState();
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

    //                                DONT FORGET TO USE RELATIVE FORCE NOT ADDFORCE SO THE FORCES ARE BASED OFF THE LOCAL AXE
    void UpdatePosition()
    {
        // W (forwards), and S (backwards) keys for changing the Z position
        if (Input.GetKey(KeyCode.W)) { rigid.AddRelativeForce(0, 0, shipZ_AxisSpeed.x * 10 * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { rigid.AddRelativeForce(0, 0, -shipZ_AxisSpeed.y * 10 * Time.deltaTime); }

        // left_ctrl (down), and space (up) keys for changing the Y position
        if (Input.GetKey(KeyCode.LeftControl)) { rigid.AddRelativeForce(0, -shipY_AxisSpeed.y * 10 * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.Space)) { rigid.AddRelativeForce(0, shipY_AxisSpeed.x * 10 * Time.deltaTime, 0); }

        // Q (left) and E (right) keys for changing the X position
        if (Input.GetKey(KeyCode.Q)) { rigid.AddRelativeForce(-shipX_AxisSpeed.x * 10 * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.E)) { rigid.AddRelativeForce(shipX_AxisSpeed.y * 10 * Time.deltaTime, 0, 0); }
    }

    // X axis rotation
    void UpdatePitch()
    {

        // Mouse Y
        //transform.Rotate();

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

        // transform.Rotate(centerOfMass.transform.forward, RollSpeed * Time.deltaTime * 10);

        // A and D keys to roll
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddRelativeTorque(0, 0, RollSpeed * Time.deltaTime);
            //Vector3 slerpAngle = Vector3.Slerp(centerOfMass.transform.rotation.eulerAngles, targetRotate, RollSpeed);
            //centerOfMass.transform.rotation.Set(slerpAngle.x, slerpAngle.y, slerpAngle.z, 0.0f);
        }
        if (Input.GetKey(KeyCode.D)) { rigid.AddRelativeTorque(0, 0, -RollSpeed * Time.deltaTime); }

    }
    




}
