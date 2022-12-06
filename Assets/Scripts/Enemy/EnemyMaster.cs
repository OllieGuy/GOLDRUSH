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
    public GameObject pfEnemy;
    public GameObject healthBar;
    public HealthBar hb;
    [SerializeField] public Sprite[] EnemySprite1;
    [SerializeField] public Sprite[] EnemySprite2;
    [SerializeField] public Sprite[] EnemySprite3;
    private int currentFrame = 0;
    private SpriteRenderer spriteRenderer;
    private Sprite[] framesToUse = null;
    private float spriteTimer;
    private bool switchedToLowHealth = false;
    void Start()
    {
        SelectEnemySprite();
        //Debug.Log("aw4ger");
        //Debug.Log(framesToUse.Length);
        healthBar = Instantiate(pfHealthBar, new Vector3(transform.position.x, transform.position.y + 0.1f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        hb = healthBar.GetComponent<HealthBar>();
        spriteRenderer = pfEnemy.GetComponent<SpriteRenderer>();
        currentState = RoamingState;
        currentState.EnterState(this);
        health = 10;
        maxHealth = 10;
    }

    void Update()
    {
        Debug.Log((float)health / (float)maxHealth);
        timer += Time.deltaTime;
        spriteTimer += Time.deltaTime;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionToPlayer = (player.transform.position - transform.position);
        currentState.UpdateState(this);
        hb.UpdateBar(health, maxHealth);
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, 0f);
        if ((float) health / (float) maxHealth <= 0.2 && !switchedToLowHealth)
        {
            Debug.Log("switchthingy");
            switchedToLowHealth = true;
            SwitchState(RetreatState);
        }
        if (health == 0)
        {
            Debug.Log("die");
            Destroy(this);
        }
        Draw();
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
    private void SelectEnemySprite()
    {
        int selectedEnemySprite = Random.Range(0, 3);
        switch(selectedEnemySprite)
        {
            case 0:
                framesToUse = EnemySprite1;
                break;
            case 1:
                framesToUse = EnemySprite2;
                break;
            case 2:
                framesToUse = EnemySprite3;
                break;
            default:
                break;
        }
    }
    private void Draw()
    {
        if (currentState != AttackState && health > 0)
        {
            if (spriteTimer >= 0.15f)
            {
                timer -= 0.15f;
                currentFrame = (currentFrame % 2) + 1;
                if (player.transform.position.x > transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
        else if (currentState == AttackState && health > 0)
        {
            currentFrame = 0;
        }
        else
        {
            currentFrame = 3;
        }
        spriteRenderer.sprite = framesToUse[currentFrame];
    }
}
