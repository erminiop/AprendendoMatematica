using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(Facing))]
public class EnemyAIController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    private Vector2 movementInput;
    Transform flip;
    Animator animator;
    Facing enemyFacing;
    
    public void setMovimentInputX(float speedX)
    {
        movementInput.x = Mathf.Clamp(speedX, -1, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        flip = GetComponent<Transform>();
        enemyFacing = GetComponent<Facing>();
         
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        //Debug.Log("Input"+movementInput);
        enemyFacing.updateFacing(movementInput,flip);
    }

    
}
