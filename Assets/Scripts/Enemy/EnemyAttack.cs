using UnityEngine;


public class EnemyAttack : EnemyAbstract
{
    public override void EnterState(EnemyMaster enemy)
    {
        Debug.Log("switched to attack");
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        //enemy.targetPos = new Vector2();
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime);
    }
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision)
    {

    }
}
