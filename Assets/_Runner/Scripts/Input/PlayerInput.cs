using System;
using UnityEngine;
using Zenject;

namespace Inputting
{
    public class PlayerInput : ITickable
    {
        public event Action<InputData> Inputted;
        private InputData _inputData;
        private bool _isPause;

        public void Tick()
        {
            if (_isPause) return;

            _inputData = new InputData()
            {
                Horizontal = Input.GetAxisRaw("Horizontal"),
                IsHorizontalDown = Input.GetButtonDown("Horizontal"),
                Fire = Input.GetMouseButtonDown(0)
            };

            Inputted?.Invoke(_inputData);
        }

        public void SetPause(bool value)
            => _isPause = value;
    }
}
