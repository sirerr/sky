using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public bool HandinBox = false;
    public float MoveSpeed = 5f;
    public Rigidbody rbody;
    Vector2 Vec2;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vec2.x = Input.GetAxis("Horizontal") * MoveSpeed;
        Vec2.y = Input.GetAxis("Vertical") * MoveSpeed;

    }

    private void FixedUpdate()
    {
        if(HandinBox)
        {
            rbody.AddRelativeForce(Vec2.x, Vec2.y, 0, ForceMode.Force);
        }
        
    }
}
