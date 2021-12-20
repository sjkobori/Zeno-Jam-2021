using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public AnimationManager animationManager;
    public CharacterController activeUser;
    public CharacterController activeTarget;
    public QTEInterface qTE;

    public InputController input;
    public bool active;
    private HitTracker hitTracker;
    private List<HitTracker.HitData> hitData;
    private List<MoveCombo> moves;
    private float activeTimer;
    private int totalInputs;
    private float activeDuration;

    private bool isAttack;
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
            qTE.DrawSequence(activeTimer, hitData);

            //if current timer > timing despawn
            if (activeTimer > activeDuration)
            {
                if (isAttack)
                {
                    animationManager.EnemyHurt();
                }
                else
                {
                    animationManager.PlayerHurt();
                }
                Debug.Log("Finished Sequence: " + totalHits + " out of " + totalInputs + " hit!");
                active = false;
                //Resolve effect
                foreach (MoveCombo move in moves)
                {
                    move.effect.TakeEffect(activeUser, activeTarget, 
                        isAttack ? ((float)totalHits) / totalInputs : (1- ((float)totalHits) / totalInputs));
                }
            }
        }
        else
        {
            activeTimer = 0;
        }
    }

    public void BeginSequence(CharacterController user, CharacterController target, BattleManager battleManager, bool isAttack)
    {
        this.isAttack = isAttack;
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
        hitData = hitTracker.GetHitData();

        foreach (HitTracker.HitData data in hitData)
        {

            if (data.timing.time > activeDuration)
            {
                activeDuration = data.timing.time;
            }
            totalInputs++;

        }
        activeDuration += 3f;
        Debug.Log(totalInputs + " total inputs");
    }


    private void DetectHit()
    {
        List<HitTracker.HitData> data = hitTracker.GetHitData();
        for (int i = 0; i < data.Count; i++)
        {
            if (Mathf.Abs(activeTimer - data[i].timing.time) < .25f &&
                IsMatchingInput(data[i].timing.key)) //add correct button
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

    private bool IsMatchingInput(MoveCombo.DIRECTION direction)
    {
        switch (direction)
        {
            case MoveCombo.DIRECTION.UP:
                return input.upPressed;
            case MoveCombo.DIRECTION.DOWN:
                return input.downPressed;
            case MoveCombo.DIRECTION.LEFT:
                return input.leftPressed;
            case MoveCombo.DIRECTION.RIGHT:
                return input.rightPressed;
            default:
                return false;
        }
    }

    private void OnGUI()
    {
        //string content = displayContent == null ? "" : displayContent;
        //GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
    
}
