using System;
using MainHero;
using Zenject;

namespace Gun
{
    public class CallingAudio : IInitializable, IDisposable
    {
        private readonly Shooting _shooting;
        private readonly GunView _gunView;

        public CallingAudio(Shooting shooting,
                            GunView gunView)
        {
            _shooting = shooting;
            _gunView = gunView;
        }

        public void Initialize()
            => _shooting.Shot += Call;

        public void Dispose()
            => _shooting.Shot -= Call;

        private void Call()
            => _gunView.Source.Play();
    }
}