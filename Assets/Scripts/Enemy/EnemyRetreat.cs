using UnityEngine;


public class EnemyRetreat : EnemyAbstract
{
    public override void EnterState(EnemyMaster enemy)
    {
        enemy.speed = -0.4f;
        enemy.timer = 0f;
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        Debug.Log("Error: shouldn't have switched to retreat with interest");
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.distanceToPlayer <= 1.5f) //until the player is 1.5 units away, run fast and try to stay more than 1.5 units away for 3 seconds
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime);
            enemy.timer = 0f;
        }
        else if (enemy.timer < 3f)
        {
            enemy.speed = -0.2f;
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime);
        }
        else
        {
            enemy.SwitchState(enemy.RoamingState);
        }
    }
        
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision) //enemies cannot be distracted when retreating
    {
        if (collision.tag == "Bullet")
        {
            enemy.health--;
        }
    }
}
