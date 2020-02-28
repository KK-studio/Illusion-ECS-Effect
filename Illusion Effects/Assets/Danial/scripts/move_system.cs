using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class move_system : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref move_component myMove, ref Translation translation) =>
        {
            if (myMove.active)
            {
                if (translation.Value.y - myMove.maxPos > 0 && myMove.dir == 1)
                {

                    myMove.dir = -myMove.dir;
                    myMove.active = Random.Range(0, 1000) < 800;
                }
                else if (translation.Value.y + myMove.maxPos < 0 && myMove.dir == -1)
                {

                    myMove.dir = -myMove.dir;
                    myMove.active = Random.Range(0, 1000) < 800;
                }
                else if(myMove.time_to_be_active > 0.25f)
                {
                    myMove.active = Random.Range(0, 1000) < 950;
                    myMove.time_to_be_active = 0;
                }
                myMove.time_to_be_active += Time.DeltaTime;

                translation.Value.y += myMove.dir * Time.DeltaTime;
            }
            else
            {
                myMove.time_to_be_active += Time.DeltaTime;
                if (myMove.time_to_be_active > 0.25f)
                {
                    myMove.active = Random.Range(0, 1000) < 200;
                    myMove.time_to_be_active = 0;
                }


 
            }

        });
    }
}
