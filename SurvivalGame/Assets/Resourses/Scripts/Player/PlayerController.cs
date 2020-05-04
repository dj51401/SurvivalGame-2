using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region
    //look Variables
    public Camera fpsCamera;
    private CharacterController characterController;
    private float mouseX;
    private float mouseY;

    [Range(0.0f, 10.0f)]
    public float lookSensitivity = 1;

    //movement variables
    [SerializeField]
    private float walkSpeed = 5;

    [SerializeField]
    private float runSpeed = 8;

    private float movementSpeed = 0.0f;
    private float jumpForce = 5.0f;
    private float gravityForce = 9.807f;

    private Vector3 moveDirection;

    #endregion

    //UI
    public int maxHealth = 100;
    public int currentHealth;

    public UIHealthBar healthBar;

    void Start()
    {
        currentHealth = 10;
        healthBar.SetHealth(currentHealth);
        healthBar.SetMaxHealth(maxHealth);

        characterController = GetComponent<CharacterController>();
        fpsCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rotate();
        Movement();

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Rotate()
        {
            // get input
            mouseX += Input.GetAxisRaw("Mouse X") * lookSensitivity;
            mouseY += Input.GetAxisRaw("Mouse Y") * lookSensitivity;

            //apply input.
            transform.localRotation = Quaternion.Euler(Vector3.up * mouseX);
            fpsCamera.transform.localRotation = Quaternion.Euler(Vector3.left * mouseY);
            mouseY = Mathf.Clamp(mouseY, -90.0f, 90.0f);
        }

    void Movement()
    {
        if (characterController.isGrounded)
        {
            Vector3 forwardMovement = transform.forward * Input.GetAxisRaw("Vertical");
            Vector3 strafeMovement = transform.right * Input.GetAxisRaw("Horizontal");
            moveDirection = (forwardMovement + strafeMovement).normalized * movementSpeed;

            if (Input.GetKey(KeyCode.LeftShift)){
                movementSpeed = runSpeed;
            } else {
                movementSpeed = walkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            } 
        }
        moveDirection.y -= gravityForce * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void GiveHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }

}
