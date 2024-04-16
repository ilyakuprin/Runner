using System.Linq;
using Inputting;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class InputingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(HandheldInput).GetInterfaces()))
                    .To<HandheldInput>().AsSingle();
            }
            else
            {
                Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(PcInput).GetInterfaces()))
                    .To<PcInput>().AsSingle();
            }
        }
    }
}
