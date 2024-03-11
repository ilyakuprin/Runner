using System;
using Boosts;
using Road;
using ScriptableObj;
using Zenject;

namespace Block
{
    public class BlockState : IInitializable, IDisposable
    {
        private readonly CreatingRoad _creatingRoad;
        private readonly ChangingParentRoadRotation _changingParentRoadRotation;
        private readonly RoadConfig _roadConfig;
        private readonly CreatingBoost _creatingBoost;

        private int _counterObstacles;
        private int _counterBlocksAfterRotateBlock;
        private bool _isRotateBlockOnRoad;

        public BlockState(CreatingRoad creatingRoad,
                          ChangingParentRoadRotation changingParentRoadRotation,
                          RoadConfig roadConfig,
                          CreatingBoost creatingBoost)
        {
            _creatingRoad = creatingRoad;
            _changingParentRoadRotation = changingParentRoadRotation;
            _roadConfig = roadConfig;
            _creatingBoost = creatingBoost;
        }

        public void Initialize()
        {
            _creatingRoad.Created += State;
        }

        public void Dispose()
        {
            _creatingRoad.Created -= State;
        }

        private void State(BlockView block)
        {
            ActivateCanRotate();

            var nameBlock = block.GetNameBlock;
            if (nameBlock == EnumNameBlock.Empty)
            {
                _creatingBoost.Create(block);
            }
            else if (IsRotateBlock(nameBlock))
            {
                _isRotateBlockOnRoad = true;

                _changingParentRoadRotation.Change(block);
                _creatingRoad.SetIsCanRotate(false);
            }
            else
            {
                _counterObstacles++;

                if (_counterObstacles >= _roadConfig.NumberAllBlocks)
                    _creatingRoad.Dispose();
            }
        }

        private void ActivateCanRotate()
        {
            if (!_isRotateBlockOnRoad) return;

            _counterBlocksAfterRotateBlock++;

            if (_counterBlocksAfterRotateBlock != _roadConfig.NumberVisibleBlocks) return;

            _creatingRoad.SetIsCanRotate(true);
            _isRotateBlockOnRoad = false;
            _counterBlocksAfterRotateBlock = 0;
        }

        private static bool IsRotateBlock(EnumNameBlock nameBlock)
            => nameBlock == EnumNameBlock.Left ||
               nameBlock == EnumNameBlock.Right;
    }
}
