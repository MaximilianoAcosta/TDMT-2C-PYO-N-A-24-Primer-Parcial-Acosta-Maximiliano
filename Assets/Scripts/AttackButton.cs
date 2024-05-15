using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [field: SerializeField] PlayerBehaviour Attacker;
    [field: SerializeField] EnemyBehaviour Defender;
    [SerializeField] int attackDistance;
    public void OnButtonPress()
    {
        Vector2 attackerPos = Attacker.getPosition();
        Debug.Log(attackerPos);
        Vector2 defenderPos = Defender.getPosition();
        Debug.Log(defenderPos);
        if (Mathf.Abs(defenderPos.x - attackerPos.x) <= attackDistance || Mathf.Abs(defenderPos.y - attackerPos.y) <= attackDistance)
        {
            Attacker.Attack(Defender);
            Debug.Log("Attacked");
        }
        else
        {
            Debug.Log("Out of range");
        }
    }
}
