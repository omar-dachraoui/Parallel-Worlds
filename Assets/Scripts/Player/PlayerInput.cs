using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event EventHandler OnJumpInputDetected;
    public event EventHandler OnSimpleAttackDetected;
    public event EventHandler OnSpecialAttackDetected;
    public event EventHandler OnMoveLeftDetected;
    public event EventHandler OnMoveRightDetected;

    string inputAxis;
    [HideInInspector] public  float horizontal;
    [SerializeField] private InputMode inputMode = InputMode.SecondPlayer;
    enum InputMode
    {
        SecondPlayer,
        Horizontal
    }

    private void Awake()
    {
        
        switch (inputMode)
        {
            case InputMode.SecondPlayer:
                inputAxis = "SecondPlayer";
                break;
            case InputMode.Horizontal:
                inputAxis = "Horizontal";
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxisRaw(inputAxis);
        
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpInputDetected?.Invoke(this, EventArgs.Empty);
            
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnSimpleAttackDetected?.Invoke(this, EventArgs.Empty);
        }
        else if(Input.GetKeyDown(KeyCode.C) )
        {
            OnSpecialAttackDetected?.Invoke(this, EventArgs.Empty);
        }

        DetectMovement();

        
    }

    private void DetectMovement()
    {
        if (horizontal < 0)
        {
            OnMoveLeftDetected?.Invoke(this, EventArgs.Empty);  // Event for left movement
        }
        else if (horizontal > 0)
        {
            OnMoveRightDetected?.Invoke(this, EventArgs.Empty); // Event for right movement
        }
    }
}
