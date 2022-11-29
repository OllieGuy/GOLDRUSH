using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMaster : MonoBehaviour
{
    public EnemyAbstract currentState;
    public EnemyRoam RoamingState = new EnemyRoam();
    public EnemyInvestigate InvestiState = new EnemyInvestigate();
    public EnemyAttack AttackState = new EnemyAttack();
    public EnemyRetreat RetreatState = new EnemyRetreat();
    public int health;
    public int maxHealth;
    public float timer;
    public float speed = 0.5f;
    public float distanceToPlayer;
    public Vector2 directionToPlayer;
    public Vector2 targetPos;
    public GameObject anchorPoint;
    public GameObject player;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        //currentState = RoamingState;
        currentState = RetreatState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionToPlayer = player.transform.position - transform.position;
        currentState.UpdateState(this);
        if (health/maxHealth > 0.2)
        {
            currentState = RetreatState;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    public void SwitchState(EnemyAbstract state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void SwitchState(EnemyAbstract state, Vector2 posPass)
    {
        currentState = state;
        currentState.EnterState(this, posPass);
    }
}
