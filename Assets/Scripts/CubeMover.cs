using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // 60 FPS: 1 second = 60 frames -> 5 m * 60 frames = 300 m/s
        // 30 FPS: 1 second = 30 frames -> 5 m * 30 frames = 150 m/s
        // 120 FPS: 1 second = 120 frames -> 5 m * 120 frames = 600 m/s
        // 60 FPS -> 1 frame = 1/60 seconds
        // 120 FPS -> 1 frame = 1/120 seconds
        // speed * 1/60
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Vector3
        // Vector3 vect = new Vector3(1, 3, 5);

        // Завдання: Змусити куб рухатися ліворуч
        // transform.Translate(Vector3.left * speed * Time.deltaTime);
        // Завдання: Змусити куб рухатися по діагоналі вниз та праворуч
        transform.Translate(new Vector3(1, -1, 0) * speed * Time.deltaTime);
    }
}
