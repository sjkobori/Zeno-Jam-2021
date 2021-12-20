using System.Collections.Generic;
using UnityEngine;

public class QTEInterface : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public GameObject background;
    Bounds bounds;
    Bounds arrowBounds;

    private List<GameObject> currentObjects;
    // Start is called before the first frame update
    void Start()
    {
        bounds = background.GetComponentInChildren<SpriteRenderer>().bounds;
        currentObjects = new List<GameObject>();
        arrowBounds = upArrow.GetComponent<SpriteRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawSequence(float currentTime, List<HitTracker.HitData> data)
    {
        Debug.Log("# of hit data entries:" + data.Count);
        foreach(HitTracker.HitData hit in data)
        {
            
            float timeDiff = hit.timing.time - currentTime;
            
            if (!hit.hit 
                && timeDiff > -.25f 
                && timeDiff < 2f) //in range and not hit
            {
                Debug.Log("visible");
                DrawHit(currentTime,  hit);
            } else
            {
                Debug.Log("not visible");
            }
        }

        foreach(GameObject gameObject in currentObjects)
        {
            Destroy(gameObject, 0.02f);
        }
    }

    public void DrawHit(float currentTime, HitTracker.HitData hit)
    {
        GameObject currentHit;
        float hitTime = hit.timing.time;
        float arrowWidth = arrowBounds.max.x;
        float xPos = bounds.center.x / 2;
        float yPos =   ((hitTime - currentTime)) * bounds.max.y;


        switch (hit.timing.key)
        {
            case MoveCombo.DIRECTION.UP:
                Debug.Log("Drawing up arrow");
                currentHit = Instantiate(upArrow, new Vector3(bounds.center.x + 1.5f * arrowWidth, +bounds.min.y + yPos, 1),
                    Quaternion.identity);
                currentObjects.Add(currentHit);
                break;
            case MoveCombo.DIRECTION.DOWN:
                currentHit = Instantiate(downArrow, new Vector3(bounds.center.x -1.5f * arrowWidth, +bounds.min.y + yPos, 1),
                    Quaternion.identity);
                currentObjects.Add(currentHit);
                break;
            case MoveCombo.DIRECTION.LEFT:
                currentHit = Instantiate(leftArrow, new Vector3(bounds.center.x + -3.5f * arrowWidth, +bounds.min.y + yPos, 1),
                    Quaternion.identity);
                currentObjects.Add(currentHit);
                break;
            case MoveCombo.DIRECTION.RIGHT:
                currentHit = Instantiate(rightArrow, new Vector3(bounds.center.x + 3.5f * arrowWidth, +bounds.min.y + yPos, 1),
                    Quaternion.identity);
                currentObjects.Add(currentHit);
                break;
        }
        

    }
}
