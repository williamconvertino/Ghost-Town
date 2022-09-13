using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectNavigation : MonoBehaviour
{
    public GameObject[] houses;

    // Start is called before the first frame update
    void Start()
    {
        int highestLevel = GameState.highestLevel;
        for (int i = 0; i < houses.Length; i++)
        {
            if (i >= highestLevel)
            {
                SpriteRenderer spriteRenderer = houses[i].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(0.15f, 0.15f, 0.15f, 1);
            }
        }
    }
}
