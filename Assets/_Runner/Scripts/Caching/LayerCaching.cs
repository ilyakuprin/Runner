using UnityEngine;
using Zenject;

namespace Caching
{
    public class LayerCaching : IInitializable
    {
        private const string NameTrajectoryChangeBlock = "TrajectoryChangeBlock";
        private const string NameObstacle = "Obstacle";

        public int TrajectoryChangeBlock { get; private set; }
        public int Obstacle { get; private set; }

        public void Initialize()
        {
            TrajectoryChangeBlock = LayerMask.NameToLayer(NameTrajectoryChangeBlock);
            Obstacle = LayerMask.NameToLayer(NameObstacle);
        }
    }
}