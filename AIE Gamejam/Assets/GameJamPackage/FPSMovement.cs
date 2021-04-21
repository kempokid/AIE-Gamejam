using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This player move class will allow the gameobject to move based on CharacterController
 */

public class FPSMovement : MonoBehaviour
{
    //VARS
    public CharacterController m_charController;
    public float m_movementSpeed = 12f;
    public float m_runSpeed = 1.5f;

    public float m_gravity = -9.81f;
    public float m_jumpHeight = 3f;
    private Vector3 m_velocity;

    public Transform m_groundCheckPoint;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;
    private bool m_isGrounded;
    private int extraJumps;
    public int extraJumpsValue;

    public KeyCode m_forward;
    public KeyCode m_backward;
    public KeyCode m_right;
    public KeyCode m_left;
    public KeyCode m_sprint;
    public KeyCode m_jump;

    private float m_finalSpeed = 0;

    // Start is called before the first frame update
    void Awake()
    {
        m_finalSpeed = m_movementSpeed;
        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = HitGroundCheck(); //Checks touching the ground every frame
        MoveInputCheck(); //Check movement input

        if (m_isGrounded == true)
        {
            extraJumps = extraJumpsValue;

        }

    }
        
    //check if a button is presssed
        void MoveInputCheck()
        {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.zero; 
                
                if (Input.GetKey(m_forward)  || Input.GetKey(m_backward) || Input.GetKey(m_left) || (Input.GetKey(m_right)))
                {
                    move = transform.right * x + transform.forward * z;
                 
                }
        MovePlayer(move);
        Runcheck(); //Checks the input for run
        JumpCheck();//Checks if we can jump
    }


    //MovePlayer
    void MovePlayer(Vector3 move)
    {
        m_charController.Move(move * m_finalSpeed * Time.deltaTime);
        m_velocity.y += m_gravity * Time.deltaTime; //Gravity affects the jump velocity
        m_charController.Move(m_velocity * Time.deltaTime); //Actually move the player up
    }
    

    // Player run
    void Runcheck()
    {

        if (Input.GetKeyDown(m_sprint))
        {
            m_finalSpeed = m_finalSpeed * m_runSpeed;
        }
        else if (Input.GetKeyUp(m_sprint))
        {
            m_finalSpeed = m_movementSpeed;
        }

    }

    bool HitGroundCheck()
    {
        bool isGrounded = Physics.CheckSphere(m_groundCheckPoint.position, m_groundDistance, m_groundMask);

        //Gravity
        if(isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }

        return isGrounded;
    }

    //Jump Check
    void JumpCheck()
    {
        if (Input.GetKeyDown(m_jump) && extraJumps > 0)
        {
            extraJumps--;
            m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            
        }
        else if (m_isGrounded == true && extraJumps == 0 && Input.GetKeyDown(m_jump))
        {
            m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
        }
    }
}
