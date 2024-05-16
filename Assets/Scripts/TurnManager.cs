using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Characters;
    [SerializeField] PlayerMovement _PlayerMovement;
    [SerializeField] EnemyIaTurn _EnemyIaTurn;
    [SerializeField] int TurnCount;
    [SerializeField] TMP_Text _FinalText;
    private static bool _PlayerCanAct;
    private static bool _Lose;
    GameObject _Winner;

    private void Start()
    {
        TurnCount = 0;
        CharacterInTurn(Characters[TurnCount]);
    }
    private void CharacterInTurn(GameObject character)
    {
        if (_Lose)
        {
            _FinalText.enabled = true;
            _FinalText.SetText("Your group lost");
            return;
        }
        if (_Winner != null)
        {
            _FinalText.enabled = true;
            _FinalText.SetText("The Winner is " + _Winner.name);
            return;
        }
        if (character.activeSelf)
        {
            if (character.CompareTag("Player"))
            {
                _PlayerCanAct = true;
                _PlayerMovement.SetEntityToMove(character);
            }
            else
            {
                PlayerMovement.BlockMovement();
                _EnemyIaTurn.TurnStart(character);
            }

        }
        else
        {
            ChangeTurn();
        }
        CheckLoseCondition();

    }

    public void OnChangeTurn(InputAction.CallbackContext context)
    {
 
        if (context.performed)
        {
            TurnCount++;
            if (TurnCount == Characters.Count) { TurnCount = 0; }
            CharacterInTurn(Characters[TurnCount]);
        }
    }
    public void ChangeTurn()
    {
        TurnCount++;
        if (TurnCount == Characters.Count) { TurnCount = 0; }
        CharacterInTurn(Characters[TurnCount]);

    }
    public static void ConsumeAction()
    {
        _PlayerCanAct = false;
    }
    public static bool CheckIfCanAct()
    {
        return _PlayerCanAct;
    }

    private void CheckLoseCondition()
    {
        List<GameObject> AliveEnemies = new();
        List<GameObject> AlivePlayers = new();
        foreach (GameObject entity in Characters)
        {
            if (entity.CompareTag("Enemy"))
            {
                if (entity.activeSelf)
                {
                    AliveEnemies.Add(entity);
                }
            }
            if (entity.CompareTag("Player"))
            {
                if (!entity.activeSelf && AliveEnemies.Count > 0)
                {
                    
                    _Lose = true;
                }
                else if (entity.activeSelf)
                {
                    AlivePlayers.Add(entity);
                } 
            }
        }
        if(AlivePlayers.Count == 1)
        {
            _Winner = AlivePlayers[0];
        }
    }

}
