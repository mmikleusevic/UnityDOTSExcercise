using Unity.Entities;
using Unity.Transforms;

public partial struct HandleCubesSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach(RotatingMovingCubeAspect rotatingMovingCubeAspect in SystemAPI.Query<RotatingMovingCubeAspect>().WithAll<RotatingCube>())
        {
            rotatingMovingCubeAspect.MoveAndRotate(SystemAPI.Time.DeltaTime);
        }
    }
}
