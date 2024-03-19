using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffMoveRotation : MonoBehaviour
{
    public GameObject PoleCenter;
    public Vector3 MousePos;
    public Vector3 point;
    public Camera cam;
    public float dis =.1f;
    // Start is called before the first frame update
    void Start()
    {
        PoleCenter = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
         
        point = cam.ScreenToWorldPoint(new Vector3 (MousePos.x,MousePos.y,cam.nearClipPlane + dis));
       // point.z = point.z + .5f;
        PoleCenter.transform.LookAt(point);
    }
}
