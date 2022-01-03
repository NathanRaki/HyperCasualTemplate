using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;
    public float speed;
    public float xPosMin;
    public float xPosMax;

    void Update()
    {
        // If at least one touch is detected
        if (Input.touchCount > 0)
        {
            // Get value of the first touch detected
            touch = Input.GetTouch(0);

            // If touch is moving
            if (touch.phase == TouchPhase.Canceled)
            {

            }
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
                //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(touch.deltaPosition.x, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);
            }
        }

        // Prevent player from getting out of the stage
        if (transform.position.x < xPosMin) transform.position = new Vector3(xPosMin, transform.position.y, transform.position.z);
        else if (transform.position.x > xPosMax) transform.position = new Vector3(xPosMax, transform.position.y, transform.position.z);
    }
}
