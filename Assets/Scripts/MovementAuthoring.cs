using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementAuthoring : MonoBehaviour
{

    public class Baker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            float x = UnityEngine.Random.Range(-1f, +1f);
            float y = 0;
            float z = UnityEngine.Random.Range(-1f, +1f);

            AddComponent(entity, new Movement
            {
                movementVector = new float3(x, y, z)
            });
        }
    }

}

public struct Movement : IComponentData
{
    public float3 movementVector;
}
