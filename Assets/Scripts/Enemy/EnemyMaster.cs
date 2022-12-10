using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMaster : MonoBehaviour
{
    //there are way too many public variables here
    public EnemyAbstract currentState;
    public EnemyRoam RoamingState = new EnemyRoam();
    public EnemyInvestigate InvestiState = new EnemyInvestigate();
    public EnemyAttack AttackState = new EnemyAttack();
    public EnemyRetreat RetreatState = new EnemyRetreat();
    public int health;
    public int maxHealth;
    public float timer;
    public float speed = 0.5f; //base speed is 0.5, but every state changes this to its own value
    public float distanceToPlayer;
    public float shootSpeed = 1f;
    public float reloadSpeed = 0.5f; //how long before the enemy has a chance to shoot again
    public float shootDistance = 0.7f; //how close to the player the enemy must be before it starts shooting
    public Vector2 directionToPlayer;
    public Vector2 targetPos;
    public GameObject anchorPoint; //the point in the level the enemy will roam around
    public GameObject player;
    public GameObject pfHealthBar;
    public GameObject pfEnemy;
    public GameObject pfBullet;
    public GameObject pfGoldBar; //gold bar is taken so that it can be spawned after the enemy is killed
    public GameObject healthBar;
    public HealthBar hb; //health bar controller
    [SerializeField] private Sprite[] EnemySprite1; //the different enemy sprites
    [SerializeField] private Sprite[] EnemySprite2;
    [SerializeField] private Sprite[] EnemySprite3;
    private int currentFrame = 0;
    private SpriteRenderer spriteRenderer;
    private Sprite[] framesToUse = null;
    private float spriteTimer;
    private bool switchedToLowHealth = false;
    void Start()
    {
        SelectEnemySprite(); //randomly choose an enemy sprite
        healthBar = Instantiate(pfHealthBar, new Vector3(transform.position.x, transform.position.y + 0.1f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        hb = healthBar.GetComponent<HealthBar>(); //get the controller for the health bar
        spriteRenderer = pfEnemy.GetComponent<SpriteRenderer>();
        currentState = RoamingState; //the default state is set to roam
        currentState.EnterState(this);
        health = 10;
        maxHealth = 10;
    }

    void Update()
    {
        timer += Time.deltaTime; //the multipurpose timer used by all enemy states to figure out target and location behaviour
        spriteTimer += Time.deltaTime; //the timer exclusively used by the sprite renderer that has to remain separate since the main timer is constantly being reset between states
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        directionToPlayer = (player.transform.position - transform.position);
        currentState.UpdateState(this); //call the update function for the current state
        hb.UpdateBar(health, maxHealth); //update the health bar in the case that the enemy has taken damage since the last frame
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, 0f);
        if ((float)health / (float)maxHealth <= 0.2 && !switchedToLowHealth)
        {
            switchedToLowHealth = true; //so that the enemy is not always retreating - it will only retreat once when on low health
            SwitchState(RetreatState);
        }
        if (health <= 0) //the enemy dies
        {
            Destroy(this);
        }
        Draw();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            currentState.OnCollisionEnter(this, collision);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e); //this error is a byproduct of the way that the level is generated, and would be very difficult to prevent, but has no effect on gameplay
        }
    }
    public void SwitchState(EnemyAbstract state) //swap the state
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void SwitchState(EnemyAbstract state, Vector2 posPass) //this is used when there is a collision with an interest hitbox
    {
        currentState = state;
        currentState.EnterState(this, posPass);
    }
    private void SelectEnemySprite()
    {
        int selectedEnemySprite = UnityEngine.Random.Range(0, 3);
        switch (selectedEnemySprite)
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
    private void Draw() //draw the sprite in its current position
    {
        if (health > 0)
        {
            if (targetPos == new Vector2(transform.position.x, transform.position.y)) //if the enemy is not moving, then use the idle frame
            {
                currentFrame = 0;
            }
            else if (spriteTimer >= 0.15f)
            {
                spriteTimer -= 0.15f;
                currentFrame = (currentFrame % 2) + 1; //switch between the frames of the walk cycle
                if (player.transform.position.x > transform.position.x) //flip the enemy to always face the player
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
        else //activates when the enemy is dead
        {
            currentFrame = 3;
            Instantiate(pfGoldBar, new Vector2 (transform.position.x, transform.position.y + 0.16f), transform.rotation);
            SceneManagerScript.enemyTotal--;
            Destroy(healthBar);
            Destroy(this); //destroys the script, so the enemy cannot move or be interacted with, but doesn't delete the sprite so the body remains
        }
        spriteRenderer.sprite = framesToUse[currentFrame];
    }
    public void destroyBullet(GameObject bullet)
    {
        Destroy(bullet); //deletes the bullet when it hits the enemy
    }
    public void shootBullet() //enemy shoot function, could not be written in the attack state since it doesn't derive from monobehaviour
    {
        GameObject bullet = Instantiate(pfBullet, transform.position, transform.rotation); //spawn a bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector3 shootDirection = player.transform.position - transform.position;
        shootDirection.Normalize();
        rb.velocity = shootDirection * shootSpeed; //make the bullet move in the direction towards the player
    }
}
