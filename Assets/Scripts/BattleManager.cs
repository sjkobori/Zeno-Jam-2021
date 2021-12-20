using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    bool activeBattle;
    public PlayerController player;
    public EnemyController enemy;
    public SequenceController sequence;
    public AnimationManager animationManager;


    private int turn;

    public List<MoveCombo> moveQueue;

    bool pickingMoves;

    public bool isPlayerTurn;


    private void Start()
    {
        DoBattle(player, enemy);
    }

    void DoBattle(PlayerController player, EnemyController enemy)
    {
        this.player = player;
        this.enemy = enemy;
        activeBattle = true;
        pickingMoves = false;
        turn = 0;

    }



    // Update is called once per frame
    void TakeTurn()
    {
        if (turn % 2 == 0)
        {
            isPlayerTurn = true;
            TakePlayerTurn();

        }
        else
        {
            isPlayerTurn = false;
            TakeEnemyTurn();

        }
        if (player.IsDead() || enemy.IsDead())
        {
            activeBattle = false;
        }
    }

    public void TakePlayerTurn()
    {
        player.StartTurn();

        pickingMoves = true;
    }

    public void TakeEnemyTurn()
    {
        enemy.StartTurn();
        //randomly pick moves
        moveQueue.Add(enemy.ChooseMoves());
        
    }

    //index from menu to add to end of move queue
    public void AddMoveToQueue(int index)
    {
        if (index < player.moves.Length)
        {
            moveQueue.Add(player.moves[index]);
        }
        else
        {
            moveQueue.Add(player.moves[0]);
        }
    }

    //index from queue to remove
    public void RemoveMoveFromQueue(int index)
    {
        if (index < moveQueue.Count)
        {
            moveQueue.RemoveAt(index);
        }
        else
        {
            moveQueue.RemoveAt(moveQueue.Count - 1);
        }
    }

    public void Ready()
    {
        TakeTurn();
        Debug.Log("Ready Clicked");
        //DO QTE
        if (isPlayerTurn)
        {
            Debug.Log("Player Turn");
            animationManager.PlayerAttack();
            sequence.BeginSequence(player, enemy, this, true);
        }
        else
        {
            Debug.Log("Enemy Turn");
            animationManager.EnemyAttack();
            sequence.BeginSequence(enemy, player, this, false);
        }
        moveQueue.Clear();
        animationManager.UpdateWorldState((player.current_health + enemy.current_health) /
            ((float)(player.total_health + enemy.total_health)) * 100f);
        turn++;
    }

}
