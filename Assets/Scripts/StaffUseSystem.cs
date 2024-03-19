using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StaffUseSystem : MonoBehaviour
{
    public bool InHand = true;
    public OVRInput.Controller RightController;
    public OVRInput.Controller LeftController;

    public GameObject Popper;
    public Transform Emitter;
    public float AttackSpeed = 5f;
    //Ability stats
    public float EnergyCharge = 0f;
    public TMP_Text textMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InHand)
        {
            if(OVRInput.GetDown(OVRInput.Button.One,RightController))
            {
                print("pressing down");
                CreatePopper();

            }
        }

        textMesh.text = EnergyCharge.ToString("F0");
    }

    public void CreatePopper()
    {
        GameObject obj = Instantiate(Popper, Emitter.position, Quaternion.LookRotation(Emitter.forward));

        Rigidbody rbody = obj.GetComponent<Rigidbody>();
        rbody.AddForce(Emitter.forward * AttackSpeed);

        PopperElement element = obj.GetComponent<PopperElement>();
        element.Emitter = Emitter;
    }

    public void PointAtSpirit()
    {

    }
}
