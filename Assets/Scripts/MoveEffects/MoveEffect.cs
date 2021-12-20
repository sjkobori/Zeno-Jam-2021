using UnityEngine;
[CreateAssetMenu(fileName = "MoveEffect", menuName = "ScriptableObjects/MoveEffect", order = 1)]
public abstract class MoveEffect : ScriptableObject
{
    public string move_name;

    public abstract void TakeEffect(CharacterController user, CharacterController target, float effectiveness);
}