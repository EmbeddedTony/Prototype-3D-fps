using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public bool isMobile;

    public float moveSpeed = 9f;
    public float gravity = -9.8f;
    private CharacterController _characterController;


    public bl_Joystick joy;


    private void Start()
    {
        moveSpeed = 11f;
        _characterController = GetComponent<CharacterController>();
        
    }
    float moveHorizontal;
    float moveVertical;

    void Update()
    {
        Vector3 moveDir;
        

    if(isMobile)
        {
            moveHorizontal = joy.Horizontal;
            moveVertical = joy.Vertical;


        } else
        {
            joy.gameObject.SetActive(false);

            moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;

            moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        }
       

        moveDir = new Vector3(moveHorizontal, gravity, moveVertical);
        moveDir = Vector3.ClampMagnitude(moveDir, moveSpeed);
        moveDir *= Time.deltaTime;
        moveDir = transform.TransformDirection(moveDir);
        // Transforming local to Global cordinates

        _characterController.Move(moveDir);
    }
}
