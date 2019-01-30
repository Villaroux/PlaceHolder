using UnityEngine;
public class Weapon : Item
{
    public Sprite weaponIcon;
    public WeaponData weaponData;
    public WeaponFiringMode.FiringMode fireMode;
    public GameObject bulletType;
    public float bulletDamage;
    [Tooltip("Bullet/min | example : 700 bpm")]
    public float fireRate;
    public float reloadDuration;
    public float chargeRate;
    public int maxAmmo;
    public int currAmmo;
    public int burstRate;
    public int burstVolley;

    public override void SelectItem()
    {
        ActiveWeapon act = FindObjectOfType<ActiveWeapon>();

        act.GetSendNewWeapon(gameObject);
    }
    private void OnValidate()
    {
        itemIcon = weaponData.weaponSprite;
        bulletType = weaponData.bulletType;
        bulletDamage = weaponData.bulletDamage;
        fireMode = weaponData.firingMode;
        fireRate = weaponData.firingRate;
        reloadDuration = weaponData.reloadDuration;
        maxAmmo = weaponData.maxAmmo;
        currAmmo = weaponData.maxAmmo;
        burstVolley = weaponData.burstVolley;
        burstRate = weaponData.burstRate;
        chargeRate = weaponData.chargeRate;
    }
    private void Start()
    {

        itemIcon = weaponData.weaponSprite;
        bulletType = weaponData.bulletType;
        bulletDamage = weaponData.bulletDamage;
        fireMode = weaponData.firingMode;
        fireRate = weaponData.firingRate;
        reloadDuration = weaponData.reloadDuration;
        maxAmmo = weaponData.maxAmmo;
        currAmmo = weaponData.maxAmmo;
        burstVolley = weaponData.burstVolley;
        burstRate = weaponData.burstRate;
        chargeRate = weaponData.chargeRate;
    }
}

