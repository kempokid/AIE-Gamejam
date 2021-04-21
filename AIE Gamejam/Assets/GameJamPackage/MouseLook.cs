using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Mouselook class will allow the GameObject to look in mouse direction
 */
public class MouseLook : MonoBehaviour
{
    float run = 10f;

    public float m_sensitivity = 100f;
    public float m_clampAngle = 90f; //limits look up rotation
    public Transform m_playerObject; // Store the player container
    public Transform m_camera; //Store the camera transform

    private Vector2 m_mousePos; //store mouse potision
    private float m_xRotation = 0f; //final loop up rotation value

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock our cursor to the centre of the screen
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos(); //get the mouseposition
        ClampUpRotation(); //clamp the look up
        LookAt(); // look at mouse position
    }

 

    //Get mouse position
    private void GetMousePos()
    {
        m_mousePos.x = Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
        m_mousePos.y = Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;

    }

    //fixRotation - means that we can clamp our look up function
    private void ClampUpRotation()
    {
        m_xRotation -= m_mousePos.y;m_xRotation = Mathf.Clamp(m_xRotation, -m_clampAngle, m_clampAngle);
    }


    //Look at mouse pos
    private void LookAt()
    {
        m_camera.transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        m_playerObject.Rotate(Vector3.up * m_mousePos.x);
    }
}
