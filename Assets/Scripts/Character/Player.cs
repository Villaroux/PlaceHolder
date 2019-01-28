using UnityEngine;

public class Player : Character
{
    // Value type variables
    Vector3 inputs;

    //Reference type variables
    public CursorScript cursor;

    private void Update()
    {
        SendToCursor();
    }

    public void ReceiveInputs(Vector3 inputs)
    {
        this.inputs = inputs;
    }

    void SendToCursor()
    {
        cursor.ReceiveMouseInputs(inputs.z);
    }
}
