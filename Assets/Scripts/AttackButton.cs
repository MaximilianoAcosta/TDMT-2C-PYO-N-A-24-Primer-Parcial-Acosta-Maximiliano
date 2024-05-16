using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [SerializeField] string _AttackerName;
    [SerializeField] string _DefenderName;
    [SerializeField] int _AttackDistance;
    ICharacter _Attacker;
    ICharacter _Defender;

    private void Start()
    {
        _Attacker = GameObject.Find(_AttackerName).GetComponent<ICharacter>();
        _Defender = GameObject.Find(_DefenderName).GetComponent<ICharacter>();
    }

    public void OnButtonPress()
    {
        if (TurnManager.CheckIfCanAct())
        {
            int damage;
            Vector2 attackerPos = _Attacker.GetPosition();
            Vector2 defenderPos = _Defender.GetPosition();
            
            if (Mathf.Abs(defenderPos.x - attackerPos.x) <= _AttackDistance && Mathf.Abs(defenderPos.y - attackerPos.y) <= _AttackDistance)
            {
                if (Mathf.Abs(defenderPos.x - attackerPos.x) <= 1 && Mathf.Abs(defenderPos.y - attackerPos.y) <= 1)
                {
                    //if the range attack is too close, it does a meele attack
                    damage = _Attacker.GetDamage();
                }
                else
                {
                    damage = _Attacker.GetRangeDamage();

                }
                TurnManager.ConsumeAction();
                _Attacker.Attack(_Defender, damage);
            }
            else
            {
                Debug.Log("Out of range");
            }
        }
    }
}
