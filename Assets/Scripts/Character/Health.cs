using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrHealth { get; set; }
    public float MaxHealth;
    private void Awake()
    {
        CurrHealth = MaxHealth;
    }
    
}
