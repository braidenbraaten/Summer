using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public GameObject playerObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * 0.1f;
        float z = Input.GetAxis("Vertical") * 0.1f;

        
        float xRotation = Input.mousePosition.normalized.y;
        Debug.Log(xRotation);
       
        playerObject.transform.Translate(x, 0, z);
        playerObject.transform.Rotate(xRotation, 0, 0);
    }
}
