using UnityEngine;

namespace Boosts
{
    public class BoostView : MonoBehaviour, IViewBoost
    {
        [SerializeField] private EnumNameBoost _nameBoost;

        public EnumNameBoost GetNameBoost => _nameBoost;
    }
}
