using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

[RequireComponent(typeof(Facing))]
[RequireComponent(typeof(Transform))]
public class AIVision : MonoBehaviour
{
    [Range(0.5f, 10f)]
    public float visionRange = 5.0f;

    [Range(0f, 360f)]
    public float visionAngle = 30f;

    private Facing facing;
    private Transform flip;

    public GameObject target;
    private void Awake()
    {
        facing = GetComponent<Facing>();
    }

    public void Update()
    {
      // Debug.Log("Visible "+ IsVisible(target));
      //  Debug.Log("Facing " + facing.facingLeft);
     //  Debug.Log(GetVisionDirection());
    }
    public bool IsVisible(GameObject target)
    {
        if(target == null)
        {
            return false;
        }
        if (Vector2.Distance(transform.position, target.transform.position) > visionRange)
        {
            return false;
        }
        Vector2 toTarget = transform.position - target.transform.position;
        Vector3 visionDirection = GetVisionDirection();
        if(Vector2.Angle(visionDirection, toTarget) > visionAngle/2)
        {
            return false;
        }

        return true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 visionDirection = GetVisionDirection();
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0,0,visionAngle/2)* -visionDirection * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle /2) * -visionDirection * visionRange);

    }

   private Vector2 GetVisionDirection()
    {
        if(facing == null)
        {
            return Vector2.right;
        }
        if (facing.facingLeft)
            {
                return Vector2.right;

            }
            else
            {
            return Vector2.left;

            }
       
     
    }
}
