using System;
using UnityEngine;

public class SeeThrough:MonoBehaviour
{
    public GameObject player;
    private WallProperty WallTarget;

    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        float length = Vector3.Distance(player.transform.position, transform.position); 
        Debug.DrawRay(transform.position, direction * length, Color.red);
        RaycastHit RayObject;

        if (Physics.Raycast(transform.position, direction, out RayObject, length, LayerMask.GetMask("Wall")))
        {
            /* TODO: fix  
            WallProperty NewTransparentWall = RayObject.transform.GetComponent("???");   
            if (NewTransparentWall)
            {  
                if (WallTarget && WallTarget.gameObject != NewTransparentWall.gameObject)
                {                    
                    WallTarget.ChangeTransparency(false);
                }                
                NewTransparentWall.ChangeTransparency(true);
                WallTarget = NewTransparentWall;
            }*/
        }
        else
        {
            if (WallTarget)
            {
                WallTarget.ChangeTransparency(false);
            }
        }
    }
}
