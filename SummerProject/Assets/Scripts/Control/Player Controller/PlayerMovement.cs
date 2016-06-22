using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public GameObject playerObject;
    public Vector2 MouseSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float WKey = Input.GetAxis("Horizontal") * 0.1f;
        float SKey = Input.GetAxis("Vertical") * 0.1f;


        float xRotation = Input.GetAxis("Mouse X") * 0.1f;
        float yRotation = Input.GetAxis("Mouse Y") * 0.1f;
        Debug.Log(xRotation);
       
        playerObject.transform.Translate(WKey, 0, SKey);
        if (xRotation > Screen.width / 2)
        {
            playerObject.transform.Rotate(0, MouseSpeed.x, 0);
        }

        if (xRotation < Screen.width / 2)
        {
            playerObject.transform.Rotate(0, -MouseSpeed.x, 0);
        }



    }
}
