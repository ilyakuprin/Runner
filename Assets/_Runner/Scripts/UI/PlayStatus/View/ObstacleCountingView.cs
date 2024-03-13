using Block;
using System;
using TMPro;
using UnityEngine;

namespace UI
{
    [Serializable]
    public struct ObstacleCount
    {
        public TextMeshProUGUI TextMeshName;
        public TextMeshProUGUI TextMeshCounter;
        public string Text;
        public EnumNameBlock NameBlockEnum;
        public int Counter;
    }

    public class ObstacleCountingView : MonoBehaviour
    {
        [SerializeField] private ObstacleCount[] _obstacleCount;

        public int GetLength
            => _obstacleCount.Length;

        public ObstacleCount GetObstacle(int index)
            => _obstacleCount[index];

        public void AddCounter(int index)
        {
            _obstacleCount[index].Counter++;
            
            var obst = GetObstacle(index);
            obst.TextMeshCounter.text = obst.Counter.ToString();
        }

        private void Awake()
        {
            for (var i = 0; i < GetLength; i++)
            {
                var obst = _obstacleCount[i];

                obst.TextMeshName.text = obst.Text;
            }
        }
    }
}
