using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallScript : MonoBehaviour
{

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private float dX = 0;
    private float dY = 0;
    private float lastX = 0;
    private float lastY = 0;
    private Rigidbody2D rb;
    public float bottom = -10.0f;
    // GameObject
    public GameObject playerObject;

    // используйте этот метод для инициализации
    void Start()
    {
        // создаем силу
        ballInitialForce = new Vector2(150.0f, 450.0f);

        // переводим в неактивное состояние
        ballIsActive = false;
        rb = GetComponent<Rigidbody2D>();
        // запоминаем положение
        ballPosition = transform.position;
    }

    void Update()
    {
        if (!ballIsActive)
        {
            ballPosition.x = playerObject.transform.position.x;
            transform.position = ballPosition;
        }
        // проверка нажатия на пробел
        if (Input.GetButtonDown("Jump") == true)
        {
            // проверка состояния
            if (!ballIsActive)
            {
                // сброс всех сил
                rb.isKinematic = false;
                // применим силу
                rb.AddForce(ballInitialForce);
                // зададим активное состояние
                ballIsActive = !ballIsActive;
            }

            if (!ballIsActive && playerObject != null)
            {
                // задаем новую позицию шарика
                ballPosition.x = playerObject.transform.position.x;

                // устанавливаем позицию шара
                transform.position = ballPosition;
            }


        }

        // проверка падения шара
        if (ballIsActive && transform.position.y < bottom)
        {
            SceneManager.LoadScene(this.gameObject.scene.name);
        }
        if (lastX == 0)
        {
            lastX = this.ballPosition.x;
            lastY = this.ballPosition.y;
        } else
        {
            dX = lastX - this.ballPosition.x;
            dY = lastY - this.ballPosition.y;
            rb.AddForce(new Vector3(dX, dY, 0));
        }
    }
}
