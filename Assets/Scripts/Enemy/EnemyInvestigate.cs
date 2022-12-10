using UnityEngine;


public class EnemyInvestigate : EnemyAbstract
{
    public override void EnterState(EnemyMaster enemy)
    {
        Debug.Log("Error: no position passed"); //investistate should never be reached if the enemy is not hit by an interest collider
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation) //takes the location of the interest
    {
        Debug.Log("Switched to investigate");
        enemy.speed = 0.3f;
        enemy.targetPos = interestedLocation;
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.timer < 5f) //investigates the area for 5 seconds
        {
            if ((enemy.transform.position.x != enemy.targetPos.x) && (enemy.transform.position.y != enemy.targetPos.y)) //if the enemy hasn't reached the target, move towards it
            {
                enemy.timer = 0f;
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.targetPos, enemy.speed * Time.deltaTime);
            }
        }
        else
        {
            enemy.SwitchState(enemy.RoamingState); //after investigating for 5 seconds, switch to roam again
        }
    }
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
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
