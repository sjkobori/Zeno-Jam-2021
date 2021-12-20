using UnityEngine;

public class EnemyController : CharacterController
{
    public override MoveCombo ChooseMoves()
    {
        // pick move randomly
        return moves[Random.Range(0, moves.Length)];
    }

}
