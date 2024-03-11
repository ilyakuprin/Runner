using PoolObjects;
using UnityEngine;

namespace Boosts
{
    public class BoostView : PoolingObjectView
    {
        [SerializeField] private EnumNameBoost _nameBoost;

        public override int GetIntName => (int)_nameBoost;
    }
}
