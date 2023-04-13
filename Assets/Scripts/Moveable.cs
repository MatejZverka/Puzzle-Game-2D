using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [Header("Moveable Movement")]
    [SerializeField] float moveTime = 0.05f;

    private Vector2 origPos;
    private Vector2 newPos;

    private GameObject[] background;
    private GameObject[] stop;
    private GameObject[] moveable;
    private GameObject[] immovable;
    private GameObject gateEnter;
    private GameObject gateExit;
    private GameObject player;

    private Vector3 tempPos;
    private int calcDist;

    private bool hasGateEnter = false;
    private bool hasGateExit = false;
    private bool passedGateEnter = false;
    private bool passedGateExit = false;

    private void Awake()
    {
        background = GameObject.FindGameObjectsWithTag("Background");
        stop = GameObject.FindGameObjectsWithTag("Stop");
        moveable = GameObject.FindGameObjectsWithTag("Moveable");
        immovable = GameObject.FindGameObjectsWithTag("Immovable");
        gateEnter = GameObject.FindGameObjectWithTag("GateEnter");
        gateExit = GameObject.FindGameObjectWithTag("GateExit");
        player = GameObject.FindGameObjectWithTag("Player");

        if (gateEnter != null) { hasGateEnter = true; }
        if (gateExit != null) { hasGateExit = true; }
    }

    public void Move(Vector2 direction)
    {
        calcDist = CalculateDistance(direction);
        StartCoroutine(MoveFewBlocks(direction, calcDist));
    }

    private int CalculateDistance(Vector2 direction)
    {
        int temp = 0;
        int control = 0;

        for (int i = 1; i <= 10; i++)
        {
            // Decides where to check next depending on Vector2 direction
            if (direction == Vector2.right)
            {
                tempPos = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
            }
            else if (direction == Vector2.up)
            {
                tempPos = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
            }
            else if (direction == Vector2.left)
            {
                tempPos = new Vector3(transform.position.x - i, transform.position.y, transform.position.z);
            }
            else if (direction == Vector2.down)
            {
                tempPos = new Vector3(transform.position.x, transform.position.y - i, transform.position.z);
            }

            // Immovable modifier detection
            foreach (GameObject go in immovable)
            {
                if (go.transform.position == tempPos)
                {
                    return temp;
                }
            }

            // Moveable modifier detection
            foreach (GameObject go in moveable)
            {
                if (go.transform.position == tempPos)
                {
                    return temp;
                }
            }

            // Player detection
            if (player.transform.position == tempPos)
            {
                return temp;
            }

            // Gate detection
            if (hasGateEnter && (gateEnter.transform.position == tempPos))
            {
                passedGateEnter = true;
                return ++temp;
            }

            if (hasGateExit && (gateExit.transform.position == tempPos))
            {
                passedGateExit = true;
                return ++temp;
            }

            // Stop modifier detection
            foreach (GameObject go in stop)
            {
                if (go.transform.position == tempPos)
                {
                    return ++temp;
                }
            }

            // Level map bounds detection
            foreach (GameObject go in background)
            {
                if (go.transform.position == tempPos)
                {
                    temp++;
                    break;
                }
            }

            control++;

            if (control - temp > 0)
            {
                return temp;
            }
        }

        return temp;
    }

    private IEnumerator MoveFewBlocks(Vector2 direction, int calcDist)
    {
        float elapsedTime = 0f;

        origPos = transform.position;
        newPos = origPos + direction * calcDist;

        while (elapsedTime < moveTime * calcDist)
        {
            transform.position = Vector2.Lerp(origPos, newPos, elapsedTime / (moveTime * calcDist));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPos;

        yield return new WaitForSeconds(moveTime);

        if (passedGateEnter)
        {
            yield return new WaitForSeconds(moveTime * calcDist);
            passedGateEnter = false;
            transform.position = gateExit.transform.position;
            calcDist = CalculateDistance(direction);
            StartCoroutine(MoveFewBlocks(direction, calcDist));
            yield return null;
        }
        else if (passedGateExit)
        {
            yield return new WaitForSeconds(moveTime * calcDist);
            passedGateExit = false;
            transform.position = gateEnter.transform.position;
            calcDist = CalculateDistance(direction);
            StartCoroutine(MoveFewBlocks(direction, calcDist));
            yield return null;
        }

        player.SendMessage("isntStopped");
    }
}
