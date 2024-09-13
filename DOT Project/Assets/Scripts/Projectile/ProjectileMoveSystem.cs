using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct ProjectileMoveSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (transform, moveSpeed, projectileScale) in SystemAPI.Query<RefRW<LocalTransform>, ProjectileMoveSpeed, ProjectileScale>())
        {
            transform.ValueRW.Position += transform.ValueRO.Up() * moveSpeed.Value * deltaTime;
            transform.ValueRW.Scale = projectileScale.Value;
        }
    }
}
