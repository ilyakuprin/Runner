using Cysharp.Threading.Tasks;
using Inputting;
using ScriptableObj;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class JumpingMainHero : IInitializable, IDisposable, IExecutive
    {
        public event Action Jumped;

        private readonly PlayerInput _playerInput;
        private readonly MainHeroStatConfig _heroStat;
        private readonly MainHeroView _mainHeroView;

        private CancellationToken _ct;
        private bool _isFirstJump = true;
        private bool _isSecondJumpPressed;
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _startPosition;
        private float _gravityValue;

        public JumpingMainHero(PlayerInput playerInput,
                               MainHeroStatConfig mainHeroStatConfig,
                               MainHeroView mainHeroView)
        {
            _playerInput = playerInput;
            _mainHeroView = mainHeroView;
            _heroStat = mainHeroStatConfig;
        }

        public void Initialize()
        {
            _startPosition = _mainHeroView.HeroController.transform.position;
            _gravityValue = Physics.gravity.y * _heroStat.GravityScale;
            
            _ct = _mainHeroView.GetCancellationTokenOnDestroy();
            _playerInput.Inputted += Execute;
        }

        public void Dispose()
        {
            _playerInput.Inputted -= Execute;
        }

        public void Execute(InputData inputData)
        {
            if (!inputData.Jump) return;

            if (_isFirstJump)
            {
                SetVelocityY();
                _isFirstJump = false; 

                Jump().Forget();
            }
            else if (!_isSecondJumpPressed)
            {
                SetVelocityY();
                _isSecondJumpPressed = true;
                
            }
        }

        private async UniTask Jump()
        {
            while (_mainHeroView.HeroController.transform.position.y >= _startPosition.y)
            {
                _velocity.y += _gravityValue * Time.deltaTime;
                _mainHeroView.HeroController.Move(_velocity * Time.deltaTime);

                await UniTask.NextFrame(_ct);
            }

            _mainHeroView.HeroController.transform.position = _startPosition;

            ResetParameters();
        }

        private void SetVelocityY()
        {
            _velocity.y = Mathf.Sqrt(_heroStat.JumpHeight * -2.0f * _gravityValue);
            Jumped?.Invoke();
        }

        private void ResetParameters()
        {
            _velocity.y = 0;
            _isFirstJump = true;
            _isSecondJumpPressed = false;
        }
    }
}
