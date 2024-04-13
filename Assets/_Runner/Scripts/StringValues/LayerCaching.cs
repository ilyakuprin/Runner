using UnityEngine;

namespace StringValues
{
    public class LayerCaching
    {
        public static int TrajectoryChangeBlock => LayerMask.NameToLayer("TrajectoryChangeBlock");
        public static int Obstacle => LayerMask.NameToLayer("Obstacle");
        public static int Boost => LayerMask.NameToLayer("Boost");
    }
}