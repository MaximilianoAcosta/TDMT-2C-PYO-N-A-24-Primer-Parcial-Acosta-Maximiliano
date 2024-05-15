using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerUI UI;
    [SerializeField] EntityMovement entityMovement;

    [SerializeField] List<GameObject> CloseEnemies;
    [SerializeField] private int _MaxHealth;
    [SerializeField] int _Health;
    [SerializeField] int _speed;
    [SerializeField] int _damage;
    [SerializeField] int _healDone;
    
    public void Attack(EnemyBehaviour character)
    {
        character.takeDamage(_damage);
    }

    public void onSelfHeal()
    {
        _Health += _healDone;
        if (_Health > _MaxHealth) { _Health = _MaxHealth; }
        UI.SetHpText(_Health);
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
