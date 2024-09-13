using Unity.Entities;
using Unity.Transforms;
using UnityEngine.UIElements;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct FireProjectileSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);
        foreach (var (projectilePrefab, transform) in SystemAPI.Query<ProjectilePrefab, LocalTransform>()
                     .WithAll<FireProjectileTag>())
        {
            var newProjectile = ecb.Instantiate(projectilePrefab.Value);
            var projectileTransform = LocalTransform.FromPositionRotationScale(transform.Position, transform.Rotation, transform.Scale);
            ecb.SetComponent(newProjectile, projectileTransform);
            //ecb.SetComponent(newProjectile, projectileScale);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}