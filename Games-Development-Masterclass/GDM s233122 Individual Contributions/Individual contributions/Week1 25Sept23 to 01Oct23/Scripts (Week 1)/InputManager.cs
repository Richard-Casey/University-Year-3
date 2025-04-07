/* SCRIPT ORIGINALLY ADAM BAKERS - WILL COMMENT MY CHANGES TO SHOW CONTRIBUTIONS */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{


    #region Events

    public static UnityEvent Interaction = new UnityEvent();

    #endregion

    //public Texture2D CrosshairTexture;

    public Vector2 MouseInputDelta { private set; get; }
    public Vector2 MousePositionOnScreen { private set; get; }
    public Vector2 MoveInput { private set; get; }
    public bool ConfineMouseInput { private set; get; }
    public bool IsSprining { private set; get; }
    public bool IsJumping { private set; get; }
    public bool IsKneel { private set; get; }
    public bool IsCrouch { private set; get; }
    public float RotateInput { private set; get; }
    public float InOutInput { private set; get; }
    public bool isInteract { private set; get; }
    public bool isAttack1 { private set; get; }
    public bool isAttack2 { private set; get; }
    #region Attack

    //void OnAttack1(InputValue value) => SetAttack1(value.isPressed);

    private void SetAttack1(bool value)
    {
        isAttack1 = value;
    }

    //void OnAttack2(InputValue value) => SetAttack2(value.isPressed);

    private void SetAttack2(bool value)
    {
        isAttack2 = value;
    }

                                                                                                                    //RCASEY CONTRIBUTION TO SCRIPT
    void OnAttack1(InputValue value)                                                                                //RCASEY CONTRIBUTION TO SCRIPT
    {                                                                                                               //RCASEY CONTRIBUTION TO SCRIPT
        isAttack1 = value.isPressed;                                                                                //RCASEY CONTRIBUTION TO SCRIPT
        if (value.isPressed)                                                                                        //RCASEY CONTRIBUTION TO SCRIPT
        {                                                                                                           //RCASEY CONTRIBUTION TO SCRIPT
            AbilityType ability = GameManager.Instance.GetAbilitiesForClass(GameManager.Instance.playerClass).Item1;//RCASEY CONTRIBUTION TO SCRIPT
            AbilityManager.Instance.ActivateAbility(ability, this.gameObject);                                      //RCASEY CONTRIBUTION TO SCRIPT
        }                                                                                                           //RCASEY CONTRIBUTION TO SCRIPT
    }                                                                                                               //RCASEY CONTRIBUTION TO SCRIPT
                                                                                                                    //RCASEY CONTRIBUTION TO SCRIPT
                                                                                                                    //RCASEY CONTRIBUTION TO SCRIPT
    void OnAttack2(InputValue value)                                                                                //RCASEY CONTRIBUTION TO SCRIPT
    {                                                                                                               //RCASEY CONTRIBUTION TO SCRIPT
        SetAttack2(value.isPressed);                                                                                //RCASEY CONTRIBUTION TO SCRIPT
        if (value.isPressed)                                                                                        //RCASEY CONTRIBUTION TO SCRIPT
        {                                                                                                           //RCASEY CONTRIBUTION TO SCRIPT
            AbilityType ability = GameManager.Instance.GetAbilitiesForClass(GameManager.Instance.playerClass).Item2;//RCASEY CONTRIBUTION TO SCRIPT
            AbilityManager.Instance.ActivateAbility(ability, this.gameObject);                                      //RCASEY CONTRIBUTION TO SCRIPT
        }                                                                                                           //RCASEY CONTRIBUTION TO SCRIPT
    }                                                                                                               //RCASEY CONTRIBUTION TO SCRIPT
                                                                                                                    //RCASEY CONTRIBUTION TO SCRIPT

    void OnInteract(InputValue value) => SetInteract(value.isPressed);

    private void SetInteract(bool value)

    void Update()
    {
        //Debug.Log(isInteract);
    }

    #endregion

    #region Focus
    private void OnApplicationFocus(bool hasFocus) => SetCursorState(false);
    private void OnApplicationPause() => SetCursorState(true);

    private void SetCursorState(bool newState)
    {
        ConfineMouseInput = newState;
        Cursor.lockState = newState ? CursorLockMode.None : CursorLockMode.Confined;
        //Cursor.SetCursor(CrosshairTexture, new Vector2(CrosshairTexture.width/2f, CrosshairTexture.height/2f),CursorMode.Auto);
    }

    #endregion

    #region Move
    void OnMove(InputValue value) => SetNewMoveInput(value.Get<Vector2>());
    private void SetNewMoveInput(Vector2 newMoveInput)
    {
        MoveInput = newMoveInput;
    }