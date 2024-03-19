using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPower0 : MonoBehaviour
{
    public int powerlevel =100; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitByAbsorber()
    {
        powerlevel = powerlevel - 5;
    }
}
