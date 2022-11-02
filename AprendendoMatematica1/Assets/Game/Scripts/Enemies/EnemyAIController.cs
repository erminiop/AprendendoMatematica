using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
public class EnemyAIController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    Vector2 movementInput;
    Transform flip;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        StartCoroutine(walk());
        flip = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);   
    }

    IEnumerator walk()
    {
        bool walkingLeft = true;
        while (true)
        {
            if (walkingLeft)
            {
                movementInput.x = -1;
                yield return new WaitForSeconds(3.0f);
                movementInput.x = 0;
                yield return new WaitForSeconds(2.0f);
                walkingLeft = false;
                flip.localScale = new Vector3(flip.localScale.x * -1, flip.localScale.y, flip.localScale.z);
            }
            else
            {
                
                movementInput.x = 1;
                yield return new WaitForSeconds(3.0f);
                movementInput.x = 0;
                yield return new WaitForSeconds(2.0f);
                walkingLeft = true;
                flip.localScale = new Vector3(flip.localScale.x * -1, flip.localScale.y, flip.localScale.z);
            }
          
            
            

        }

    }
}
