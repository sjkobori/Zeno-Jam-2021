using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    bool activeBattle;
    public PlayerController player;
    public EnemyController enemy;
    public SequenceController sequence;

    private int turn;

    public List<MoveCombo> moveQueue;

    bool pickingMoves;

    bool isPlayerTurn;


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

        TakeTurn();
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

        enemy.ChooseMoves();
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
        Debug.Log("Ready Clicked");
        //DO QTE
        if (isPlayerTurn)
        {
            Debug.Log("Player Turn");
            sequence.BeginSequence(player, enemy, this);
        }
        else
        {
            Debug.Log("Enemy Turn");
            sequence.BeginSequence(enemy, player, this);
        }

    }

}
