using UnityEngine;


public class EnemyInvestigate : EnemyAbstract
{
    public override void EnterState(EnemyMaster enemy)
    {
        Debug.Log("Error: no position passed");
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        Debug.Log("Switched to investigate");
        enemy.speed = 0.3f;
        enemy.targetPos = interestedLocation;
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.timer < 5f)
        {
            if ((enemy.transform.position.x != enemy.targetPos.x) && (enemy.transform.position.y != enemy.targetPos.y))
            {
                enemy.timer = 0f;
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.targetPos, enemy.speed * Time.deltaTime);
            }
        }
        else
        {
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
        if (collision.tag == "Interest")
        {
            Debug.Log("hmmmm");
            enemy.timer = 0f;
            enemy.targetPos = collision.transform.position;
        }
    }
}
