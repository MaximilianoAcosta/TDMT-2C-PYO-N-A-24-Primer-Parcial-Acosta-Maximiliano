using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, ICharacter
{
    [SerializeField] PlayerUI _UI;
    [SerializeField] EntityMovement _EntityMovement;
    [SerializeField] GridManager gridManager;

    [SerializeField] private int _MaxHealth;
    [SerializeField] int _Health;
    [SerializeField] int _Speed;
    [SerializeField] int _Damage;
    [SerializeField] int _RangeDamage;
    [SerializeField] int _HealDone;
    private bool _IsAlive = true;
    public void Attack(ICharacter character, int damage)
    {
        character.TakeDamage(damage);
    }

    public void OnSelfHeal()
    {
        Heal(_HealDone);
    }
    public void Heal(int ammount)
    {
        _Health += ammount;
        if (_Health > _MaxHealth) { _Health = _MaxHealth; }
        _UI.SetHpText(_Health);
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
    public int GetHealthDone()
    {
        return _HealDone;
    }
    public int GetDamage()
    {
        return _Damage;
    }
    public int GetRangeDamage() 
    {
        return _RangeDamage;
    }
    public bool GetIsAlive()
    {
        return _IsAlive;
    }
}
