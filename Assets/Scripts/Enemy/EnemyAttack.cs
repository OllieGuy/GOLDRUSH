using System.Threading;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class EnemyAttack : EnemyAbstract
{
    private Rigidbody rb;
    public override void EnterState(EnemyMaster enemy)
    {
        enemy.speed = 0.3f;
        enemy.timer = 0f;
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        Debug.Log("Error: shouldn't have switched to attack with interest");
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.distanceToPlayer <= enemy.shootDistance) //uses variables contained in the master so that there is very little hard coding
        {
            enemy.speed = 0.1f;
            if(enemy.timer > enemy.reloadSpeed)
            {
                int willShoot = Random.Range(0, 3); 
                if (willShoot == 0)
                {
                    enemy.shootBullet(); //every 0.5 seconds there in a 1 in 3 chance to shoot
                }
                enemy.timer = 0f;
            }
        }
        else
        {
            enemy.speed = 0.3f; //if the player is out of the close shooting distance speed up to try and catch up to the player
        }
        if (enemy.timer > 3f && enemy.distanceToPlayer <= 2.5f)
        {
            enemy.SwitchState(enemy.RoamingState); //when the player has effectively run away from the enemy
        }
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.speed * Time.deltaTime); //move towards the player
    }
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
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