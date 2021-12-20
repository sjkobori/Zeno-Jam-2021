using System.Collections.Generic;
using UnityEngine;

public class QTEInterface : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    private List<GameObject> currentObjects;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DrawSequence(float currentTime, List<HitTracker.HitData> data)
    {
        foreach(HitTracker.HitData hit in data)
        {
           
            if (!hit.hit 
                && (hit.timing.time - currentTime) > -.25f 
                && (hit.timing.time - currentTime) < -2f) //in range and not hit
            {
                DrawHit(currentTime,  hit);
            } else
            {

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

        switch(hit.timing.key)
        {
            case MoveCombo.DIRECTION.UP:
                currentHit = Instantiate(upArrow);
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
