using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    public enum CharacterState
    {
        Dead,
        Attacking,
        Moving,
    }
    CharacterState state;

    Health healthState;

    private void Awake()
    {
        healthState = GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current State for " + gameObject.name + " is: " + state);
        CheckHealth();
        switch(state)
        {
            case (CharacterState.Dead):
                gameObject.SetActive(false);
                break;
            case (CharacterState.Attacking):
                break;
            case (CharacterState.Moving):
                break;
        }
    }
    void CheckHealth()
    {
        if(healthState.CurrHealth < 0.0f)
        {
            state = CharacterState.Dead;
        }
        else
        {
            state = CharacterState.Moving;
        }
    }
}
