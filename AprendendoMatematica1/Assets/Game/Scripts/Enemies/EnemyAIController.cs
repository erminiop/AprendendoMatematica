using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(Facing))]
[RequireComponent (typeof(IDamageble))]
public class EnemyAIController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    private Vector2 movementInput;
    Transform flip;
    Facing enemyFacing;
    IDamageble damageble;
    
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
        damageble = GetComponent<IDamageble>();
        damageble.DeathEvent += OnDeath;
        
    }
    private void OnDestroy()
    {
        if(damageble != null) { damageble.DeathEvent -= OnDeath; }
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        //Debug.Log("Input"+movementInput);
        enemyFacing.updateFacing(movementInput,flip);
    }

    private void OnDeath()
    {
        Destroy(gameObject,1.0f);

    }

    
}
