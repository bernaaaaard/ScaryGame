using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maindoor : MonoBehaviour
{
    [Header("Public References")]
    [Space]
    public GameObject door;
    [Space]
    public Vector3 openRotation; // The target rotation when the door is open

    // Internal state
    private float timeToOpen = 1.0f; // Time in seconds to open/close the door
    private Quaternion closedRotation; // The rotation of the door when it is closed
    private Quaternion targetRotation; // The rotation we are interpolating towards
    private bool isOpen = false; // Is the door currently open or not
    private float lerpTime = 0f; // Track the lerp progress
    private bool isMoving = false; // Is the door currently moving

    [Header("Display")]
    public Text promptText;
    public Camera playerCamera;
    public LayerMask buttonLayer;
    public float maxPressDistance = 2f;

    private void Start()
    {
        door = this.gameObject;

        closedRotation = transform.rotation;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Update the lerp time based on the specified time to open/close
            lerpTime += Time.deltaTime / timeToOpen;

            // Interpolate the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpTime);

            // Check if the rotation is close enough to the target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                // Set the rotation to the exact target and stop moving
                transform.rotation = targetRotation;
                isMoving = false;
            }
        }

         RaycastHit buttonHit;

         Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out buttonHit, maxPressDistance, buttonLayer))
            {

                if (buttonHit.collider.gameObject == door || buttonHit.collider.gameObject.layer == buttonLayer)
                {
                    TogglePrompt(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        ToggleDoor();
                    }
                } 
            } 
            else if (!Physics.Raycast(ray, out buttonHit, maxPressDistance, buttonLayer))
        {
                TogglePrompt(false);
            }
    }


    public void ToggleDoor()
    {
        
            timeToOpen = 2.0f;

            // If the door is currently moving, reverse the target rotation
            if (isMoving)
            {
                // Reverse the state and reset lerpTime to handle smooth interpolation
                isOpen = !isOpen;
                lerpTime = 1.0f - lerpTime;
            }
            else
            {
                // Set the target rotation and start lerping
                isOpen = !isOpen;
                lerpTime = 0f;
            }

            // Set the target rotation based on the current state
            targetRotation = isOpen ? Quaternion.Euler(openRotation) : closedRotation;
            isMoving = true;
    }

    private void TogglePrompt(bool toggle)
    {
        promptText.gameObject.SetActive(toggle);
    }
}
