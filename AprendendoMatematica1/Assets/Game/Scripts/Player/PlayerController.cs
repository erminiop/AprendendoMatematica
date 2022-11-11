using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof (PlayerInput))]
[RequireComponent (typeof(IDamageble))]
public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    IDamageble damageble;
    //Variaveis usadas para teste antes da animacao
   // public Sprite crouchedSprite;
   //public Sprite idleSprite;

    [Header("Camera")]

    [SerializeField]private Transform cameraTarget;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float cameraTargetOffsetX = 2.0f;
    [Range(0.5f,50.0f)]
    [SerializeField] private float cameraTargetFlipSpeed = 5.0f;
    [Range(0.0f,5.0f)]
    [SerializeField] private float characterSpeedInfluence = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        damageble = GetComponent<IDamageble>();

        damageble.DeathEvent += OnDeath;

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

           // spriteRenderer.sprite = crouchedSprite;
        } else if (playerInput.IsCrouchBottonUP())
        {
            playerMovement.UnCrouch();

           // spriteRenderer.sprite = idleSprite;
        }
      
    }
    private void FixedUpdate()
    {
        //Controle do target da camera dependendo da direcao do sprite e da velocidade do jogador
        bool isFacingRight = spriteRenderer.flipX == false;
        float targetOffsetx = isFacingRight ? cameraTargetOffsetX : -cameraTargetOffsetX;

        //Usando Mathf.Lerp, para que camera mude acompanhe o jogador de forma propocional a velocidade Time.deltaTime * cameraTargetFlipSpeed
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetx, Time.fixedDeltaTime * cameraTargetFlipSpeed);

        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
        //
    }

    private void OnDeath()
    {
        playerMovement.StopImmediately();
        enabled = false;
        //Debug.Log("Damage");
    }

    private void OnDestroy()
    {
        if (damageble !=null)
        {
            damageble.DeathEvent -= OnDeath;
        }
    }

}
