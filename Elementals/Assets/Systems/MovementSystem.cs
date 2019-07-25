using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;
using UnityEngine;

public class MovementSystem : JobComponentSystem
{
    
    [BurstCompile]
    struct MovementSystemJob : IJobForEach<Translation, Race>
    {
       
        public float deltaTime;
        public float2 move;
        
        public void Execute(ref Translation translation, [ReadOnly] ref Race race)
        {
            translation.Value += new float3{ xy = move * deltaTime * race.speed};
            
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new MovementSystemJob();
        
        job.deltaTime = Time.deltaTime;

        Vector2 m = Vector2.zero;
        m.x = Input.GetAxis("Horizontal");
        m.y = Input.GetAxis("Vertical");
        m.Normalize();
        job.move = new float2(m);
        return job.Schedule(this, inputDependencies);
    }
}