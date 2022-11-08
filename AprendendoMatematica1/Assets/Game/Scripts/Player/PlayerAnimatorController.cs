using UnityEngine;
using Platformer2D.Character;

public static class CharacterMovementAnimationKeys
{
    public const string isCrouching = "isCrouching";
    public const string walkSpeed = "horizontalSpeed";
    public const string jumpSpeed = "verticalSpeed";
    public const string inFloor = "inFloor";
    public const string dead = "Dead";
}

[RequireComponent(typeof(IDamageble))]
public class PlayerAnimatorController : MonoBehaviour
{
    Animator animator;
    CharacterMovement2D playerMovement;
    IDamageble damageble;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<CharacterMovement2D>();
        damageble = GetComponent<IDamageble>();
        damageble.DeathEvent += OnDeath;

    }

    private void Update()
    {
        animator.SetBool(CharacterMovementAnimationKeys.isCrouching, playerMovement.IsCrouching);
        animator.SetFloat(CharacterMovementAnimationKeys.walkSpeed, playerMovement.CurrentVelocity.x / playerMovement.MaxGroundSpeed);
        animator.SetFloat(CharacterMovementAnimationKeys.jumpSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.inFloor, playerMovement.IsGrounded);

    }

    private void OnDeath()
    {
        animator.SetTrigger(CharacterMovementAnimationKeys.dead);
    }
    private void OnDestroy()
    {
        damageble.DeathEvent -= OnDeath;
    }
}
