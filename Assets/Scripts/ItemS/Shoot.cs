using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject bulletContainer;
    public Weapon weapon;
    float timer;

    bool CanShoot;

    public void ShootBullet(Vector2 direction, float shooting)
    {
        
        if (weapon != null)
        {
            switch (weapon.fireMode)
            {
                case (WeaponFiringMode.FiringMode.Auto):
                    if(shooting > 0.95f)
                    AutoMode(direction);
                    break;
                case (WeaponFiringMode.FiringMode.Semi):
                    if (shooting > .95f)
                    {
                        if (CanShoot)
                        {
                            SemiMode(direction);
                            CanShoot = false;
                        }
                    }
                    if (shooting < .15f)
                    {
                        CanShoot = true;
                    }
                    break;
                case (WeaponFiringMode.FiringMode.Burst):
                    //Debug.Log("Float: " + shooting + "/n" + "bool: " + CanShoot);
                    if(shooting > .95f)
                    {
                        if(CanShoot)
                        {
                            StartCoroutine(BurstMode(direction));
                        }
                    }
                    if(shooting < .15f)
                    {
                        CanShoot = true;
                    }
                    break;
                case (WeaponFiringMode.FiringMode.Charge):
                    ChargeMode(direction, shooting);
                    break;
                default:
                    AutoMode(direction);
                    break;
            }
        }

    }
    void AutoMode(Vector2 direction)
    {
        if (weapon.currAmmo > 0)
        {
            if (Time.time - timer > 60.0f / weapon.fireRate)
            {
                //Bullet Inst and changes
                var instanteBullet = Instantiate(weapon.bulletType, direction, Quaternion.identity);
                instanteBullet.transform.parent = bulletContainer.transform;
                instanteBullet.GetComponent<Bullet>().SetDamage(weapon.bulletDamage);
                
                //Weapon Changes
                weapon.currAmmo--;
                //Timer changes for FireRate
                timer = Time.time;
                //Debug.Log("CurrAmmo: " + weapon.currAmmo + "/ MaxAmmo: " + weapon.maxAmmo);
            }
        }
        else
        {
            Reload();
        }
    }
    IEnumerator BurstMode(Vector2 direction)
    {
        if (Time.time - timer > 60.0f / weapon.fireRate)
        {
            for (int i = 0; i < weapon.burstVolley; i++)
            {
                if(weapon.currAmmo > 0)
                {
                    CanShoot = false;
                    //Bullet Inst and changes
                    var instanteBullet = Instantiate(weapon.bulletType, direction, Quaternion.identity);
                    instanteBullet.transform.parent = bulletContainer.transform;
                    instanteBullet.GetComponent<Bullet>().SetDamage(weapon.bulletDamage);
                    //Weapon Changes
                    weapon.currAmmo--;
                    //Timer changes for FireRate
                    timer = Time.time;
                    //Debug.Log("CurrAmmo: " + weapon.currAmmo + "/ MaxAmmo: " + weapon.maxAmmo);
                    yield return new WaitForSeconds(60.0f / weapon.burstRate);
                }
            }
        }
    }
    void SemiMode(Vector2 direction)
    {
        if (weapon.currAmmo > 0)
        {
            if (Time.time - timer > 60.0f / weapon.fireRate)
            {
                //Bullet Inst and changes
                var instanteBullet = Instantiate(weapon.bulletType, direction, Quaternion.identity);
                instanteBullet.transform.parent = bulletContainer.transform;
                instanteBullet.GetComponent<Bullet>().SetDamage(weapon.bulletDamage);
                //Weapon Changes
                weapon.currAmmo--;
                //Timer changes for FireRate
                timer = Time.time;
                //Debug.Log("CurrAmmo: " + weapon.currAmmo + "/ MaxAmmo: " + weapon.maxAmmo);
            }
        }
        else
        {
            Reload();
        }
    }
    void ChargeMode(Vector2 direction, float shoot)
    {
        if(timer > 1 && shoot < 0.15f)
        {
            //Debug.Log(timer);
            // Fully charged and let go means fire

            //Bullet Inst and changes
            var instanteBullet = Instantiate(weapon.bulletType, direction, Quaternion.identity);
            instanteBullet.transform.parent = bulletContainer.transform;
            instanteBullet.GetComponent<Bullet>().SetDamage(weapon.bulletDamage);
            //Weapon Changes
            weapon.currAmmo--;
            timer = 0.0f;
        }
        else if(timer < 1 && shoot < 0.15f)
        {
            //Let go of button before it is charged
            timer = 0.0f;
            //Debug.Log(timer);
        }
        else
        {
            //Still charging with button pressed
            timer += weapon.chargeRate;
            //Debug.Log(timer);
        }
    }
    void Reload()
    {
        //Reload Here Best to be called by animation.
        Debug.Log("Realoading");
        weapon.currAmmo = weapon.maxAmmo;
        Debug.Log("Done");
    }
}
