using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diatrofologos : MonoBehaviour
{
    private bool isInRange;

    public GameObject pressEPrompt;
    public GameObject diatrofologosDialogue;

    public TextMeshProUGUI weight;
    public TextMeshProUGUI height;
    public TextMeshProUGUI BMI;
    public TextMeshProUGUI Goals;
    public TextMeshProUGUI Title;

    public GameObject BmiClass1;
    public GameObject BmiClass2;
    public GameObject BmiClass3;
    public GameObject BmiThinClass1;
    public GameObject BmiThinClass2;
    public GameObject BmiThinClass3;
    public GameObject BmiOver;
    public GameObject BmiNorm;

    private float weightValue;
    private float heightValue;
    private float bmiValue;
    private List<string> goalsValue;
    public bool canGetPrograms;

    void Start()
    {
        this.isInRange = false;
        this.pressEPrompt.SetActive(false);
        this.diatrofologosDialogue.SetActive(false);
    }

    void Update()
    {
        if (this.isInRange && Input.GetKeyDown(KeyCode.E))
        {
            this.diatrofologosDialogue.SetActive(true);
            this.pressEPrompt.SetActive(false);
            if (canGetPrograms)
            {
                this.Title.text = "Ας αναλύσουμε τις μετρήσεις σου:";
                this.weight.text = weightValue.ToString();
                this.height.text = heightValue.ToString();
                this.BMI.text = bmiValue.ToString();
                this.Goals.text = goalsValue[0].ToString() + ", " + goalsValue[1];
            }
            else
            {
                this.Title.text = "Πρέπει πρώτα να μετρηθεί το βάρος και το ύψος σου πρίν κάνουμε ανάλυση των αναγκών σου";
            }
        }

        if (this.isInRange && Input.GetKeyDown(KeyCode.Escape))
        {
            this.diatrofologosDialogue.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            this.pressEPrompt.SetActive(true);
            var playerProps = other.GetComponent<PlayerProperties>();
            if (playerProps.weightCheck && playerProps.heightCheck)
            {
                this.canGetPrograms = true;
                this.weightValue = playerProps.Weight;
                this.heightValue = playerProps.Height;
                this.bmiValue = playerProps.BMI;
                this.goalsValue = playerProps.PersonalGoals;
                playerProps.canGetExerciseProgram = true;
            }
            
            if (this.canGetPrograms)
            {
                if (playerProps.BMI < 16)
                {
                    this.BmiThinClass1.SetActive(true);
                }
                else if (playerProps.BMI > 16 && playerProps.BMI < 17)
                {
                    this.BmiThinClass2.SetActive(true);
                }
                else if (playerProps.BMI > 17 && playerProps.BMI < 18.5)
                {
                    this.BmiThinClass3.SetActive(true);
                }
                else if (playerProps.BMI > 18.5 && playerProps.BMI < 25)
                {
                    this.BmiNorm.SetActive(true);
                }
                else if (playerProps.BMI > 25 && playerProps.BMI < 30)
                {
                    this.BmiOver.SetActive(true);
                }
                else if (playerProps.BMI > 30 && playerProps.BMI < 35)
                {
                    this.BmiClass1.SetActive(true);
                }
                else if (playerProps.BMI > 35 && playerProps.BMI < 40)
                {
                    this.BmiClass2.SetActive(true);
                }
                else if (playerProps.BMI > 40)
                {
                    this.BmiClass3.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            this.pressEPrompt.SetActive(false);
            this.diatrofologosDialogue.SetActive(false);
        }
    }
}
