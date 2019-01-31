using UnityEngine;

public class InputMapping : MonoBehaviour
{
    public string horizontal;
    public string vertical;
    public string mouseLeftRight;
    [SerializeField]
    KeyCode InventoryKey;
    public InputMap inputMap;
    public enum InputMap
    {
        Game,
        Menu
    }

    [SerializeField]
    Player player;
    [SerializeField]
    GameObject inventoryHUD;
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
        if (Input.GetKeyDown(InventoryKey)) inventoryHUD.SetActive(!inventoryHUD.activeInHierarchy);
        //Debug.Log(inputs);
    }
    void MenuInputs()
    {

    }
}
