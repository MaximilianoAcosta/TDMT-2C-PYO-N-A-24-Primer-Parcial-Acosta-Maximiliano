using System.Collections;
using UnityEngine;

public class EnemyIaTurn : MonoBehaviour
{
    EntityMovement _EntityMovement;
    GameObject _entity;
    [SerializeField] TurnManager _turnManager;
    public GameObject[] players;
    ICharacter _Defender;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    public void TurnStart(GameObject entity)
    {
        _entity = entity;
        StartCoroutine(MoveAndAttack());
    }
    private IEnumerator MoveAndAttack()
    {
        _EntityMovement = _entity.GetComponent<EntityMovement>();
        TryUntilMoved(_EntityMovement);
        yield return new WaitForSeconds(0.5f);
        IaAttack(_entity.GetComponent<ICharacter>());
        yield return new WaitForSeconds(0.5f);
        _turnManager.ChangeTurn();
    }
    private void TryUntilMoved(EntityMovement entityMovement)
    {
        if (!_EntityMovement.TryMovement(GetRandomMoveDirection()))
        {
            TryUntilMoved(entityMovement);
        }
    }
    private Vector2 GetRandomMoveDirection()
    {
        Vector2 direction = new(Random.Range(-1, 2), Random.Range(-1, 2));
        if (direction.x != 0 || direction.y != 0)
        {

            return direction;

        }
        else
        {
            return GetRandomMoveDirection();
        }
    }
    private void IaAttack(ICharacter _Attacker)
    {
        Vector2 MaxDistance = new(100,100);
        GameObject ClosestEnemy = null;
        Vector2 thisPos = _entity.GetComponent<EntityMovement>().GetPositionOnGrid();

        foreach (var player in players)
        {
            Vector2 playerPos = player.GetComponent<EntityMovement>().GetPositionOnGrid();
            Vector2 distanceBetween = playerPos - thisPos;

            if (distanceBetween.magnitude < MaxDistance.magnitude)
            {
                MaxDistance = distanceBetween;
                ClosestEnemy = player;
            }
        }
        _Defender = ClosestEnemy.GetComponent<ICharacter>();

        SelectAttackType(_Attacker, _Defender, MaxDistance);
    }

    private void SelectAttackType(ICharacter attacker, ICharacter defender, Vector2 distanceBetween)
    {
        int range = _entity.GetComponent<EnemyBehaviour>().GetRange();
        if (distanceBetween.x <= 1 && distanceBetween.y <= 1)
        {
            attacker.Attack(defender, attacker.GetDamage());
        }
        else if (distanceBetween.x <= range && distanceBetween.y <= range)
        {
            attacker.Attack(defender, attacker.GetRangeDamage());
        }
    }
}

