using UnityEngine;

public interface ICharacter
{

    
    void Attack(ICharacter character);
    void takeDamage(int damage);
    Vector2 getPosition();
}
