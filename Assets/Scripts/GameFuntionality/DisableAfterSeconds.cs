using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    [SerializeField]
    float destroyAfterXSeconds;
    float timer;

    private void OnEnable()
    {
        timer = Time.time;
    }
    private void Update()
    {
        if(Time.time - timer > destroyAfterXSeconds)
        {
            Destroy(gameObject);
        }
    }
}
