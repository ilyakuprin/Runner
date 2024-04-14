using UnityEngine;

namespace StringValues
{
    public class LayerCaching
    {
        private const string ObstacleName = "Obstacle";
        private const string TrajectoryChangeBlockName = "TrajectoryChangeBlock";
        private const string BoostName = "Boost";
        
        public static int TrajectoryChangeBlock => LayerMask.NameToLayer(TrajectoryChangeBlockName);
        public static int Obstacle => LayerMask.NameToLayer(ObstacleName);
        public static int Boost => LayerMask.NameToLayer(BoostName);
        
        public static int ObstacleMask => LayerMask.GetMask(ObstacleName);
    }
}