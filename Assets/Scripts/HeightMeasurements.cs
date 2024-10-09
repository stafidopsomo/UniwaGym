using TMPro;
using UnityEngine;

public class HeightMeasurement : MonoBehaviour
{
    public TextMeshProUGUI ypsosHeight;

    private float timeElapsed;
    private float lerpDuration = 3.5f;
    private float targetHeight;
    private float currentHeight;
    private bool isPlayerInArea;

    private void Start()
    {
        this.currentHeight = 0f;
        this.targetHeight = 0f;
        this.timeElapsed = 0f;
        this.isPlayerInArea = false;
    }

    private void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            currentHeight = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            this.ypsosHeight.text = currentHeight.ToString("0.0") + " cm";
        }
        else
        {
            currentHeight = targetHeight;
            this.ypsosHeight.text = currentHeight.ToString("0.0") + " cm";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerProps = other.GetComponent<PlayerProperties>();
            targetHeight = playerProps.Height;
            playerProps.heightCheck = true;
            isPlayerInArea = true;
            timeElapsed = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetHeight = 0f;
            isPlayerInArea = false;
            timeElapsed = 0f;
        }
    }
}
