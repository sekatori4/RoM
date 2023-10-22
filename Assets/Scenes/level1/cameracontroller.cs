using System.Runtime.Serialization;
using UnityEngine;

public class cameracontroller : MonoBehaviour {
    public float panSpeed = 20f;
    public float panBoardThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
    private float xx;
    private float zz
        ;
    
    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
       xx = pos.x;
       zz = pos.z;



       
            if (Input.GetMouseButton(1))
            {
            pos.x = xx + Input.GetAxis("Mouse X");
            pos.z = zz + Input.GetAxis("Mouse Y");
        }
        






        if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBoardThickness)
         {
             pos.z -= panSpeed * Time.deltaTime;     
         }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBoardThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoardThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoardThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("space"))
        {
            pos.x = 0; pos.y = 20; pos.z = 10;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y+45, panLimit.y);



        transform.position = pos;
    }

}