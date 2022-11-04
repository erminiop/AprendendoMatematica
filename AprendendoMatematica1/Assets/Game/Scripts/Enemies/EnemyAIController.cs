using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(Facing))]
public class EnemyAIController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    public Vector2 movementInput;
    public Transform flip;
    public Animator animator;
    Facing enemyFacing;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        flip = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        enemyFacing = GetComponent<Facing>();
         
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        Debug.Log("Input"+movementInput);
        enemyFacing.updateFacing(movementInput,flip);
    }

    
}
