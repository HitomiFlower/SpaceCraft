using System;
using Unity.Entities;

namespace ECS
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float value;
    }

    public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed>
    {
    }
}

