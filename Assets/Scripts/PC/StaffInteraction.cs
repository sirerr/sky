using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffInteraction : MonoBehaviour
{
    public GameObject shield;
    public GameObject Popper;
    Vector3 worldPosition;
    public Camera cam;
    public float AttackSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attacking();
        }
        


        if(Input.GetKey(KeyCode.Space))
        {
            shield.SetActive(true);
        }else
        {
            shield.SetActive(false);
        }

    }

    void Attacking()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane +.5f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = worldPosition - cam.transform.position;
        GameObject obj = Instantiate(Popper, worldPosition, Quaternion.LookRotation(dir));

        Rigidbody rbody = obj.GetComponent<Rigidbody>();
        rbody.AddForce(dir * AttackSpeed);

    }
}
