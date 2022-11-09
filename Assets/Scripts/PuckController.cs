using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PuckController : Agent
{

    public Transform ball;
    public BallMovement ballMovement;
    public float puckSpeed = 0;

    public float ballSpeed, lastBallXPosition;

    private Vector3 targetPosition;
    public bool isPuck2 = false;


    private void Awake() 
    { 
        targetPosition = transform.position;
    }
    public override void OnEpisodeBegin()
    {
        ballMovement.Reset();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((ball.position.x - transform.position.x) / 4.58f); //The difference between the puck and ball's x position divided by 2.29 to normalize the value between -1 and 1.
        
        if(isPuck2){
            sensor.AddObservation((ball.position.y - transform.position.y) / 8.41f); //The difference between the puck and ball's y position substracted 4.9 and divided by 9.2 to normalize the value between -1 and 1.
        } else {
            sensor.AddObservation((transform.position.y - ball.position.y) / 8.41f); //The difference between the puck and ball's y position substracted 4.9 and divided by 9.2 to normalize the value between -1 and 1.
        }  

        sensor.AddObservation(ballSpeed); //Speed of the ball as m/s

        sensor.AddObservation((2.29f - ball.position.x) < 0.22f); //Bool if the agent close to the wall to make it learn bouncing of the ball from the wall.

        sensor.AddObservation((-2.29f - ball.position.x) > -0.22f); //Bool if the agent close to the wall to make it learn bouncing of the ball from the wall.
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        puckSpeed = actionBuffers.ContinuousActions[0];
    }

    private void FixedUpdate(){
        if(targetPosition.x <= -2.29f && puckSpeed > 0 || targetPosition.x >= 2.29f && puckSpeed < 0 || Mathf.Abs(targetPosition.x) < 2.29f){ //Making sure that the puck is between boundaries
            targetPosition += new Vector3(puckSpeed * Time.fixedDeltaTime * 20f, 0, 0);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 14); //Lerping puck to the desired position
        ballSpeed = ball.position.x - lastBallXPosition;
        lastBallXPosition = ball.position.x;

        AddReward(0.02f * (0.25f - Mathf.Abs(puckSpeed))); //Rewarding the agent for going slow since we want to make sure that agent stop whenever it is not required to move.
    }

    public void End(){
        puckSpeed = 0;
        EndEpisode(); 
    }

    public void BadEnd(){
        SetReward(-2); //Setting reward as -2 whenever the agent loses.

        End();
    }

    public void AddRew(float rev){
        AddReward(rev / 90 + 0.2f); //Adding reward
    }
}

