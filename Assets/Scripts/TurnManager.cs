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
    [SerializeField] GameObject _TurnArrow;
    [SerializeField] IntersticialAd _IntersticialAd;
    private static bool _PlayerCanAct;
    private static bool _Lose;
    GameObject _Winner;

    private void Start()
    {
        _Winner = null;
        _PlayerCanAct = true;
        _Lose = false;
        TurnCount = 0;
        CharacterInTurn(Characters[TurnCount]);
    }
    private void Update()
    {
        if (_PlayerCanAct) { _TurnArrow.GetComponentInChildren<SpriteRenderer>().color = Color.black; }
        else { _TurnArrow.GetComponentInChildren<SpriteRenderer>().color= Color.red; }
        _TurnArrow.transform.position = Characters[TurnCount].transform.position;    
    }
    private void CharacterInTurn(GameObject character)
    {
        if (_Lose)
        {
            _FinalText.enabled = true;
            _FinalText.SetText("Your group lost");
            showAndroidAd();
            return;
        }
        if (_Winner != null)
        {
            _FinalText.enabled = true;
            _FinalText.SetText("The Winner is " + _Winner.name);
            showAndroidAd();
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

    }

    private void showAndroidAd()
    {
#if UNITY_ANDROID
        _IntersticialAd.ShowAd();
#endif
    }

    public void OnChangeTurn(InputAction.CallbackContext context)
    {
 
        if (context.performed)
        {
            ChangeTurn();
        }
    }
    public void ChangeTurn()
    {
        if (_Lose || _Winner != null) { return; }
        CheckLoseCondition();
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
        Debug.Log("Checking lose condition");
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
        }
        foreach (GameObject entity in Characters)
        {
            if (entity.CompareTag("Player"))
            {
                if (!entity.activeSelf && AliveEnemies.Count > 0)
                {
                    Debug.Log("Lose");
                    _Lose = true;
                    break;
                }
                else if (entity.activeSelf)
                {
                    Debug.Log(entity.name + "alive");
                    AlivePlayers.Add(entity);
                } 
            }
        }
        Debug.Log("enemies alive "+AliveEnemies.Count);
        if (AlivePlayers.Count == 1)
        {
            _Winner = AlivePlayers[0];
        }
        Debug.Log(_Lose);
    }

}
