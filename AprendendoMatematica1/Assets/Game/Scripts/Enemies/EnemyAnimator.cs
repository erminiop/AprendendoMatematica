using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAnimatorkey
{
    public const string state = "State";
    public const string speed = "Speed";
    public const string attack = "Attack";
}


public class EnemyAnimator : MonoBehaviour
{
   
    Animator animator;
    CharacterMovement2D enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<CharacterMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMovement != null)
        {
            if (enemyMovement.CurrentVelocity.x == 0)
            {
                animator.SetInteger(EnemyAnimatorkey.state,1);
            }else if(((enemyMovement.CurrentVelocity.x<3 && enemyMovement.CurrentVelocity.x>0)|| (enemyMovement.CurrentVelocity.x >-3) && enemyMovement.CurrentVelocity.x < 0))
            {
                //Debug.Log(enemyMovement.CurrentVelocity.x);
                animator.SetInteger(EnemyAnimatorkey.state,2);
            }
            else if ((enemyMovement.CurrentVelocity.x > 3 || enemyMovement.CurrentVelocity.x < -3))
            {
                //Debug.Log("erro " + enemyMovement.CurrentVelocity.x);
                animator.SetInteger(EnemyAnimatorkey.state,3);
            }
        }
    }

}
