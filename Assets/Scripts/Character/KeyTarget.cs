using UnityEngine;

public class KeyTarget : MonoBehaviour, IDamageable
{
    Health health;

    void Start()
    {
        health = GetComponentInParent<Health>();
    }
    public void IDamageable(float amount)
    {
        health.CurrHealth -= 2.0f* amount;
    }
}
