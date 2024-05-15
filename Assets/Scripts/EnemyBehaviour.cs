using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ICharacter
{
    [SerializeField] PlayerUI UI;
    [SerializeField] EntityMovement entityMovement;
    [SerializeField] private int _MaxHealth;
    [SerializeField] int _Health;
    [SerializeField] int _speed;
    [SerializeField] int _damage;
    [SerializeField] int rangeDamage;
    [SerializeField] int range;


    public void Attack(ICharacter character)
    {
        character.takeDamage(_damage);
    }

    public void takeDamage(int damage)
    {
        _Health -= damage;
        UI.SetHpText(_Health);
    }
    public int getSpeed()
    {
        return _speed;
    }
    public Vector2 getPosition()
    {
        return entityMovement.GetPositionOnGrid();
    }
}
