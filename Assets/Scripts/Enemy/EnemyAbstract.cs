using UnityEngine;

public abstract class EnemyAbstract //Creates the methods that the states of the enemy draw from
{
    public abstract void EnterState(EnemyMaster enemy);
    public abstract void EnterState(EnemyMaster enemy, Vector2 interestedLocation); //used for the investigation state
    public abstract void UpdateState(EnemyMaster enemy); //called every frame to update the specific state the enemy is currently in
    public abstract void OnCollisionEnter(EnemyMaster enemy, Collider2D collision); //passes the collision so the enemy can work out if it is taking damage or in range of something

}
