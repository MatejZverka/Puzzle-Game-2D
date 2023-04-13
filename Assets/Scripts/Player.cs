using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveTime = 0.055f;
    [SerializeField] bool isMoving = false;

    [Header("Modifiers")]
    [SerializeField] bool isStopped = false;
    [SerializeField] bool passedExit = false;

    private Vector2 moveInput;

    private Vector2 origPos;
    private Vector2 newPos;

    private GameObject[] background;
    private GameObject[] stop;
    private GameObject[] moveable;
    private GameObject[] immovable;
    private GameObject levelExit;
    private GameObject gateEnter;
    private GameObject gateExit;

    private Vector3 tempPos;
    private int calcDist;

    private bool hasGateEnter = false;
    private bool hasGateExit = false;
    private bool passedGateEnter = false;
    private bool passedGateExit = false;

    public int steps = 0;
    public TextMeshProUGUI stepsLabel;

    private void Awake()
    {
        background = GameObject.FindGameObjectsWithTag("Background");
        stop = GameObject.FindGameObjectsWithTag("Stop");
        moveable = GameObject.FindGameObjectsWithTag("Moveable");
        immovable = GameObject.FindGameObjectsWithTag("Immovable");
        levelExit = GameObject.FindGameObjectWithTag("LevelExit");
        gateEnter = GameObject.FindGameObjectWithTag("GateEnter");
        gateExit = GameObject.FindGameObjectWithTag("GateExit");

        if (gateEnter != null) { hasGateEnter = true; }
        if (gateExit != null) { hasGateExit = true; }
    }

    private void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (!isMoving && !passedExit && !isStopped)
        {
            if (moveInput.x == 1)       // Right
            {
                calcDist = CalculateDistance(Vector2.right);
                StartCoroutine(MoveFewBlocks(Vector2.right, calcDist));
            }
            else if (moveInput.y == 1)  // Up
            {
                calcDist = CalculateDistance(Vector2.up);
                StartCoroutine(MoveFewBlocks(Vector2.up, calcDist));
            }
            else if (moveInput.x == -1) // Left
            {
                calcDist = CalculateDistance(Vector2.left);
                StartCoroutine(MoveFewBlocks(Vector2.left, calcDist));

            }
            else if (moveInput.y == -1) // Down
            {
                calcDist = CalculateDistance(Vector2.down);
                StartCoroutine(MoveFewBlocks(Vector2.down, calcDist));
            }
        }
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
                    StartCoroutine(Push(go, direction, temp));
                    return temp;
                }
            }

            // Level Exit detection
            if (levelExit.transform.position == tempPos)
            {
                passedExit = true;
                return ++temp;
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
        if ((calcDist > 0) && (!passedGateEnter) && (!passedGateExit))
        {
            steps++;
            if (steps < 10)
            {
                stepsLabel.text = "0" + steps;
            }
            else
            {
                stepsLabel.text = "" + steps;
            }
            AudioPlayer.instance.PlayDashClip();
        }

        isMoving = true;

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

        yield return new WaitForSeconds(moveTime * 2);

        if (passedExit)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            int previousSteps = PlayerPrefs.GetInt(sceneName);
            if ((steps < previousSteps) || (previousSteps == 0))
            {
                PlayerPrefs.SetInt(sceneName, steps);
                PlayerPrefs.Save();
            }
            AudioPlayer.instance.PlayFinishClip();
        } 

        isMoving = false;

        if (passedGateEnter)
        {
            passedGateEnter = false;
            transform.position = gateExit.transform.position;
            calcDist = CalculateDistance(direction);
            StartCoroutine(MoveFewBlocks(direction, calcDist));
            yield return null;
        }
        else if (passedGateExit)
        {
            passedGateExit = false;
            transform.position = gateEnter.transform.position;
            calcDist = CalculateDistance(direction);
            StartCoroutine(MoveFewBlocks(direction, calcDist));
            yield return null;
        }
    }

    private IEnumerator Push(GameObject go, Vector2 direction, int distance)
    {
        yield return new WaitForSeconds(distance * moveTime);
        isStopped = true;
        go.SendMessage("Move", direction);
    }

    public void isntStopped()
    {
        isStopped = false;
    }

}
