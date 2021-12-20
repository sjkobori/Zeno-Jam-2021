using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "ScriptableObjects/DamageEffect", order = 1)]
public class DamageEffect : MoveEffect
{
    public int damage;

    public override void TakeEffect(CharacterController user, CharacterController target, float effectiveness)
    {
        user.DealDamage((int)(damage * effectiveness), target);
    }
}
