using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject Cactus;
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject Stick;
    private float spaceToFill = 2f;
    void Start()
    {
        pepperLevelDecorations();
    }
    private void pepperLevelDecorations()
    {
        GameObject[] gameObjects = {Cactus, Rock, Stick};
        for (int i = 0; i < 50; i++)
        {
            var position = new Vector2(Random.Range(-spaceToFill, spaceToFill), Random.Range(-spaceToFill, spaceToFill));
            int selectedObj = Random.Range(0,3);
            Instantiate(gameObjects[selectedObj], position, Quaternion.identity);
        }
    }
}

