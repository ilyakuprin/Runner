using System;
using Zenject;

namespace Road
{
    public class ObstacleCounting : IInitializable, IDisposable
    {
        public event Action Added;
        
        private readonly CreatingRoad _creatingRoad;

        public ObstacleCounting(CreatingRoad creatingRoad)
        {
            _creatingRoad = creatingRoad;
        }
        
        public int Counter { get; private set; }

        public void Initialize()
            => _creatingRoad.Returned += Count;

        public void Dispose()
            => _creatingRoad.Returned -= Count;

        private void Count()
        {
            Counter++;
            Added?.Invoke();
        } 
    }
}
