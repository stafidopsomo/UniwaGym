using UnityEngine;

public class Hover : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1.0f;
    public float speed = 1.0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float hoverEffect = amplitude * Mathf.Cos(Time.time * speed);
        transform.position = startPosition + Vector3.up * hoverEffect;
    }
}
