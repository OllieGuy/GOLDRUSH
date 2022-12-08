using System.Threading;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class EnemyAttack : EnemyAbstract
{
    private Rigidbody rb;
    public override void EnterState(EnemyMaster enemy)
    {
        Debug.Log("Switched to attack");
        enemy.speed = 0.3f;
        enemy.timer = 0f;
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        Debug.Log("switched to attack, but somehow the wrong way");
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.distanceToPlayer <= enemy.shootDistance)
        {
            enemy.speed = 0.1f;
            if(enemy.timer > enemy.reloadSpeed)
            {
                int willShoot = Random.Range(0, 3);
                if (willShoot == 0)
                {
                    enemy.shootBullet();
                }
                enemy.timer = 0f;
            }
        }
        else
        {
            enemy.speed = 0.3f;
        }
        if (enemy.timer > 3f && enemy.distanceToPlayer <= 2.5f)
        {
            enemy.SwitchState(enemy.RoamingState);
        }
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime);
    }
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            //Debug.Log("owww");
            enemy.health--;
            enemy.destroyBullet(collision.gameObject);
        }
        if (collision.tag == "Interest")
        {
            Debug.Log("hmmmm");
            enemy.timer = 0f;
            enemy.targetPos = collision.transform.position;
        }
    }
}