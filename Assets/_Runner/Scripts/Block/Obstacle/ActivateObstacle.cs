using UnityEngine;

namespace Block.Obstacle
{
    public class ActivateObstacle : MonoBehaviour
    {
        [SerializeField] private GameObject _wall;
        
        private void OnEnable()
        {
            if (!_wall.activeInHierarchy)
                _wall.SetActive(true);
        }
    }
}