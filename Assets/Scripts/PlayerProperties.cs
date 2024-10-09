using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerProperties : MonoBehaviour
{
    private readonly List<string> PersonalGoalsDirectory = new List<string> { " Ενδυνάμωση", " Αντοχή" };


    public bool isMale; // fylo
    public float Weight; // se kila
    public float Height; // se ekatosta
    public float BMI; // (varos(kg)/ypsos(cm)^2)*10,000 - deikths mazas swmatos
    public List<string> PersonalGoals = new List<string>(); // lista me tous prosopikous stoxous to atomou

    public bool weightCheck;
    public bool heightCheck;

    public bool canGetExerciseProgram;
    public string exerciseProgram;
    public float ypoloipoPaikth;

    public GameObject pauseMenu;
    private bool emailRunning = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        GetRandomHealthProperties();
        GetRandomBudget();
        //Debug.Log("Male: " + isMale);
        //Debug.Log("Weight: " + Weight);
        //Debug.Log("Height: " + Height);
        //Debug.Log("BMI: " + BMI);
        foreach (var goal in PersonalGoals) 
        {
            UnityEngine.Debug.Log("Goal: " + goal);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void GetRandomBudget()
    {
        this.ypoloipoPaikth = Random.Range(70, 500);
    }

    public void GetRandomHealthProperties()
    {
        //tyxaio fylo
        var randomGender = Random.Range(0, 1);
        this.isMale = randomGender == 0 ? false : true;

        //tyxaio varos
        var randomWeight = isMale? Random.Range(60, 200) : Random.Range(40, 150);
        this.Weight = randomWeight;

        //tyxaio ypsos
        var randomHeight = isMale ? Random.Range(160, 210) : Random.Range(140, 180);
        this.Height = randomHeight;

        //ypologismeno BMI
        this.BMI = (this.Weight / (this.Height * this.Height))*10000f;

        //vazoume ypoxrewtika kapoious stoxous analoga me to BMI (px den ginetai na eimaste ypervaroi kai na exoume stoxo na paroume kila)
        this.PersonalGoals.Clear();
        if (this.BMI <18.5) //underweight
        {
            this.PersonalGoals.Add(" Αύξηση βάρους");
        }
        else if (this.BMI > 25) //overweight
        {
            this.PersonalGoals.Add(" Μείωση βάρους");
        }
        else
        {
            this.PersonalGoals.Add(" Αντοχή");
            this.PersonalGoals.Add(" Ενδυνάμωση");
            return;
        }

        //vazoume kai enan prosopiko stoxo
        var r = Random.Range(0, 2);
        this.PersonalGoals.Add(PersonalGoalsDirectory[r]);
    }

    public void Exodos()
    {
        Application.Quit();
    }

    public void Synexeia()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Epanekinish()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnlineHelp()
    {
        //Απενεργοποιηθηκε η λειτουργια καθως εαν ο χρηστης κανει χρηση της καινουριας εφαρμογης desktop outlook, ανοιγουν ατελειωτα παραθυρα email και δημιουργει προβλημα στον υπολογιστη
        //if (!emailRunning)
        //{
        //    string email = "mhlionis@gmail.com";
        //    string subject = "ΠΑΡΟΧΗ ON-LINE ΒΟΗΘΕΙΑΣ!";
        //    string body = "Γεια σας, αντιμετωπιζω το παρακατω προβλημα με το παιχνιδι και θα χρειαστω την βοηθεια σας.";

        //    string uri = "mailto:" + email + "?subject=" + subject + "&body=" + body;

        //    Process emailProcess = new Process();
        //    emailProcess.StartInfo.FileName = uri;
        //    emailProcess.Start();

        //    emailRunning = true;

        //    emailProcess.EnableRaisingEvents = true;
        //    emailProcess.Exited += (sender, args) => emailRunning = false;
        //}
    }
}
