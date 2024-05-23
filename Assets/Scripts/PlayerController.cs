using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private Vector3 rotationVector;
    private float gravity; 
    bool isGrounded;
    [SerializeField] private float movePower = 5f;
    [SerializeField] private float rotationPower = 2f;

    private float horizontal = 0.0f;
    private float vertical = 0.0f;
    private new Camera camera;
    private Glasses glasses;
    private bool glassesOn = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        camera = GetComponentInChildren<Camera>();
        glasses = GetComponentInChildren<Glasses>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!glassesOn)
            {
                glasses.PutOnGlasses();
                glassesOn = true;
            }
            else
            {
                glasses.TakeOffGlasses();
                glassesOn = false;
            }
            //glassesOn = !glassesOn ? (glasses.PutOnGlasses(), true) : (glasses.TakeOffGlasses(), false);
        }
        
        isGrounded = controller.isGrounded;
        if (!isGrounded)
        {
            gravity -= 9f * Time.deltaTime;
        }
        else 
        {
            gravity = 0;
        }
                        
        moveVector = new Vector3(Input.GetAxis("Horizontal"), gravity, Input.GetAxis("Vertical"));
        moveVector = transform.TransformDirection(moveVector);
        controller.Move(moveVector * movePower * Time.deltaTime);
            
        // rotationVector = new Vector3(0, Input.GetAxis("Mouse X") * rotationPower * Time.deltaTime, 0);
        // transform.Rotate(rotationVector);
        
        // horizontal += rotationPower * Input.GetAxis("Mouse X") * Time.deltaTime;
        // vertical -= rotationPower * Input.GetAxis("Mouse Y") * Time.deltaTime;
        // transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);



        float mouseX = Input.GetAxis("Mouse X") * rotationPower * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationPower * Time.deltaTime;

        horizontal -= mouseY;
        horizontal = Mathf.Clamp(horizontal, -80f, 80f);

        camera.transform.localRotation = Quaternion.Euler(horizontal, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
        
        
    }
}
