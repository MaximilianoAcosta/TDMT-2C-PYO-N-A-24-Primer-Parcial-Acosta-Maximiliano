using UnityEngine;

public interface ICharacter
{

    
    void Attack(ICharacter character, int damage);
    void TakeDamage(int damage);
    Vector2 GetPosition();
    int GetDamage();
    int GetRangeDamage();
}
