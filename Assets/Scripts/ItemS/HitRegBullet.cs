using UnityEngine;

public class HitRegBullet : Bullet
{
    [SerializeField]
    float bulletRadius=0.1f;
    KeyTarget key;
    BodyTarget bod;
    private void Start()
    {
        CheckColliders();
    }

    void CheckColliders()
    {
        Collider2D[] bodColls = Physics2D.OverlapCircleAll(transform.position, bulletRadius,bodMask);
        Collider2D[] keyColls = Physics2D.OverlapCircleAll(transform.position, bulletRadius, keyMask);

        if(keyColls.Length > 0)
        {
            foreach(var damageable in keyColls)
            {
                damageable.GetComponent<IDamageable>().IDamageable(damage);
                return;
            }
        }
        if (bodColls.Length > 0)
        {
            foreach (var damageable in bodColls)
            {
                damageable.GetComponent<IDamageable>().IDamageable(damage);
                return;
            }
        }
    }
}
