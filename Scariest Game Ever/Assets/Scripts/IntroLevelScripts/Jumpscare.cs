using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject ScareyScreenTemporary;
    public InteractionScript Couch;
    public GameObject player;
    public GameObject teleportTarget;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScareyScreenTemporary.SetActive(true);
            WaitABit();
            ScareyScreenTemporary.SetActive(false);
            player.transform.position = teleportTarget.transform.position;
            player.transform.rotation = teleportTarget.transform.rotation;
            Couch.introJumpscare = true;
        }

    }

    IEnumerator WaitABit()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

    }
}
