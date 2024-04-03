using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    Vector2 moveInput;
   
    public float CurrentMoveSpeed { get
        {
            if (IsMoving)
            {
                if(IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }else
            {
                return 0;
            }
        }

    }
    [SerializeField]
    public bool _isMoving = false;
    public bool IsMoving { get
    {
            return _isMoving;

    }
        private set
        {
            
            _isMoving = value;
            animator.SetBool("isMoving", value);

        }

    }

        [SerializeField]
        public bool _isRunning = false;

      public bool IsRunning
      {

        get
        {
            return _isRunning;

        }
        set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value);
           
        }


      }

    Rigidbody2D rb;
    Animator animator;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
   
    public void FixedUpdate()
    {

        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        

    }
    public void OnRun(InputAction.CallbackContext context)
    {
        

        if (context.started)
            {

                IsRunning = true;
            

            } else if (context.canceled)

            {
            IsRunning = false;
            }
    }

               

                
            

    
}

