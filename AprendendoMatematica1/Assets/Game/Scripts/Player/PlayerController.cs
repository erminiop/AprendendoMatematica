using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof (PlayerInput))]
public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;

    public Sprite crouchedSprite;
    public Sprite idleSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        var w = GamesCodeDataSource.Instance.JogadorDAO.getJogador(1);
        print(w.Nome_jogador);
    }

    // Update is called once per frame
    void Update()
    {
        //movimenta jogador na horizontal
        Vector2 movimentInput = playerInput.getMovimentInput();
        playerMovement.ProcessMovementInput(movimentInput);

        if(movimentInput.x > 0)
        {
            //Virar player para direita
            spriteRenderer.flipX = false;
        }
        else if(movimentInput.x < 0)
        {
            //virar player para esquerda
            spriteRenderer.flipX = true;
        }

        //Pulo
        if (playerInput.IsJumpBottonDown())
        {
            playerMovement.Jump();
        }
        if (playerInput.IsJumpBottonHeld()==false)
        {
            playerMovement.UpdateJumpAbort();
        }

        //Agachar
        if (playerInput.IsCrouchBottonDown())
        {
            playerMovement.Crouch();

            spriteRenderer.sprite = crouchedSprite;
        } else if (playerInput.IsCrouchBottonUP())
        {
            playerMovement.UnCrouch();

            spriteRenderer.sprite = idleSprite;
        }
      
    }

}
