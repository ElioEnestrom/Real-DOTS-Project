using Unity.Entities;
using Unity.Transforms;

namespace Enemies
{
    public partial class EnemySystem : SystemBase
    {
        //public void OnUpdate(ref SystemState state)
        //{
        //    
        //}


        protected override void OnStartRunning()
        {
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);
        
            foreach (var (enemySpawning, transform) in SystemAPI.Query<EnemySpawning, LocalTransform>())
            {
                Entity[] newProjectile = new Entity[20];
            }

            //foreach (Entity entity in newProjectile)
            //{
            //    
            //}
        }

        protected override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}