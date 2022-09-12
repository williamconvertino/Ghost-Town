using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private int selectedLevel = 1;

    void Start()
    {
        transform.position = new Vector3(-7, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && selectedLevel < 5)
        {
            selectedLevel++;
            transform.position =
                new Vector3(transform.position.x + 3.5f, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedLevel > 1)
        {
            selectedLevel--;
            transform.position =
                new Vector3(transform.position.x - 3.5f, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            GameState.LoadLevel(selectedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState.LoadMenu();
        }
    }
}
