using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//[RequireComponent(typeof(Transform))]
public class Facing : MonoBehaviour
{

    public bool facingLeft =true;
    void Start()
    {
       // Transform flip = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateFacing(Vector2 movementInput, Transform flip)
    {
        if(movementInput.x > 0 && flip.localScale.x > 0)
        {
            flip.localScale = new Vector3(flip.localScale.x * -1, flip.localScale.y, flip.localScale.z);
            facingLeft = false;
            //Debug.Log("Direita");
         
        }
        else if(movementInput.x < 0 && flip.localScale.x < 0)
        {
            flip.localScale = new Vector3(flip.localScale.x * -1, flip.localScale.y, flip.localScale.z);
            facingLeft = true;
           // Debug.Log("Esquerda");
        }
    }

 
  
}
