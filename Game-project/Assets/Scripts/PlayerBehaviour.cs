using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 7f;

    public Text countText;
    public Text winMessage;

    private int count = 0;

    Vector3 movement;
    Rigidbody playerRigidbody;

    Vector3 startingPosition;

    int floorMask;
    float camRayLength = 100f;

    private bool isPlaying = true;

    public Button startButton;

    Image buttonImage;




    void Awake ()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");

        // Set up references.
        playerRigidbody = GetComponent <Rigidbody> ();

        startingPosition = transform.position;


        startButton.onClick.AddListener(() => ButtonClicked());

        buttonImage = startButton.GetComponent<Image> ();

        Debug.Log(buttonImage);
    }

    void Turning ()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);



        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        //Debug.Log(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask));

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {


            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotation);
        }
    }

    // collision detection
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = count + "";
        }

        if(other.gameObject.CompareTag("Enemy")) {
            winMessage.text = "Game Over";
        }

        if(other.gameObject.CompareTag("Destination")) {
            winMessage.text = "Win";
        }

        if(other.gameObject.CompareTag("Falling")) {
            Debug.Log("falling");
            transform.position = startingPosition;
        }
    }


        void FixedUpdate ()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");


        if(isPlaying)
        {
        // Move the player around the scene.
        Move (h, v);

        // Turn the player to face the mouse cursor.
        Turning ();
        }

    }

    void Move (float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set (h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);
    }

         void ButtonClicked()
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Start Button clicked");

        isPlaying = true;

        buttonImage.enabled = false;


    }





}