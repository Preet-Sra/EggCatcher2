using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minX, maxX;
    Animator anim;
    public bool isDead;

    Joystick joystick;
    private int currentPoint = 0;
    [SerializeField] Transform[] points;


    Vector3 startTouchPos, endTouchPos;
    public GameObject[] AllPlayers;


    

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        anim = GetComponentInChildren<Animator>();
        currentPoint = 2;
    }


    private void Update()
    {
        if (!isDead)
        {
            // Movement();
            CheckSwipe();
            CheckBounds();
        }

    }

    void Movement()
    {
        //float horzontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = joystick.Horizontal * speed * Time.deltaTime;

        if (horizontalMovement == 0)
        {
            //Idle Animtion
            anim.SetBool("isRunning", false);
        }
        else
        {
            //Running Animation
            anim.SetBool("isRunning", true);
            Vector3 ScaleX = transform.localScale;

            if (horizontalMovement > 0)
                ScaleX.x = 1;
            else
                ScaleX.x = -1;

            transform.localScale = ScaleX;
        }


        transform.position = new Vector3(transform.position.x + horizontalMovement, transform.position.y, transform.position.z);

    }


   


    void CheckBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
            temp.x = maxX;
        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;
    }

    public void Dead()
    {
        isDead = true;
        anim.SetTrigger("Dead");

    }


    void CheckSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
            
        }
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            
            endTouchPos = Input.GetTouch(0).position;


            if (endTouchPos.x > startTouchPos.x)
            {
                //swipe right
                MoveToNextPoint(1);
            }
            else if (endTouchPos.x < startTouchPos.x)
            {
                //swipe left
                MoveToNextPoint(-1);
            }
        }

        // Move the player towards the current point
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(points[currentPoint].position.x,transform.position.y,transform.position.z), speed * Time.deltaTime);
    }

    void MoveToNextPoint(int direction)
    {
        // Update the current point based on the swipe direction
        currentPoint += direction;

        // Clamp the current point within the array bounds
        currentPoint = Mathf.Clamp(currentPoint, 0, points.Length - 1);
    }
}
