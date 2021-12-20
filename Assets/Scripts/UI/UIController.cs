using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text playerHP;
    public Text enemyHP;
    //fields of all UI elements needed to control
    public void UpdatePlayerHP(int current, int total)
    {
        playerHP.text = current + "/" + total;
    }

    public void UpdateEnemyHP(int current, int total)
    {
        enemyHP.text = current + "/" + total;
    }



    void ShowAttackName(string attackName)
    {

    }

    void HideAttackName()
    {

    }

    void ShowMoveMenu(MoveCombo[] moves)
    {
        //put all names as buttons into the menu
    }

    void HideMoveMenu()
    {

    }


    void ShowQTEInterface(SequenceController sequence)
    {

    }

    void HideQTEInterface()
    {

    }

    void ShowPlayerDialogue(string text)
    {

    }

    void HidePlayerDialogue()
    {

    }

    void ShowEnemyDialogue(string text)
    {

    }

    void HideEnemyDialogue()
    {

    }
}
