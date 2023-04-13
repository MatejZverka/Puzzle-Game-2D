using UnityEngine;

public class GateExit : MonoBehaviour
{
    GameObject player;
    GameObject gateEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gateEnter = GameObject.FindGameObjectWithTag("GateEnter");
    }

    private void FixedUpdate()
    {
        if (player.transform.position == transform.position)
        {
            player.transform.position = gateEnter.transform.position;
        }
    }
}
