using System;
using MainHero;
using UI;
using UnityEngine;
using Zenject;

namespace Road
{
    public class ShiftingRoadBack : IInitializable, IDisposable
    {
        private const float HalfPlatform = 5f;

        private readonly RoadView _roadView;
        private readonly MainHeroView _mainHeroView;
        private readonly ContinuationGameForAd _continuationGameForAd;

        private float _startDistanceBetweenPlayerRoad;

        public ShiftingRoadBack(RoadView roadView,
                                     MainHeroView mainHeroView,
                                     ContinuationGameForAd continuationGameForAd)
        {
            _roadView = roadView;
            _mainHeroView = mainHeroView;
            _continuationGameForAd = continuationGameForAd;
        }

        public void Initialize()
        {
            _startDistanceBetweenPlayerRoad =
                _roadView.Road.position.z - _mainHeroView.HeroController.transform.position.z;

            _continuationGameForAd.Continued += MoveRoadBack;
        }

        public void Dispose()
        {
            _continuationGameForAd.Continued -= MoveRoadBack;
        }

        private void MoveRoadBack()
        {
            _roadView.Road.transform.position +=
                new Vector3(0, 0, _startDistanceBetweenPlayerRoad + HalfPlatform);
        }
    }
}
