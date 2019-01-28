using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    //Value type variables
    public float moveSpeed;
    public float damage;
    public Vector2 moveDir;
    public LayerMask bodMask;
    public LayerMask keyMask;

    //Reference type variables
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rb.velocity = moveSpeed * moveDir;
    }
    public void SetDamage(float amount)
    {
        damage = amount;
    }
}
