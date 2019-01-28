using UnityEngine;

public class BodyTarget : MonoBehaviour, IDamageable
{
    Health health;

    void Start()
    {
        health = GetComponentInParent<Health>();
    }
    public void IDamageable(float amount)
    {
        health.CurrHealth -= amount;
    }
}
