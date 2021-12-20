using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator enemyAnimator;
    public Animator worldAnimator;

    public void PlayerAttack()
    {
        playerAnimator.Play("main_attack");
    }

    public void PlayerHurt()
    {
        playerAnimator.Play("main_hurt");
    }

    public void EnemyAttack()
    {
        enemyAnimator.Play("enemy_attack");
    }

    public void EnemyHurt()
    {
        enemyAnimator.Play("enemy_hurt");
    }

    public void UpdateWorldState(float percent)
    {
        if (percent > -1 && percent < 20)
        {
            World0();
        } else if (percent > 20 && percent < 40)
        {
            World20();
        }
        else if (percent > 40 && percent < 60)
        {
            World40();
        }
        else if (percent > 60 && percent < 80)
        {
            World60();
        }
        else if (percent > 80)
        {
            World80();
        }
    }

    public void World0()
    {
        worldAnimator.Play("bg0%");
    }

    public void World20()
    {
        worldAnimator.Play("bg20-40%");

    }
    public void World40()
    {
        worldAnimator.Play("bg40-60%");
    }

    public void World60()
    {
        worldAnimator.Play("bg60-80%");
    }

    public void World80()
    {
        worldAnimator.Play("bg80-100%");
    }
}
