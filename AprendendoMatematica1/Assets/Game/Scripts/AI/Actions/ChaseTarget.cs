using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/ChaseTarget")]
public class ChaseTarget : BasePrimitiveAction

{
    [InParam("Target")]
    private GameObject target;

    [InParam("AiContoller")]
    private EnemyAIController enemyAIController;

    [InParam("ChaseSpeed")]
    private float chaseSpeed;

    [InParam("SpeedMovement")]
    private CharacterMovement2D speedMovement;

    public override void OnStart()
    {
        base.OnStart();
        speedMovement.MaxGroundSpeed = chaseSpeed;
    }

    public override TaskStatus OnUpdate()
    {
        Vector2 toTarget = target.transform.position - enemyAIController.transform.position;
        enemyAIController.setMovimentInputX(Mathf.Sign(toTarget.x));
        //enemyAIController.animator.SetInteger("State", 3);
        return TaskStatus.RUNNING;
    }
}
