using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 playerPosition;
    public float playerSpeed = 0.5f;    //Скорость платформы
    public float boundary = 8.5f;    //Граница
    private new Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.gameObject.GetComponent<Renderer>();
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
        float leftLimit = -boundary + renderer.bounds.size.x / 2; // Левая граница игрового поля Заданная граница + половина корзинки
        float rightLimit = boundary - renderer.bounds.size.x / 2; // Правая граница
        if (playerPosition.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, playerPosition.y, playerPosition.z);
        }
    }
}
