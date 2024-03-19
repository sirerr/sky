using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpotController : MonoBehaviour
{
    bool Full = false;
    GameObject InnerPopper;
    PopperElement PopElement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("popper") && !Full)
        {
            PopElement = col.GetComponent<PopperElement>();
            InnerPopper = col.gameObject;
            PopElement.StopMoving();
            col.transform.position = transform.position;
            Full = true;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("spirit") && Full)
        {
            PopElement.EnergySpitter();
        }

    }
}
