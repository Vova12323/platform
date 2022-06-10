using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2f;
        float mouseY = Input.GetAxis("Mouse Y");

        playerBody.Rotate(0, mouseX, 0);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
    }
    
}
