using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Inputting;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class MovingLeftRight : IInitializable, IDisposable, IExecutive
    {
        private const int Leftmost = -1;
        private const int Rightmost = 1;
        private const float ZeroError = 0.1f;
        
        private readonly CharacterController _characterController;
        private readonly PlayerInput _playerInput;
        private readonly MainHeroStatConfig _mainHeroStat;
        
        private int _currentSegment = 0;
        private CancellationToken _ct;
        private bool _isMoved;
        private Vector3 _directionMotion;

        public MovingLeftRight(MainHeroView mainHeroView,
                               PlayerInput playerInput,
                               MainHeroStatConfig mainHeroStat)
        {
            _characterController = mainHeroView.HeroController;
            _playerInput = playerInput;
            _mainHeroStat = mainHeroStat;
        }
        
        public void Execute(InputData inputData)
        {
            if (!inputData.IsHorizontalPressDown) return;
            
            if (inputData.Horizontal > 0 && _currentSegment < Rightmost)
            {
                _currentSegment++;
                _directionMotion = new Vector3(_mainHeroStat.OffsetToSide, 0, 0);
                
                if (!_isMoved)
                    Move().Forget();
            }
            else if (inputData.Horizontal < 0 && _currentSegment > Leftmost)
            {
                _currentSegment--;
                _directionMotion = new Vector3(-_mainHeroStat.OffsetToSide, 0, 0);
                
                if (!_isMoved)
                    Move().Forget();
            }
        }
        
        public void Initialize()
        {
            _ct = _characterController.GetCancellationTokenOnDestroy();
            _playerInput.Inputted += Execute;
        }
        
        public void Dispose()
        {
            _playerInput.Inputted -= Execute;
        }

        private async UniTask Move()
        {
            _isMoved = true;
            
            while (!IsReachedTargetPosition())
            {
                _characterController.Move(_directionMotion * (Time.deltaTime * _mainHeroStat.HorizontalSpeed));
                await UniTask.WaitForFixedUpdate(_ct);
            }

            var targetPosition = _directionMotion;
            targetPosition.x = GetTargetPositionX();
            _characterController.transform.position = targetPosition;
            
            _isMoved = false;
        }

        private bool IsReachedTargetPosition()
            => IsZero(_characterController.transform.position.x - GetTargetPositionX());

        private float GetTargetPositionX()
        {
            var segmentAbs = _currentSegment < 0 ? -_currentSegment : _currentSegment;
            return _directionMotion.x * segmentAbs;
        }

        private static bool IsZero(float difference)
            => difference <= ZeroError && difference >= -ZeroError;
    }
}