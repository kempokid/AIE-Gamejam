using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutting : MonoBehaviour
{
    public Camera _cam1;
    public Camera _cam2;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _cam2.enabled = false;
            _cam1.enabled = true;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            _cam2.enabled = true;
            _cam1.enabled = false;
        }
    }
}
