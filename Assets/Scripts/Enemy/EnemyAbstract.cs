using UnityEngine;

public abstract class EnemyAbstract
{
    public abstract void EnterState(EnemyMaster enemy);
    public abstract void EnterState(EnemyMaster enemy, Vector2 interestedLocation);
    public abstract void UpdateState(EnemyMaster enemy);
    public abstract void OnCollisionEnter(EnemyMaster enemy, Collider2D collision);

}
