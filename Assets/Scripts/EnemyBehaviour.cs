using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ICharacter
{
    [SerializeField] PlayerUI _UI;
    [SerializeField] EntityMovement _EntityMovement;
    [SerializeField] GridManager gridManager;

    [SerializeField] private int _MaxHealth;
    [SerializeField] private int _Health;
    [SerializeField] private int _Speed;
    [SerializeField] private int _Damage;
    [SerializeField] private int _RangeDamage;
    [SerializeField] private int _Range;
    private bool _IsAlive = true;

    public void Attack(ICharacter character, int damage)
    {
        character.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        _Health -= damage;
        _UI.SetHpText(_Health);
        if (_Health <= 0)
        {
            _IsAlive = false;
            Tile thisTile = gridManager.GetTileAtPosition(GetPosition());
            if (thisTile.CheckIfHasEntityOn()) thisTile.setIfHasEntityOn(false);
            gameObject.SetActive(false);
        }
    }
    public int GetSpeed()
    {
        return _Speed;
    }
    public Vector2 GetPosition()
    {
        return _EntityMovement.GetPositionOnGrid();
    }
    public int GetDamage()
    {
        return _Damage;
    }
    public int GetRangeDamage()
    {
        return _RangeDamage;
    }
    public int GetRange()
    {
        return _Range;
    }
    public bool GetIsAlive()
    {
        return _IsAlive;
    }
}
