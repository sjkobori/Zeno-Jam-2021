using UnityEngine;

public class EnemyController : CharacterController
{
    public override MoveCombo ChooseMoves()
    {
        // pick move randomly
        return moves[Random.Range(0, moves.Length)];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
