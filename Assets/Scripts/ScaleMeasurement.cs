using TMPro;
using UnityEngine;

public class ScaleMeasurement : MonoBehaviour
{
    public TextMeshProUGUI scaleWeight;

    private float timeElapsed;
    private float lerpDuration = 3.5f;
    private float targetWeight;
    private float currentWeight;
    private bool isPlayerOnScale;

    private void Start()
    {
        this.currentWeight = 0f;
        this.targetWeight = 0f;
        this.timeElapsed = 0f;
        this.isPlayerOnScale = false;
    }

    private void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            currentWeight = Mathf.Lerp(currentWeight, targetWeight, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            this.scaleWeight.text = currentWeight.ToString("0.0") + " kg";
        }
        else
        {
            currentWeight = targetWeight;
            this.scaleWeight.text = currentWeight.ToString("0.0") + " kg";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerProps = other.GetComponent<PlayerProperties>();
            targetWeight = playerProps.Weight;
            playerProps.weightCheck = true;
            isPlayerOnScale = true;
            timeElapsed = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetWeight = 0f;
            isPlayerOnScale = false;
            timeElapsed = 0f;
        }
    }
}
