using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public float speed = 5f;   // Скорость игрока
    public TrailRenderer trail;  // Ссылка на компонент Trail Renderer

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Вычисляем новую позицию игрока
        Vector3 position = transform.position + new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        // Двигаем игрока
        transform.position = position;

        // Устанавливаем позицию Trail Renderer так, чтобы она оставалась на месте
        trail.transform.position = transform.position;
    }
}
