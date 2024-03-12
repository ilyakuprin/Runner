using UnityEngine;
using Zenject;

namespace StringValues
{
    public class LayerCaching : IInitializable
    {
        private const string NameTrajectoryChangeBlock = "TrajectoryChangeBlock";
        private const string NameObstacle = "Obstacle";
        private const string NameBoost = "Boost";

        public int TrajectoryChangeBlock { get; private set; }
        public int Obstacle { get; private set; }
        public int Boost { get; private set; }

        public void Initialize()
        {
            TrajectoryChangeBlock = LayerMask.NameToLayer(NameTrajectoryChangeBlock);
            Obstacle = LayerMask.NameToLayer(NameObstacle);
            Boost = LayerMask.NameToLayer(NameBoost);
        }
    }
}