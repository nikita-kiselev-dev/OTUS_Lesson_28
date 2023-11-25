using System.Collections;
using UnityEngine;

namespace Sample
{
    public class MortarWeapon : Weapon, IWeapon
    {
        [SerializeField] private WeaponData WeaponData;
        [SerializeField] private Transform firePoint;
        
        private bool fireRequired;
        private Vector3 fireDirection;
        private float shootReloadTime;
        
        public override void Shoot(Vector3 direction)
        {
            this.fireRequired = true;
            this.fireDirection = direction;
        }

        public void FixedUpdate()
        {
            if (!this.fireRequired)
            {
                return;
            }

            this.fireRequired = false;
            
            if (this.shootReloadTime > 0)
            {
                this.shootReloadTime -= Time.fixedDeltaTime;
                return;
            }

            var bullet = Instantiate(this.WeaponData.projectilePreafab, this.firePoint.position, Quaternion.LookRotation(this.fireDirection));
            bullet.GetComponent<Rigidbody>().velocity = this.fireDirection * 15.0f;
            this.shootReloadTime = this.WeaponData.shootCountdown;
        }
    }
}