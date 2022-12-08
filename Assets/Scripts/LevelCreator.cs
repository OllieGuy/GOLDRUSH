using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject Cactus;
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject Stick;
    [SerializeField] private GameObject AnchorPoint;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Player;
    private float spaceToFill = 2f;
    private float enemyBufferSpace = 0.3f;
    void Start()
    {
        pepperLevelDecorations();
        placeAnchorPointsAndEnemies();
        //Instantiate(Player, new Vector2 (0f,0f), Quaternion.identity);
    }
    private void pepperLevelDecorations()
    {
        GameObject[] gameObjects = { Cactus, Rock, Stick };
        for (int i = 0; i < 50; i++)
        {
            var position = new Vector2(Random.Range(-spaceToFill, spaceToFill), Random.Range(-spaceToFill, spaceToFill));
            int selectedObj = Random.Range(0, gameObjects.Length);
            Instantiate(gameObjects[selectedObj], position, Quaternion.identity);
        }
    }
    private void placeAnchorPointsAndEnemies()
    {
        for (int i = 0; i < 4; i++)
        {
            var position = new Vector2(Random.Range(-spaceToFill, spaceToFill), Random.Range(-spaceToFill, spaceToFill));
            GameObject Anchor = Instantiate(AnchorPoint, position, Quaternion.identity);
            for (int j = 0; j < Random.Range(1, 5); j++)
            {
                var enemyInstantiatePosition = new Vector2(Random.Range(position.x - enemyBufferSpace, position.x + enemyBufferSpace), Random.Range(position.y - enemyBufferSpace, position.y + enemyBufferSpace));
                GameObject e = Instantiate(Enemy, enemyInstantiatePosition, Quaternion.identity);
                EnemyMaster EM = e.GetComponent<EnemyMaster>();
                EM.player = Player;
                EM.anchorPoint = Anchor;
            }
        }
    }
}