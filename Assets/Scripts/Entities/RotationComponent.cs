using System;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS
{
    [Serializable]
    public struct Rotation : IComponentData
    {
        public quaternion value;
    }
    public class RotationComponent : ComponentDataWrapper<Rotation>
    {
    }

}

