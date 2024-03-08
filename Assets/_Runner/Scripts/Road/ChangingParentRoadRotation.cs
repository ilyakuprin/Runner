using Block;
using UnityEngine;

namespace Road
{
    public class ChangingParentRoadRotation
    {
        private readonly Transform _road;

        public ChangingParentRoadRotation(RoadView roadView)
        {
            _road = roadView.Road;
        }

        public Quaternion Rotation { get; private set; }

        public void Change(IViewBlock rotateBlock)
        {
            var center = rotateBlock.GetStart.position;
            center.z = rotateBlock.GetEnd.position.z;
            ChangePositionRoad(center);

            Rotation = Quaternion.Euler(rotateBlock.GetEnd.rotation.eulerAngles * -1);
        }

        private void ChangePositionRoad(Vector3 newPosition)
        {
            var children = new Transform[_road.childCount];
            var length = _road.childCount;

            for (var i = 0; i < length; i++)
            {
                children[i] = _road.GetChild(i);
            }

            for (var i = 0; i < length; i++)
            {
                children[i].parent = null;
            }

            _road.position = newPosition;

            for (var i = 0; i < length; i++)
            {
                children[i].parent = _road;
            }
        }
    }
}
