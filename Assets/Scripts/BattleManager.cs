using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    bool activeBattle;
    public PlayerController player;
    public EnemyController enemy;
    public SequenceController sequence;
    public AnimationManager animationManager;
    public UIController uIController;
    public TransitionManager transitionManager;

    float transitionTimer;
    float transitionTime = 4f;
    bool playerDead;
    bool enemyDead;

    private int turn;

    public List<MoveCombo> moveQueue;

    bool pickingMoves;

    public bool isPlayerTurn;




    private void Start()
    {
        DoBattle(player, enemy);
    }

    private void Update()
    {
        if (playerDead || enemyDead)
        {
            transitionTimer += Time.deltaTime;
        }
        if (transitionTimer > transitionTime)
        {
            if (playerDead)
            {
                transitionManager.ToGameOver();
            }
            else
            {
                transitionManager.ToWin();
            }
            
        }
        animationManager.UpdateWorldState((player.current_health + enemy.current_health) /
               ((float)(player.total_health + enemy.total_health)) * 100f);
        EchoHP();
        if (player.current_health <= 0)
        {
            player.current_health = 0;
            playerDead = true;
        }
        if (enemy.current_health <= 0)
        {
            enemy.current_health = 0;
            enemyDead = true;
        }
        if ((playerDead || enemyDead) && transitionTimer <.5f)
        {
            if (playerDead)
            {
                animationManager.PlayerDeath();
            }
            else
            {
                animationManager.EnemyDeath();
            }
            activeBattle = false;
        }
    }

    void DoBattle(PlayerController player, EnemyController enemy)
    {
        this.player = player;
        this.enemy = enemy;
        activeBattle = true;
        pickingMoves = false;
        turn = 0;
        EchoHP();
    }

    private void EchoHP()
    {
        uIController.UpdatePlayerHP(player.current_health, player.total_health);
        uIController.UpdateEnemyHP(enemy.current_health, enemy.total_health);
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
        moveQueue.Clear();
        moveQueue.Add(enemy.ChooseMoves());
        
    }

    //index from menu to add to end of move queue
    public void AddMoveToQueue(int index)
    {
        moveQueue.Clear();
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
        
        
        turn++;
    }

}
