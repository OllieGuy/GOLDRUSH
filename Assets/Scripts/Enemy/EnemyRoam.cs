using UnityEngine;

public class EnemyRoam : EnemyAbstract
{
    private float randomVariationFromAnchor = 1f;
    public override void EnterState(EnemyMaster enemy)
    {
        enemy.speed = 0.2f;
        enemy.timer = 0f;
        enemy.targetPos = new Vector2(Random.Range(enemy.player.transform.position.x - randomVariationFromAnchor * 10, enemy.player.transform.position.x + randomVariationFromAnchor * 10), Random.Range(enemy.player.transform.position.y - randomVariationFromAnchor * 10, enemy.player.transform.position.y + randomVariationFromAnchor * 10));
    }
    public override void EnterState(EnemyMaster enemy, Vector2 interestedLocation)
    {
        //enemy.targetPos = new Vector2();
    }
    public override void UpdateState(EnemyMaster enemy)
    {
        if (enemy.timer >= 4.0f)
        {
            if (enemy.anchorPoint != null)
            {
                enemy.targetPos = new Vector2(Random.Range(enemy.anchorPoint.transform.position.x - randomVariationFromAnchor, enemy.anchorPoint.transform.position.x + randomVariationFromAnchor), Random.Range(enemy.anchorPoint.transform.position.y - randomVariationFromAnchor, enemy.anchorPoint.transform.position.y + randomVariationFromAnchor));
            }
            else
            {
                enemy.targetPos = new Vector2(Random.Range(enemy.player.transform.position.x - randomVariationFromAnchor * 10, enemy.player.transform.position.x + randomVariationFromAnchor * 10), Random.Range(enemy.player.transform.position.y - randomVariationFromAnchor * 10, enemy.player.transform.position.y + randomVariationFromAnchor * 10));
            }
            enemy.timer = 0f;
        }
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.targetPos, enemy.speed * Time.deltaTime);
    }
    public override void OnCollisionEnter(EnemyMaster enemy, Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("owww");
        }
        if (collision.tag == "Interest")
        {
            enemy.SwitchState(enemy.InvestiState, collision.transform.position);
        }
    }
}
