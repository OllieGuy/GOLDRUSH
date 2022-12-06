using UnityEngine;


public class EnemyRetreat : EnemyAbstract
{
    public override void EnterState(EnemyMaster enemy)
    {
        Debug.Log("switched to retreat");
        enemy.speed = -0.4f;
        enemy.timer = 0f;
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.distanceToPlayer <= 1.5f)
        {
            //Debug.Log(enemy.distanceToPlayer);
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
            Debug.Log("goodbye");
            enemy.SwitchState(enemy.RoamingState);
        }
    }
        
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            //Debug.Log("owww");
            enemy.health--;
        }
    }
}
