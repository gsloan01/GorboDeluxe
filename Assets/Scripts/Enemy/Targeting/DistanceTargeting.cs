using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTargeting : EnemyTargeting
{

    public override void Search(float range)
    {
        currentTarget = PlayerManager.Instance.player;
        if(Vector3.Distance(currentTarget.transform.position, transform.position) < range )
        {
            //Change this to be if the new target isnt the same target
            if(currentTarget != null)
            {
                OnTargetFound_Enemy.Invoke(currentTarget);

            }
        }
    }
}
