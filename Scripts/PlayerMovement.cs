using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move the object around with the arrow keys but confine it
    // to a given radius around a center point.

    private float deltaX, deltaY;
    private Rigidbody2D rb;
    public Vector3 centerPt;
    public float radius;
    public float speed = 10;


    public Vector3 CurrentPos;
    public Camera cam;

    public bool isMoving;
    public bool movementDisabled;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerHealth.OnPlayerDamaged += PlayerDamaged;
    }

    void Update()
    {
        if (movementDisabled == false)
        {
            MovementDesktop();
            MovementMobile();
        } 
    }

    private void OnEnable()
    {
        EnemySeeking.OnMeteorSpawn += SendPosition;
    }
    private void OnDisable()
    {
        EnemySeeking.OnMeteorSpawn -= SendPosition;
    }

    void MovementDesktop()
    {
        // Get the new position for the object.
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 newPos = transform.position + (movement * speed) * Time.deltaTime;

        // Calculate the distance of the new position from the center point. Keep the direction
        // the same but clamp the length to the specified radius.
        Vector3 offset = newPos - centerPt;
        transform.position = centerPt + Vector3.ClampMagnitude(offset, radius);

        if(movement.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void MovementMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position); //converts the space on screen in pixels to x/y co-ords

            switch (touch.phase)
            {
                case TouchPhase.Began: //sets the delta to the offset from transform position to the players finger
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved: //moves the rigidbody by altering the transform.pos by the delta offset ammount
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended: //stops the gameobject from moving when finger is taken off the screen.
                    rb.velocity = Vector2.zero;
                    break;

            }
            // Calculate the distance of the new position from the center point. Keep the direction
            // the same but clamp the length to the specified radius.
            Vector3 newPos = new Vector3(touchPos.x - deltaX, touchPos.y - deltaY, 0);
            Vector3 offset = newPos - centerPt;
            transform.position = centerPt + Vector3.ClampMagnitude(offset, radius);
        }
    }

    void PlayerDamaged()
    {
        movementDisabled = true;
    }

    //if an entity requires the players position, give it from here
    void SendPosition(GameObject entityRequesting)
    {
        EnemySeeking enemySeeking = entityRequesting.GetComponent<EnemySeeking>();
        enemySeeking.target = gameObject.transform;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centerPt, radius);
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDamaged -= PlayerDamaged;
    }

}