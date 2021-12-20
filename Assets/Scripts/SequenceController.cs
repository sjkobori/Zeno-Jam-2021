using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public CharacterController activeUser;
    public CharacterController activeTarget;

    private InputController input;
    public bool active;
    private HitTracker hitTracker;
    private List<HitTracker.HitData> hitData;
    private List<MoveCombo> moves;
    private float activeTimer;
    private int totalInputs;
    private float activeDuration;

    private int totalHits;

    string displayContent;
    /// <summary>
    /// calls the move effect take effect method in this class
    /// </summary>



    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            activeTimer += Time.deltaTime;
            //if you hit the correct button +- .25 secs, add to total percent hit
            DetectHit();
            //if timing is < 2 seconds away, spawn it


            //if current timer > timing despawn
            if (activeTimer > activeDuration)
            {
                Debug.Log("Finished Sequence: " + totalHits + " out of " + totalInputs + " hit!");
                active = false;
                //Resolve effect
                foreach (MoveCombo move in moves)
                {
                    move.effect.TakeEffect(activeUser, activeTarget, ((float)totalHits) / totalInputs);
                }
            }
        }
    }

    public void BeginSequence(CharacterController user, CharacterController target, BattleManager battleManager)
    {
        active = true;
        moves = battleManager.moveQueue;

        activeUser = user;
        activeTarget = target;
        //start timer (moves only begin after 1 sec)
        activeTimer = 0;
        totalInputs = 0;
        activeDuration = 0;

        //setup hit tracker
        hitTracker = new HitTracker(moves);


        foreach (HitTracker.HitData data in hitTracker.GetHitData())
        {

            if (data.timing.time > activeDuration)
            {
                activeDuration = data.timing.time;
            }
            totalInputs++;

        }
        activeDuration += 0.5f;
        Debug.Log(totalInputs + " total inputs");
    }


    private void DetectHit()
    {
        List<HitTracker.HitData> data = hitTracker.GetHitData();
        for (int i = 0; i < data.Count; i++)
        {
            if (Mathf.Abs(activeTimer - data[i].timing.time) < .25f) //add correct button
            {
                displayContent += " " + data[i].timing.key.ToString();
                HitTracker.HitData tempItem = new HitTracker.HitData();
                tempItem.hit = true;
                tempItem.timing = data[i].timing;
                data[i] = tempItem;
                totalHits++;
                Debug.Log("HIT INPUT ");
            }
        }
        

    }

    private void OnGUI()
    {
        string content = displayContent == null ? "" : displayContent;
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
    
}
