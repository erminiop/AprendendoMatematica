using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private GameObject target;

    [InParam("AIVision")]
    private AIVision aiVision;

    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;

    private float forgetTargetTime;
    public override bool Check()
    {
        bool isAlive = IsAlive();
        if (aiVision.IsVisible(target)&& isAlive)
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;
        }
        return Time.time < forgetTargetTime && isAlive;

        //bool teste=
        // return Vector2.Distance(gameObject.transform.position, target.transform.position) <5;
       // Debug.Log(teste);
       // return teste;
    }
    bool IsAlive()
    {
        if(target == null)
        {
            return false;
        }
        IDamageble damageble = target.GetComponent<IDamageble>();
        if (damageble != null)
        {
            return !damageble.isDead;
        }
        return true;
    }
}
