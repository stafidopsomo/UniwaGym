using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinningCircleGame : MonoBehaviour
{
    public float spinSpeed = 200f;
    public RectTransform holeIndicator;
    public TextMeshProUGUI healthTipsText;
    public TextMeshProUGUI epanalipseisText;
    public string[] healthTips;
    public GameObject askisiSanida;
    private RectTransform rectTransform;
    private int successfulReps = 0;
    private int totalReps = 0;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ShowRandomHealthTip();
    }

    void Update()
    {
        totalReps = askisiSanida.GetComponent<AskisiSanida>().Synolikesepanalipseis;

        // Περιστροφή του δακτυλίου
        rectTransform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);

        // Έλεγχος οτι ολοκληρώθηκε η επανάληψη
        if (successfulReps >= totalReps)
        {
            askisiSanida.GetComponent<AskisiSanida>().isComplete = true;
        }

        // Έλεγχος για εισαγωγή απο τον παίκτη
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsAligned())
            {
                successfulReps++;
                epanalipseisText.text = "Επανάληψη επιτυχής! Συνολικές επιτυχείς επαναλήψεις: " + successfulReps;
                epanalipseisText.color = Color.green;
                ShowRandomHealthTip();
            }
            else
            {
                epanalipseisText.text = "Δεν το πέτυχες! Συνολικές επιτυχείς επαναλήψεις: " + successfulReps;
                epanalipseisText.color = Color.red;
            }
        }

        // Αλλαγή ταχύτητας περιστροφής
        AdjustSpinSpeed();
    }

    bool IsAligned()
    {
        float angle = Vector3.Angle(rectTransform.up, holeIndicator.up);
        return angle < 20f;
    }

    void ShowRandomHealthTip()
    {
        int randomIndex = Random.Range(0, healthTips.Length);
        healthTipsText.text = healthTips[randomIndex];
    }

    void AdjustSpinSpeed()
    {
        float completionPercentage = (float)successfulReps / totalReps;

        if (completionPercentage >= 0.8f)
        {
            spinSpeed = 400f; // Αύξηση ταχύτητας όταν φτάσει στο 80% ολοκλήρωσης
        }
        else if (completionPercentage >= 0.4f)
        {
            spinSpeed = 300f; // Αύξηση ταχύτητας όταν φτάσει στο 40% ολοκλήρωσης
        }
    }
}
