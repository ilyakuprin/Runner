using UnityEngine;

namespace MainHero
{
    public interface ICollidable
    {
        public void Collide(GameObject gameObj);
    }
}
