using UnityEngine;

namespace Inputting
{
    public class PcInput : PlayerInput
    {
        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Horizontal = Input.GetAxisRaw("Horizontal"),
                IsHorizontalPressDown = Input.GetButtonDown("Horizontal"),
                Fire = Input.GetMouseButtonDown(0)
            };

            return inputData;
        }
    }
}