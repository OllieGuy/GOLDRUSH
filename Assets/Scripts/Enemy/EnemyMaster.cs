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
    public GameObject pfHealthBar;
    public HealthBar healthBar;
    //public HealthBar healthBar;
    private bool switchedToLowHealth = false;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = Instantiate(pfHealthBar, new Vector3(transform.position.x, transform.position.y + 0.3f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f))) as HealthBar;
        currentState = RoamingState;
        currentState.EnterState(this);
        health = 10;
        maxHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((float)health / (float)maxHealth);
        timer += Time.deltaTime;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionToPlayer = (player.transform.position - transform.position);
        currentState.UpdateState(this);
        healthBar.UpdateBar(health, maxHealth);
        if ((float) health / (float) maxHealth <= 0.2 && !switchedToLowHealth)
        {
            Debug.Log("switchthingy");
            switchedToLowHealth = true;
            SwitchState(RetreatState);
        }
        if (health == 0)
        {
            Debug.Log("die");
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
