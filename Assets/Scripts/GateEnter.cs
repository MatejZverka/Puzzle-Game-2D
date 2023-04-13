using System.Collections;
using UnityEngine;

public class GateEnter : MonoBehaviour
{
    GameObject player;
    GameObject gateExit;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gateExit = GameObject.FindGameObjectWithTag("GateExit");
    }

    private void FixedUpdate()
    {
        if (player.transform.position == transform.position)
        {
            player.transform.position = gateExit.transform.position;
        }
    }

}
