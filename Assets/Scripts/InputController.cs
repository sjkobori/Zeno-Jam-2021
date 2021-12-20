using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool upPressed;
    public bool downPressed;
    public bool leftPressed;
    public bool rightPressed;
    public bool actionPressed;

    
    public float maxBuffer;

    private float upBuffer;
    private float downBuffer;
    private float leftBuffer;
    private float rightBuffer;
    private float actionBuffer;

    // Start is called before the first frame update
    void Start()
    {
        upPressed = false;
        downPressed = false;
        leftPressed = false;
        rightPressed = false;
        actionPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) )
        {
            upBuffer = 0;
            upPressed = true;
            
            //start timer
        }
        else if (upPressed && upBuffer < maxBuffer)
        {
            upBuffer += Time.deltaTime;
            
        } else
        {
            upPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downPressed = true;
        }
        else if (downPressed && downBuffer < maxBuffer)
        {
            downBuffer += Time.deltaTime;

        }
        else
        {
            downPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPressed = true;
        }
        else if (leftPressed && leftBuffer < maxBuffer)
        {
            leftBuffer += Time.deltaTime;

        }
        else
        {
            leftPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightPressed = true;
        }
        else if (rightPressed && rightBuffer < maxBuffer)
        {
            rightBuffer += Time.deltaTime;

        }
        else
        {
            rightPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            actionPressed = true;
        }
        else if (actionPressed && actionBuffer < maxBuffer)
        {
            actionBuffer += Time.deltaTime;

        }
        else
        {
            actionPressed = false;
        }
    }
}
