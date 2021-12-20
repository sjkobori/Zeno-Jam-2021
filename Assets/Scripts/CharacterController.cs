using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{

    public int total_health;
    public int current_health;
    public MoveCombo[] moves;
    Status[] statuses;
    bool dead;


    // Start is called before the first frame update
    void Start()
    {
        statuses = new Status[0];
        Reset();
    }

    private void Update()
    {
        if(current_health <=0)
        {
            Die();
        }
    }

    public virtual void StartTurn()
    {
        // foreach(Status s in statuses)
        // {
        //   s.applyStatus(this);
        // }
    }

    public void Reset()
    {
        dead = false;
        current_health = total_health;
    }

    public abstract MoveCombo ChooseMoves();

    public virtual void TakeDamage(int damage)
    {
        if (current_health - damage <= 0)
        {
            current_health = 0;
            Die();
        }
        current_health -= damage;
    }

    protected virtual void Die()
    {
        dead = true;
        //play death animation
    }

    public bool IsDead()
    {
        return dead;
    }

    public virtual void DealDamage(int damage, CharacterController target)
    {
        target.TakeDamage(damage);
    }
}
