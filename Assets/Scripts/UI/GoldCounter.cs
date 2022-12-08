using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text text;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.gold.ToString();
    }
}
