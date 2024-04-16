using System;
using Zenject;

namespace Inputting
{
    public abstract class PlayerInput : ITickable
    {
        public event Action<InputData> Inputted;
        private bool _isPause;

        public void Tick()
        {
            if (_isPause) return;

            var inputData = GetInputData();

            Inputted?.Invoke(inputData);
        }
        
        protected abstract InputData GetInputData();

        public void SetPause(bool value)
            => _isPause = value;
    }
}
