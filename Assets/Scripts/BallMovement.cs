using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector3 speed;

    public float boundariesX, boundariesY;

    public Transform puck, puck2;
    public Vector3 puckSpeed, puckSpeed2, lastPuckPosition, lastPuckPosition2;
    public Vector3 ballSpeed, lastBallPosition;

    public float dist, lastDist;
    public float dist2, lastDist2;
    public int multiplier;
    public bool colliding, colliding2;
    private float lastCollision;

    private Vector3 defaultPosition;

    public PuckController puckController;

    public PuckController puckController2;

    private int lastHit = 0;

    private Vector3 predictedPos;
    public ScoreTable scoreTable;


    private void Start(){
        defaultPosition = transform.position;
    }

    public void Reset(){
        dist = 0;
        lastDist = 0;
        
        dist2 = 0;
        lastDist2 = 0;

        puckSpeed = Vector3.zero;
        lastPuckPosition = Vector3.zero;

        puckSpeed2 = Vector3.zero;
        lastPuckPosition2 = Vector3.zero;

        ballSpeed = Vector3.zero;
        lastBallPosition = Vector3.zero;

        if(Random.Range(0,2) == 0){
            speed = new Vector3(Random.Range(-8f,8f), Random.Range(5, 8), 0);
        } else {
            speed = new Vector3(Random.Range(-8f,8f), Random.Range(-5, -8), 0);
        }

        colliding = false;
        lastCollision = Time.time;

        transform.position = defaultPosition;
        predictedPos = defaultPosition;

        lastHit = 0;
    }

    private void FixedUpdate(){
        puckSpeed = puck.transform.position - lastPuckPosition;
        if(puck2){
            puckSpeed2 = puck2.transform.position - lastPuckPosition2;
        }
        
        ballSpeed = transform.position - lastBallPosition;

        lastPuckPosition = puck.transform.position;
        if(puck2){
            lastPuckPosition2 = puck2.transform.position;
        }
        
        lastBallPosition = transform.position;

        lastDist = dist;
        dist = Vector3.Distance(puck.transform.position, predictedPos);

        if(puck2){
            lastDist2 = dist2;
            dist2 = Vector3.Distance(puck2.transform.position, predictedPos);
        }
        predictedPos = predictedPos + speed * Time.fixedDeltaTime;

        transform.position = predictedPos;
        
        if(colliding || colliding2){
            if(dist > 0.96f){
                colliding = false;
            }
            if(dist2 > 0.96f){
                colliding2 = false;
            }
        }
    

        if(transform.position.y > boundariesY){           
            puckController.BadEnd();

            scoreTable.IncrementScore(true);

            //The puck at the bottom scored a goal.
        } else if(transform.position.y < -boundariesY){
            puckController2.BadEnd();

            scoreTable.IncrementScore(false);

            //The puck at the top scored a goal.
        }

    
        if(!colliding && dist < 0.93f && Time.time - lastCollision > 0.06f){
            speed = Vector3.Reflect(speed - puckSpeed / Time.fixedDeltaTime, Vector3.Normalize(puck.transform.position - transform.position));

            colliding = true;
            lastCollision = Time.time;
            
            puckController.AddRew((90 - Vector3.Angle(-transform.up, speed))); //Adding reward for hitting the ball as straight as possible.

            lastHit = 1;
        } else if(!colliding2 && dist2 < 0.93f && Time.time - lastCollision > 0.06f){
            speed =  Vector3.Reflect(speed - puckSpeed2 / Time.fixedDeltaTime, Vector3.Normalize(puck2.transform.position - transform.position));

            colliding2 = true;
            lastCollision = Time.time;

            lastHit = 2;

            puckController2.AddRew((90 - Vector3.Angle(transform.up, speed))); //Adding reward for hitting the ball as straight as possible.
        }


        if(transform.position.x < -boundariesX  && speed.x < 0){
            speed = new Vector2(-speed.x, speed.y);
            colliding = false;
            colliding2 = false;
            lastCollision = Time.time - 1; //Resetting up the last collision check to make sure that the ball does not go through to puck at the cases that the puck is too close to the wall.
        }

        if(transform.position.x > boundariesX && speed.x > 0){
            speed = new Vector2(-speed.x, speed.y);
            colliding = false;
            colliding2 = false;
            lastCollision = Time.time - 1; //Resetting up the last collision check to make sure that the ball does not go through to puck at the cases that the puck is too close to the wall.
        }

        speed = speed.normalized * 13.5f; //Making sure that the magnitude of the speed is always 13.5
    }
}
