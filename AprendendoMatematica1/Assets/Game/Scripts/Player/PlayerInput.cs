using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Jump = "Jump";
        public const string Vertical = "Vertical";

    }
    public Vector2 getMovimentInput()
    {
        //usando metodo GetAxisRaw para ler input da horizontal -1 para esquerda e +1 para direita
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);

        //Lendo input do celular
        if(Mathf.Approximately(horizontalInput,0.0f))
        {
            horizontalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal);
        }
        return new Vector2(horizontalInput, 0);
    }

    public bool IsJumpBottonDown()
    {
        //Retorna verdadeiro se botão foi clicado
        bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);
        return isKeyboardButtonDown || isMobileButtonDown;

    }

    public bool IsJumpBottonHeld()
    {
        bool isKeyboardButtonHeld = Input.GetKey(KeyCode.Space);
        bool isMobileButtonHeld = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);
        return isKeyboardButtonHeld || isMobileButtonHeld;
    }
   
    public bool IsCrouchBottonDown()
    {
        bool isMobileButtonDown=false;
        bool iskeyboardButtonDown = Input.GetKeyDown(KeyCode.S);
        if (CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) < 0)
        {
            isMobileButtonDown = true;
        }
        return iskeyboardButtonDown || isMobileButtonDown;
    }

    public bool IsCrouchBottonUP()
    {
        bool isKeyBoardButtonUP = Input.GetKey(KeyCode.S) == false;
        bool isMobileButtonUP = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) >= 0;
        return isKeyBoardButtonUP && isMobileButtonUP;
    }

 }
