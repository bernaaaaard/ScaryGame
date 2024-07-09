using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public IntroScript GameManager;
    public Transform teleportTarget;
    public bool IsTriggerboi;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("IsWorking");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerHit at " + PlayerCharacter.transform.position + ". Will teleport to: "+ teleportTarget.transform.position);
            PlayerCharacter.transform.position = teleportTarget.transform.position;
            PlayerCharacter.transform.rotation = teleportTarget.transform.rotation;
            if (IsTriggerboi == true)
            {
                GameManager.sequence = GameManager.sequence + 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
