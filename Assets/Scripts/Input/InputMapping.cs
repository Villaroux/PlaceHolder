using UnityEngine;

public class InputMapping : MonoBehaviour
{
    public string horizontal;
    public string vertical;
    public string mouseLeftRight;
    public InputMap inputMap;
    public enum InputMap
    {
        Game,
        Menu
    }


    public Player player;

    private void Update()
    {
        switch (inputMap)
        {
            case (InputMap.Game):
                GameInputs();
                break;
            case (InputMap.Menu):
                MenuInputs();
                break;
            default:
                GameInputs();
                break;
        }
    }
    void GameInputs()
    {
        Vector3 inputs;
        inputs.x = Input.GetAxis(horizontal);
        inputs.y = Input.GetAxis(vertical);
        inputs.z = Input.GetAxisRaw("Fire1");

        player.ReceiveInputs(inputs);

        //Debug.Log(inputs);
    }
    void MenuInputs()
    {

    }
}
