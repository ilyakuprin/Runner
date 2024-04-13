using Block;
using System;
using UI;
using Zenject;

namespace Road
{
    public class ObstacleCounting : IInitializable, IDisposable
    {
        private readonly CreatingRoad _creatingRoad;
        private int _counter;

        public ObstacleCounting(CreatingRoad creatingRoad)
        {
            _creatingRoad = creatingRoad;
        }

        public void Initialize()
            => _creatingRoad.Returned += Count;

        public void Dispose()
            => _creatingRoad.Returned -= Count;

        private void Count()
            => _counter++;
    }
}
