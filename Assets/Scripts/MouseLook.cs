using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum rotationAxis
    {
        mouseXandY = 0,
        mouseX = 1,
        mouseY = 2
    }

    public bl_Joystick joyC;

    public rotationAxis axis = rotationAxis.mouseXandY;
    public float sensitivityHoriz = 7.0f;
    public float sensitivityVert = 7.0f;

    Vector3 current_position = Vector3.zero;

    public FPSInput check;

    



    public float minimumVert = -75f;
    public float maximumVert = 75f;

    private float _rotationX = 0f;

    private void Start()
    {
        
        Rigidbody body = GetComponent<Rigidbody>();

        if(body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if(axis == rotationAxis.mouseX)
        {

            if (check.isMobile)
            {
                transform.Rotate(0, joyC.Horizontal * 0.2f, 0);
            }
            else
            {
                joyC.gameObject.SetActive(false);
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHoriz, 0);
            }

        } else if (axis == rotationAxis.mouseY)
        {
            if(check.isMobile)
            {
                _rotationX -= joyC.Vertical * 0.2f;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            } else
            {
                

            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }

        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHoriz;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0 );

        }
    }
}
