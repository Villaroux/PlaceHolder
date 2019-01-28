using UnityEngine;

public class CursorScript : MonoBehaviour
{
    //Value type variables

    float mouseClicks;
    
    //Reference type variables
    public Shoot shoot;
    private void Start()
    {
        //No windows cursor too be shown
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
            //Debug.Log(mouseClicks);
            CommandShoot();
 
    }

    public void ReceiveMouseInputs(float mouseClicks)
    {
        this.mouseClicks = mouseClicks;
    }

    void CommandShoot()
    {
        shoot.ShootBullet(transform.position, mouseClicks);
    }
}
