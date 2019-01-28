using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if(cam != null)
        {
            Vector3 posi = cam.ScreenToWorldPoint(Input.mousePosition);
            posi.z = 0.0f;
            transform.position = posi;
        }
    }
}
