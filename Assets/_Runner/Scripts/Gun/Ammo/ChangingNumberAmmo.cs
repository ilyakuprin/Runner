using System;
using MainHero;
using ScriptableObj;
using Zenject;

namespace Gun
{
    public class ChangingNumberAmmo : IInitializable, IDisposable, IIsShotable
    {
        public event Action<int> Changed; 
        
        private const int MinCountAmmo = 0;
        
        private readonly Shooting _shooting;
        
        private int _currentCountAmmo;

        public ChangingNumberAmmo(GunConfig gunConfig,
                                  Shooting shooting)
        {
            MaxNumberAmmo = gunConfig.MaxAmmo;
            _currentCountAmmo = gunConfig.StartAmmo;

            _shooting = shooting;
        }
        
        public int MaxNumberAmmo { get; }

        public void Initialize()
        {
            _shooting.AddIsCanShot(this);

            _shooting.Shot += Reduce;
        }

        public void Dispose()
            => _shooting.Shot -= Reduce;

        public bool IsCanShot()
            => _currentCountAmmo > MinCountAmmo;

        private void Reduce()
        {
            if (_currentCountAmmo > MinCountAmmo)
            {
                _currentCountAmmo--;
                Changed?.Invoke(_currentCountAmmo);
            }
        }

        private void Add()
        {
            if (_currentCountAmmo < MaxNumberAmmo)
            {
                _currentCountAmmo++;
                Changed?.Invoke(_currentCountAmmo);
            }
        }
    }
}