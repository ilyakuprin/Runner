using Block;
using System;
using UI;
using Zenject;

namespace Road
{
    public class ObstacleCounting : IInitializable, IDisposable
    {
        private readonly CreatingRoad _creatingRoad;
        private readonly ObstacleCountingView _obstacleCountingView;

        public ObstacleCounting(CreatingRoad creatingRoad,
                                ObstacleCountingView obstacleCountingView)
        {
            _creatingRoad = creatingRoad;
            _obstacleCountingView = obstacleCountingView;
        }

        public void Initialize()
        {
            _creatingRoad.Returned += Count;
        }

        public void Dispose()
        {
            _creatingRoad.Returned -= Count;
        }

        private void Count(EnumNameBlock nameBlock)
        {
            for (var i = 0; i < _obstacleCountingView.GetLength; i++)
            {
                var obst = _obstacleCountingView.GetObstacle(i);

                if (obst.NameBlockEnum == nameBlock)
                {
                    _obstacleCountingView.AddCounter(i);
                    return;
                }
            }
        }
    }
}
