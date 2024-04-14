using UnityEngine;
using Random = UnityEngine.Random;

namespace Block.Obstacle
{
    public class SettingRandomPosition : MonoBehaviour
    {
        [SerializeField] private Transform _wall;
        [SerializeField] private Transform[] _positions;

        private void OnEnable()
        {
            var randomIndex = Random.Range(0, _positions.Length);
            _wall.position = _positions[randomIndex].position;
        }
    }
}