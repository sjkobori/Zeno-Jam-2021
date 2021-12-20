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

    private List<GameObject> currentObjects;
    // Start is called before the first frame update
    void Start()
    {
        bounds = background.GetComponent<SpriteRenderer>().bounds;
        currentObjects = new List<GameObject>();
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
            Destroy(gameObject);
        }
    }

    public void DrawHit(float currentTime, HitTracker.HitData hit)
    {
        GameObject currentHit;
        float hitTime = hit.timing.time;

        float xPos = 0;
        float yPos =   ((hitTime - currentTime)/2f) * bounds.max.y;


        switch(hit.timing.key)
        {
            case MoveCombo.DIRECTION.UP:
                Debug.Log("Drawing up arrow");
                currentHit = Instantiate(upArrow, background.transform.position + new Vector3(xPos, yPos, -1), 
                    Quaternion.identity);
                break;
            case MoveCombo.DIRECTION.DOWN:
                currentHit = Instantiate(downArrow);
                break;
            case MoveCombo.DIRECTION.LEFT:
                currentHit = Instantiate(leftArrow);
                break;
            case MoveCombo.DIRECTION.RIGHT:
                currentHit = Instantiate(rightArrow);
                break;
        }
        

    }
}
