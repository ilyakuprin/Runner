using System;
using Gun;
using TMPro;
using Zenject;

namespace UI
{
    public class AmmoDisplaying : IInitializable, IDisposable
    {
        private const string Format = "Bullet {0}/{1}";
        
        private readonly TextMeshProUGUI _ammo;
        private readonly ChangingNumberAmmo _changingNumberAmmo;

        public AmmoDisplaying(GameCanvasView gameCanvasView,
                              ChangingNumberAmmo changingNumberAmmo)
        {
            _ammo = gameCanvasView.Ammo;
            _changingNumberAmmo = changingNumberAmmo;
        }

        public void Initialize()
            => _changingNumberAmmo.Changed += Display;

        public void Dispose()
            => _changingNumberAmmo.Changed -= Display;

        private void Display(int numberAmmo)
            => _ammo.text = string.Format(Format, numberAmmo, _changingNumberAmmo.MaxNumberAmmo);
    }
}