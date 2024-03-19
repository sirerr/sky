using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopperElement : MonoBehaviour
{
    Rigidbody rbody;
    public Transform spot;
    public float LifeTime = 5f;
    public enum PopperState { closed, open};
    public PopperState CurrentPopperState;
    float LifeCounter = 0f;
    public Transform Emitter;
    public LineRenderer LineRen;
    float StartTime = 0f;
    float EndTime = 0f;
    public float AllTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMoving()
    {
        CurrentPopperState = PopperState.open;
        rbody.velocity = Vector3.zero;
        rbody.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("spirit"))
        {
            StopMoving();
            spot = other.transform;

            SpiritPower0 power = spot.GetComponent<SpiritPower0>();
            power.HitByAbsorber();
           
            StartTime = Time.time;
        }

    }

    public void EnergySpitter()
    {
        LineRen.enabled = true;
        LineRen.SetPosition(0, transform.position);
        LineRen.SetPosition(1, Emitter.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("spirit"))
        {
            EndTime = Time.time;
            AllTime = EndTime - StartTime;
            StaffUseSystem staff = Emitter.GetComponentInParent<StaffUseSystem>();
            staff.EnergyCharge += AllTime;
            LineRen.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    IEnumerator LifeTimeCounter()
    {
        yield return new WaitForSeconds(LifeTime);
       // spot.GetComponent<SpiritMovement>().PlayerAttackPoints.Remove(transform);
        yield return new WaitForEndOfFrame();
        Destroy(transform.gameObject);
    }

    public void StartLifeCounter()
    {
      //  StartCoroutine(LifeTimeCounter());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "skylimit")
        {
            Destroy(transform.gameObject);
        }
    }
}
