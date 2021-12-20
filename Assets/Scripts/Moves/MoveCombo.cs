using UnityEngine;
[CreateAssetMenu(fileName = "MoveCombo", menuName = "ScriptableObjects/MoveCombo", order = 1)]
public class MoveCombo : ScriptableObject
{
    public enum DIRECTION
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    [System.Serializable]
    public struct Timing
    {
        public float time;
        public DIRECTION key;
    }

    public Timing[] moves;

    float speed;

    public MoveEffect effect;

}
