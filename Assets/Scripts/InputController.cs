using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool upPressed;
    public bool downPressed;
    public bool leftPressed;
    public bool rightPressed;
    public bool actionPressed;

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upPressed = true;
        }
        else
        {
            upPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downPressed = true;
        }
        else
        {
            downPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPressed = true;
        }
        else
        {
            leftPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightPressed = true;
        }
        else
        {
            rightPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            actionPressed = true;
        }
        else
        {
            actionPressed = false;
        }
    }
}
