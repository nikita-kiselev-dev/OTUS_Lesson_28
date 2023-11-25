using System.Collections;
using UnityEngine;

namespace Sample
{
    public sealed class RifleWeapon : Weapon, IWeapon
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
            bullet.GetComponent<Rigidbody>().velocity = this.fireDirection * 10.0f;
            this.shootReloadTime = this.WeaponData.shootCountdown;

            StartCoroutine(DestroyProjectile(bullet));
        }

        public IEnumerator DestroyProjectile(Projectile projectile)
        {
            yield return new WaitForSeconds(WeaponData.projectileDestroyDelayInSeconds);
            if (projectile)
            {
                Destroy(projectile.gameObject);
            }
        }
    }
}