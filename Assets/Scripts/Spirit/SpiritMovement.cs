using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{
    public List<Transform> StopSpots = new List<Transform>();
    public float MovementSpeed = 2f;
    public Transform LookSpot;
    public float FinalDistance = .3f;
  public  int CurrentSpot = 0;
    float TimeLimit = 5f;
    public enum FocusGoal {PAttack, Player, MPoints};
    public FocusGoal CurrentFocusGoal;
    public float CapturedTime;
    public List<Transform> PlayerAttackPoints = new List<Transform>();
    bool HitByPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        CapturedTime = Time.time;
    }

    public void SimpleMoveAround()
    {

        float dis = Vector3.Distance(transform.position, StopSpots[CurrentSpot].position);


        //  transform.LookAt(LookSpot);
        transform.position = Vector3.MoveTowards(transform.position, StopSpots[CurrentSpot].position, Time.deltaTime * MovementSpeed);


        float currentTime = Time.time;
        if ((currentTime - CapturedTime) > TimeLimit && dis < FinalDistance)
        {
            CapturedTime = Time.time;
            CurrentSpot = Random.Range(0, StopSpots.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentFocusGoal)
        {
            case FocusGoal.MPoints:
                SimpleMoveAround();

                break;

            case FocusGoal.PAttack:
               // MoveToAttacks();
                break;

            case FocusGoal.Player:
                CapturedByPlayer();
                break;

        }


    }

    public void CapturedByPlayer()
    {
        if(!HitByPlayer)
        {

            HitByPlayer = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      //  print("hit "+ other.name);
     //   PlayerAttackPoints.Add(other.transform);

        if(other.CompareTag("popper"))
        {
            PopperElement element = other.GetComponentInParent<PopperElement>();
            element.StartLifeCounter();
            element.spot = transform;
        }
        
       // CurrentFocusGoal = FocusGoal.PAttack;
        //if (CurrentFocusGoal == FocusGoal.PAttack && PlayerAttackPoints.Count >0)
        //{
        //     foreach(Transform spot in PlayerAttackPoints)
        //    {

        //    }
        //}
    }

    public void MoveToAttacks()
    {
        // float dis = Vector3.Distance(transform.position, PlayerAttackPoints[CurrentSpot].position);



        //  transform.LookAt(LookSpot);
        if (PlayerAttackPoints.Count > 0 )
            transform.position = Vector3.MoveTowards(transform.position, PlayerAttackPoints[0].position, Time.deltaTime * MovementSpeed);
        else
            CurrentFocusGoal = FocusGoal.MPoints;
    }
}
