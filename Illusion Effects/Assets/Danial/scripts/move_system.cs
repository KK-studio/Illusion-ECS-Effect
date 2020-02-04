using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class move_system : ComponentSystem
{
    protected override void OnUpdate()
    {
        
        Entities.ForEach((ref move_component myMove, ref Translation translation) =>
        {
            if (translation.Value.y  - myMove.maxPos  > 0 && myMove.dir == 1)
            {
                
                myMove.dir = -myMove.dir;
            }
            else if (translation.Value.y  + myMove.maxPos  < 0 && myMove.dir == -1)
            {
                
                myMove.dir = -myMove.dir;
            }

            translation.Value.y += myMove.dir*Time.DeltaTime;
            });
    }
}
