using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public int weaponlevel;
    public float bulletDamage;
    [Tooltip("Bullets per minute : example 700 bpm")]
    public float firingRate;
    public float chargeRate;
    public float reloadDuration;
    public int burstRate;
    public int burstVolley;
    public int maxAmmo;
    public GameObject bulletType;
    public Sprite weaponSprite;
    public WeaponFiringMode.FiringMode firingMode;
    
}

