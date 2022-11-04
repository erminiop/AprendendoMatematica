using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
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

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        Vector2 toTarget = target.transform.position - enemyAIController.transform.position;
        enemyAIController.movementInput.x = Mathf.Sign(toTarget.x);
        return TaskStatus.RUNNING;
    }
}
