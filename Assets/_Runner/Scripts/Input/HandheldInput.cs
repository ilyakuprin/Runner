using UnityEngine;

namespace Inputting
{
    public class HandheldInput : PlayerInput
    {
        private Vector2 _startTouchPosition;
        private bool _isPressDown;
        
        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Horizontal = GetSwipe(),
                IsHorizontalPressDown = _isPressDown,
                Fire = IsFire()
            };

            return inputData;
        }

        private int GetSwipe()
        {
            _isPressDown = false;
            
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    _startTouchPosition = Input.GetTouch(0).position;
                    _isPressDown = true;
                }
                else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Canceled)
                { 
                    var endTouchPosition = Input.GetTouch(0).position;

                    if (endTouchPosition.x < _startTouchPosition.x)
                    {
                        return 1;
                    }
                    else if (endTouchPosition.x > _startTouchPosition.x)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }

        private static bool IsFire()
            => Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary;
    }
}