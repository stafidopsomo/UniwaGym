using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Gymnastis : MonoBehaviour
{
    private bool isInRange;

    public GameObject pressEPrompt;
    public GameObject gymnastisDialogue;
    public bool canGetExerciseProgram;

    private bool isFinished;
    private float weightValue;
    private float heightValue;
    private float bmiValue;
    private string goalsValue;
    public List<Askisi> ListaAskhsewn = new List<Askisi>();
    public List<Askisi> ListaAskhsewnExtra = new List<Askisi>();

    public TextMeshProUGUI weight;
    public TextMeshProUGUI height;
    public TextMeshProUGUI BMI;
    public TextMeshProUGUI Goals;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Subtitle;
    public TextMeshProUGUI GoalSubtitle;
    public TextMeshProUGUI askiseisLista;
    public TextMeshProUGUI askiseisLista2;
    public GameObject playerUI;
    public TextMeshProUGUI askiseisListaUI;

    public GameObject organoSanidas;
    private bool isSanidaUIComplete = false;
    public bool isSanidaComplete = false;

    public GameObject organoDiadromos;
    private bool isDiadromosUIComplete = false;
    public bool isDiadromosComplete = false;

    public GameObject organoJumpingJacks;
    private bool isJumpingJacksUIComplete = false;
    public bool isJumpingJacksComplete = false;

    public GameObject organoPushups;
    private bool isPushupsUIComplete = false;
    public bool isPushupsComplete = false;

    public GameObject organoBackSquats;
    private bool isBackSquatsUIComplete = false;
    public bool isBackSquatsComplete = false;

    public GameObject organoBicycle;
    private bool isBicycleUIComplete = false;
    public bool isBicycleComplete = false;
    
    void Start()
    {
        this.isInRange = false;
        this.pressEPrompt.SetActive(false);
        this.gymnastisDialogue.SetActive(false);
    }

    void Update()
    {
        bool resultSanida = ListaAskhsewn.Any(s => s.Onoma == "Σανίδα");
        bool resultDiadromos = ListaAskhsewn.Any(s => s.Onoma == "Τρέξιμο στον διάδρομο");
        bool resultJumpingJacks = ListaAskhsewn.Any(s => s.Onoma == "Εκτάσεις - Ανατάσεις");
        bool resultPushups = ListaAskhsewn.Any(s => s.Onoma == "Κάμψεις");
        bool resultBackSquats = ListaAskhsewn.Any(s => s.Onoma == "Ημικάθισμα με ανύψωση αλτήρα");
        bool resultBicycle = ListaAskhsewn.Any(s => s.Onoma == "Ποδήλατο");

        if ((resultSanida && isSanidaComplete && !isSanidaUIComplete) ||
            (resultDiadromos && isDiadromosComplete && !isDiadromosUIComplete) ||
            (resultJumpingJacks && isJumpingJacksComplete && !isJumpingJacksUIComplete) ||
            (resultPushups && isPushupsComplete && !isPushupsUIComplete) ||
            (resultBackSquats && isBackSquatsComplete && !isBackSquatsUIComplete) ||
            (resultBicycle && isBicycleComplete && !isBicycleUIComplete))
        {
            askiseisListaUI.text = "";
            bool allTasksComplete = true;

            foreach (var askisi in ListaAskhsewn)
            {
                bool isCompleted = false;

                if (askisi.Onoma == "Σανίδα" && isSanidaComplete) isCompleted = true;
                else if (askisi.Onoma == "Τρέξιμο στον διάδρομο" && isDiadromosComplete) isCompleted = true;
                else if (askisi.Onoma == "Εκτάσεις - Ανατάσεις" && isJumpingJacksComplete) isCompleted = true;
                else if (askisi.Onoma == "Κάμψεις" && isPushupsComplete) isCompleted = true;
                else if (askisi.Onoma == "Ημικάθισμα με ανύψωση αλτήρα" && isBackSquatsComplete) isCompleted = true;
                else if (askisi.Onoma == "Ποδήλατο" && isBicycleComplete) isCompleted = true;
                else allTasksComplete = false;

                if (isCompleted)
                {
                    askiseisListaUI.text += "<color=green><s>- " + askisi.Onoma +
                        (askisi.Onoma == "Τρέξιμο στον διάδρομο" ? " Επαναλήψεις ανά 5': " : " Επαναλήψεις: ") +
                        askisi.Epanalipseis + "</s></color><br>";
                }
                else
                {
                    askiseisListaUI.text += "- " + askisi.Onoma + " Επαναλήψεις: " + askisi.Epanalipseis + "<br>";
                    allTasksComplete = false;
                }
            }

            if (resultSanida && isSanidaComplete) isSanidaUIComplete = true;
            if (resultDiadromos && isDiadromosComplete) isDiadromosUIComplete = true;
            if (resultJumpingJacks && isJumpingJacksComplete) isJumpingJacksUIComplete = true;
            if (resultPushups && isPushupsComplete) isPushupsUIComplete = true;
            if (resultBackSquats && isBackSquatsComplete) isBackSquatsUIComplete = true;
            if (resultBicycle && isBicycleComplete) isBicycleUIComplete = true;

            if (allTasksComplete)
            {
                askiseisListaUI.text = "<color=green> Συγχαρητήρια! Ολοκληρώσατε το πρόγραμμα γυμναστικής για σήμερα!";
            }
        }

        if (this.isInRange && Input.GetKeyDown(KeyCode.E) && !isFinished)
        {

            this.gymnastisDialogue.SetActive(true);
            if (canGetExerciseProgram)
            {
                this.weight.text = weightValue.ToString();
                this.height.text = heightValue.ToString();
                this.BMI.text = bmiValue.ToString();
                this.Goals.text = goalsValue;
                this.Title.text = "Ας βρούμε το σωστό πρόγραμμα γυμναστικής.";

                var goalsArray = this.goalsValue.Split(", ");

                if (goalsArray[0] == " Αύξηση βάρους" || goalsArray[1] == " Αύξηση βάρους")
                {
                    ListaAskhsewn.AddRange(new List<Askisi>()
                    {
                        new Askisi()
                        {
                            Onoma = "Ημικάθισμα με ανύψωση αλτήρα",
                            Epanalipseis = 10
                        },
                        new Askisi()
                        {
                            Onoma = "Kάμψεις",
                            Epanalipseis = 11
                        },
                        new Askisi()
                        {
                            Onoma = "Ποδήλατο",
                            Epanalipseis = 15
                        }
                    });
                    organoPushups.GetComponent<AskisiPushups>().Synolikesepanalipseis += 11;
                    organoBackSquats.GetComponent<AskisiBackSquat>().Synolikesepanalipseis += 10;
                    organoBicycle.GetComponent<AskisiBicycle>().Synolikesepanalipseis += 15;

                    this.Subtitle.text = $"Για τον ΔΜΣ σου θα πρέπει να γίνει άυξηση βάρους επομένως θα ξεκινήσουμε με κάποιες ασκήσεις ενδυνάμωσης σε συνδυασμό με καλή πλούσια σε υγιεινές θερμίδες διατροφή.";
                }
                else if (goalsArray[0] == " Μείωση βάρους" || goalsArray[1] == " Μείωση βάρους")
                {
                    ListaAskhsewn.AddRange(new List<Askisi>()
                    {
                        new Askisi()
                        {
                            Onoma = "Τρέξιμο στον διάδρομο",
                            Epanalipseis = 10
                        },
                        new Askisi()
                        {
                            Onoma = "Σανίδα",
                            Epanalipseis = 15
                        },
                        new Askisi()
                        {
                            Onoma = "Εκτάσεις - Ανατάσεις",
                            Epanalipseis = 16
                        }
                    });
                    organoSanidas.GetComponent<AskisiSanida>().Synolikesepanalipseis += 15;
                    organoDiadromos.GetComponent<AskisiDiadromos>().Synolikesepanalipseis += 10;
                    organoJumpingJacks.GetComponent<AskisiJumpingJacks>().Synolikesepanalipseis += 16;

                    this.Subtitle.text = $"Για τον ΔΜΣ σου θα πρέπει να γίνει μείωση βάρους επομένως θα ξεκινήσουμε με κάποιες ασκήσεις βελτίωσης της αντοχής σε συνδυασμό με καλή διατροφή με μειωμένες θερμίδες.";
                }

                foreach (var askisi in ListaAskhsewn)
                {
                    askiseisLista.text += "Άσκηση: " + askisi.Onoma + "<br>";
                    askiseisLista.text += "Επαναλήψεις: " + askisi.Epanalipseis + "<br> <br>";
                }

                if (goalsArray[0] == " Αντοχή" || goalsArray[1] == " Αντοχή")
                {
                    this.GoalSubtitle.text = "Βάση των προσωπικών σου στόχων θα προσθέσουμε μερικές ασκήσεις για την βελτίωση της αντοχής σου.";

                    ListaAskhsewnExtra.AddRange(new List<Askisi>()
                    {
                        new Askisi()
                        {
                            Onoma = "Τρέξιμο στον διάδρομο",
                            Epanalipseis = 10
                        },
                        new Askisi()
                        {
                            Onoma = "Σανίδα",
                            Epanalipseis = 10
                        },
                        new Askisi()
                        {
                            Onoma = "Εκτάσεις - Ανατάσεις",
                            Epanalipseis = 8
                        }
                    });
                    organoSanidas.GetComponent<AskisiSanida>().Synolikesepanalipseis += 10;
                    organoDiadromos.GetComponent<AskisiDiadromos>().Synolikesepanalipseis += 10;
                    organoJumpingJacks.GetComponent<AskisiJumpingJacks>().Synolikesepanalipseis += 8;

                }

                if (goalsArray[0] == " Ενδυνάμωση" || goalsArray[1] == " Ενδυνάμωση")
                {
                    this.GoalSubtitle.text = "Βάση των προσωπικών σου στόχων θα προσθέσουμε μερικές ασκήσεις για την ενδυνάμωση σου.";

                    ListaAskhsewnExtra.AddRange(new List<Askisi>()
                    {
                        new Askisi()
                        {
                            Onoma = "Κάμψεις",
                            Epanalipseis = 12
                        },
                        new Askisi()
                        {
                            Onoma = "Ημικάθισμα με ανύψωση αλτήρα",
                            Epanalipseis = 11
                        },
                        new Askisi()
                        {
                            Onoma = "Ποδήλατο",
                            Epanalipseis = 9
                        }
                    });
                    organoPushups.GetComponent<AskisiPushups>().Synolikesepanalipseis += 12;
                    organoBackSquats.GetComponent<AskisiBackSquat>().Synolikesepanalipseis += 11;
                    organoBicycle.GetComponent<AskisiBicycle>().Synolikesepanalipseis += 9;
                }

                foreach (var askisi in ListaAskhsewnExtra)
                {
                    askiseisLista2.text += "Άσκηση: " + askisi.Onoma + "<br>";
                    askiseisLista2.text += "Επαναλήψεις: " + askisi.Epanalipseis + "<br> <br>";
                }

                ListaAskhsewn.AddRange(ListaAskhsewnExtra);
                playerUI.SetActive(true);

                foreach (var askisi in ListaAskhsewn)
                {
                    askiseisListaUI.text += "- " + askisi.Onoma + " Επαναλήψεις: " + askisi.Epanalipseis + "<br>";
                }
                isFinished = true;
            }
            else
            {
                this.Title.text = "Θα πρέπει πρώτα να μιλήσεις με τον διατροφολόγο για να βρούμε το σωστό πρόγραμμα γυμναστικής.";
            }
        }

        if (this.isInRange && Input.GetKeyDown(KeyCode.Escape))
        {
            this.gymnastisDialogue.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            this.pressEPrompt.SetActive(true);
            var playerProps = other.GetComponent<PlayerProperties>();
            if (playerProps.canGetExerciseProgram)
            {
                this.canGetExerciseProgram = true;
                this.weightValue = playerProps.Weight;
                this.heightValue = playerProps.Height;
                this.bmiValue = playerProps.BMI;
                this.goalsValue = playerProps.PersonalGoals[0] + ", " + playerProps.PersonalGoals[1];

                if (this.bmiValue < 18.5)
                {
                    if(this.bmiValue < 16)
                    {
                        playerProps.exerciseProgram = "GainWeightMax";
                        return;
                    }
                    playerProps.exerciseProgram = "GainWeightNormal";
                }
                else if (this.bmiValue > 25)
                {
                    if (this.bmiValue >35 )
                    {
                        playerProps.exerciseProgram = "LoseWeightMax";
                        return;
                    }
                    playerProps.exerciseProgram = "LoseWeightNormal";
                }
                else
                {
                    playerProps.exerciseProgram = "Strengthen";
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
            this.gymnastisDialogue.SetActive(false);
        }
    }
}
