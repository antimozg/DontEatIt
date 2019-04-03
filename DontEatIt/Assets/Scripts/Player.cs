using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 playerPosition;
    public float playerSpeed;    //Скорость платформы
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition.x += Input.GetAxis("Horizontal") * playerSpeed;

        // выход из игры
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // обновим позицию платформы!
        transform.position = playerPosition;
    }
}
