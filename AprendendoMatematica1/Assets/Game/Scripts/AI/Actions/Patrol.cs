using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/Patrol")]
public class Patrol : BasePrimitiveAction

{
    [InParam("AIController")]
    private EnemyAIController aiController;

    [InParam("PatrolSpeed")]
    private float patrolSpeed;

    [InParam("SpeedMovement")]
    private CharacterMovement2D speedMovement;
    public override void OnStart()
    {
        base.OnStart();
        aiController.StartCoroutine(walk());
        speedMovement.MaxGroundSpeed = patrolSpeed;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.RUNNING;
    }

    public override void OnAbort()
    {
        base.OnAbort();

        aiController.StopAllCoroutines();
    }

    IEnumerator walk()
    {
        bool walkingLeft = true;
        while (true)
        {
            //aiController.animator.SetInteger("State", 2);
            if (walkingLeft)
            {
                aiController.setMovimentInputX(-1);
                yield return new WaitForSeconds(3.0f);
                aiController.setMovimentInputX(0);
                // aiController.animator.SetInteger("State",1);
                yield return new WaitForSeconds(2.0f);
                walkingLeft = false;
               // aiController.flip.localScale = new Vector3(aiController.flip.localScale.x * -1, aiController.flip.localScale.y, aiController.flip.localScale.z);
                //aiController.animator.SetInteger("State",2);
            }
            else
            {
                aiController.setMovimentInputX(1);
                yield return new WaitForSeconds(3.0f);
                aiController.setMovimentInputX(0);
                //aiController.animator.SetInteger("State",1);
                yield return new WaitForSeconds(2.0f);
                walkingLeft = true;
                //aiController.flip.localScale = new Vector3(aiController.flip.localScale.x * -1, aiController.flip.localScale.y, aiController.flip.localScale.z) ;
                //aiController.animator.SetInteger("State",2);
            }
        }
    }
}
