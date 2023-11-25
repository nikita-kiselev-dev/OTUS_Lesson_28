using System.Collections;
using UnityEngine;

namespace Sample
{
    public interface IWeapon
    {
        public void Shoot(Vector3 direction);
        public void FixedUpdate();
    }
}