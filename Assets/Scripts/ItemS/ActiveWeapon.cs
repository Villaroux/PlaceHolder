using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public GameObject weaponItem;
    Shoot shoot;

    private void Awake()
    {
        shoot = GetComponentInChildren<Shoot>();
    }
    private void Start()
    {
        Weapon weapon = weaponItem.GetComponent<Weapon>();
        if (weapon != null)
        {
            shoot.weapon = weapon;
        }
    }

    public void GetSendNewWeapon(GameObject weaponItem)
    {
        this.weaponItem = weaponItem;

        Weapon weapon = weaponItem.GetComponent<Weapon>();
        if (weapon != null)
        {
            shoot.weapon = weapon;
        }
    }
}
