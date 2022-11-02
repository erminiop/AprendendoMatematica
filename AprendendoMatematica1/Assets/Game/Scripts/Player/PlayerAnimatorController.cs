using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public static class CharacterMovementAnimationKeys
{
    public const string isCrouching = "isCrouching";
    public const string walkSpeed = "horizontalSpeed";
    public const string jumpSpeed = "verticalSpeed";
    public const string inFloor = "inFloor";
}

public class PlayerAnimatorController : MonoBehaviour
{
    Animator animator;
    CharacterMovement2D playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<CharacterMovement2D>();
    }

    private void Update()
    {
        animator.SetBool(CharacterMovementAnimationKeys.isCrouching, playerMovement.IsCrouching);
        animator.SetFloat(CharacterMovementAnimationKeys.walkSpeed, playerMovement.CurrentVelocity.x / playerMovement.MaxGroundSpeed);
        animator.SetFloat(CharacterMovementAnimationKeys.jumpSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.inFloor, playerMovement.IsGrounded);

    }
}
