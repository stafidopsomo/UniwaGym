using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class ReceptionMarket : MonoBehaviour
    {
        public List<string> ProsopikoiStoxoi = new List<string>();
        private List<ProgrammaDiatrofhs> programmataDiatrofis = new List<ProgrammaDiatrofhs>();

        public TextMeshProUGUI txtProgrammaDiatrofhs;
        public GameObject pressEprompt;
        public GameObject marketCanvas;
        private bool isPlayerInRange;
        private bool playerCanGetProgram;
        private float ypoloipoPaikth;
        public TextMeshProUGUI txtYpoloipo;
        public TextMeshProUGUI pressEPromptText1;
        public TextMeshProUGUI pressEPromptText2;
        public TextMeshProUGUI textEidopoihsh;

        public GameObject button1;
        public GameObject button2;
        public GameObject button3;
        public GameObject button4;
        public GameObject button5;
        public GameObject button6;
        public GameObject button7;
        public GameObject button8;

        private Dictionary<string, GameObject> itemButtons;
        private Dictionary<string, bool> itemPurchased;

        private void Start()
        {
            Cursor.visible = false;
            ypoloipoPaikth = 0f;
            isPlayerInRange = false;
            playerCanGetProgram = false;
            marketCanvas.SetActive(false);
            pressEprompt.SetActive(false);
            ArxikopoihshProgramatwn();
            InitializeItemButtons();
        }

        private void InitializeItemButtons()
        {
            itemButtons = new Dictionary<string, GameObject>
            {
                { "Πρωτεϊνικό Ρόφημα (500ml)", button1 },
                { "Μπάρα Ενέργειας", button2 },
                { "Μπουκάλι Νερού (1L)", button3 },
                { "Ενοικίαση Πετσέτας", button4 },
                { "Στρώμα Γιόγκα", button5 },
                { "Σέικερ Μπουκάλι", button6 },
                { "Ενεργειακό ποτό με ηλεκτρολύτες", button7 },
                { "Αγορά προγράμματος", button8 }
            };

            itemPurchased = new Dictionary<string, bool>
            {
                { "Πρωτεϊνικό Ρόφημα (500ml)", false },
                { "Μπάρα Ενέργειας", false },
                { "Μπουκάλι Νερού (1L)", false },
                { "Ενοικίαση Πετσέτας", false },
                { "Στρώμα Γιόγκα", false },
                { "Σέικερ Μπουκάλι", false },
                { "Ενεργειακό ποτό με ηλεκτρολύτες", false },
                { "Αγορά προγράμματος", false }
            };
        }

        private void Update()
        {
            txtYpoloipo.text = "Υπόλοιπο: " + ypoloipoPaikth.ToString("F2") + "€";
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                if (playerCanGetProgram)
                {
                    marketCanvas.SetActive(true);
                    pressEprompt.SetActive(false);
                    txtProgrammaDiatrofhs.text = "";
                    if (ProsopikoiStoxoi.Count > 0)
                    {
                        foreach (var stoxos in ProsopikoiStoxoi)
                        {
                            if (stoxos == " Αύξηση βάρους")
                            {
                                txtProgrammaDiatrofhs.text += "Πρωινό: " + programmataDiatrofis[0].Breakfast + "\n";
                                txtProgrammaDiatrofhs.text += "Σνακ: " + programmataDiatrofis[0].Snack + "\n";
                                txtProgrammaDiatrofhs.text += "Μεσημεριανό: " + programmataDiatrofis[0].Lunch + "\n";
                                txtProgrammaDiatrofhs.text += "Βραδινό: " + programmataDiatrofis[0].Dinner + "\n";
                                txtProgrammaDiatrofhs.text += "\n";
                            }
                            else if (stoxos == " Μείωση βάρους")
                            {
                                txtProgrammaDiatrofhs.text += "Πρωινό: " + programmataDiatrofis[1].Breakfast + "\n";
                                txtProgrammaDiatrofhs.text += "Σνακ: " + programmataDiatrofis[1].Snack + "\n";
                                txtProgrammaDiatrofhs.text += "Μεσημεριανό: " + programmataDiatrofis[1].Lunch + "\n";
                                txtProgrammaDiatrofhs.text += "Βραδινό: " + programmataDiatrofis[1].Dinner + "\n";
                                txtProgrammaDiatrofhs.text += "\n";
                            }
                            else if (stoxos == " Αντοχή")
                            {
                                txtProgrammaDiatrofhs.text += "Πρωινό: " + programmataDiatrofis[2].Breakfast + "\n";
                                txtProgrammaDiatrofhs.text += "Σνακ: " + programmataDiatrofis[2].Snack + "\n";
                                txtProgrammaDiatrofhs.text += "Μεσημεριανό: " + programmataDiatrofis[2].Lunch + "\n";
                                txtProgrammaDiatrofhs.text += "Βραδινό: " + programmataDiatrofis[2].Dinner + "\n";
                                txtProgrammaDiatrofhs.text += "\n";
                            }
                            else if (stoxos == " Ενδυνάμωση")
                            {
                                txtProgrammaDiatrofhs.text += "Πρωινό: " + programmataDiatrofis[3].Breakfast + "\n";
                                txtProgrammaDiatrofhs.text += "Σνακ: " + programmataDiatrofis[3].Snack + "\n";
                                txtProgrammaDiatrofhs.text += "Μεσημεριανό: " + programmataDiatrofis[3].Lunch + "\n";
                                txtProgrammaDiatrofhs.text += "Βραδινό: " + programmataDiatrofis[3].Dinner + "\n";
                                txtProgrammaDiatrofhs.text += "\n";
                            }
                        }
                    }
                }
            }

            if (isPlayerInRange)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AgoraAntikeimenou("Πρωτεϊνικό Ρόφημα (500ml)");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    AgoraAntikeimenou("Μπάρα Ενέργειας");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    AgoraAntikeimenou("Μπουκάλι Νερού (1L)");
                }
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    AgoraAntikeimenou("Ενοικίαση Πετσέτας");
                }
                else if (Input.GetKey(KeyCode.Alpha5))
                {
                    AgoraAntikeimenou("Στρώμα Γιόγκα");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    AgoraAntikeimenou("Σέικερ Μπουκάλι");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    AgoraAntikeimenou("Ενεργειακό ποτό με ηλεκτρολύτες");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    AgoraAntikeimenou("Αγορά προγράμματος");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                ProsopikoiStoxoi = other.GetComponent<PlayerProperties>().PersonalGoals;
                playerCanGetProgram = other.GetComponent<PlayerProperties>().canGetExerciseProgram;
                ypoloipoPaikth = other.GetComponent<PlayerProperties>().ypoloipoPaikth;
                isPlayerInRange = true;
                if (playerCanGetProgram)
                {
                    pressEPromptText1.text = "Καλωσήρθατε στο γυμναστήριο! Ρίξτε μια ματιά στα προιόντα μας! \r\n[ Ε ]";
                }
                else
                {
                    pressEPromptText1.text = "Καλωσήρθατε στο γυμναστήριο! Για την εξυπηρέτηση σας θα πρέπει πρώτα να επισκεφθείτε τον διατροφολόγο για να γίνουν οι απαραίτητες μετρήσεις\r\n[ Ε ]";
                }
                pressEprompt.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                isPlayerInRange = false;
                pressEprompt.SetActive(false);
                marketCanvas.SetActive(false);
            }
        }

        private void ArxikopoihshProgramatwn()
        {
            programmataDiatrofis.Add(new ProgrammaDiatrofhs
            {
                Breakfast = "Ομελέτα με λαχανικά και τυρί",
                Snack = "Μπάρα δημητριακών με πρωτεΐνη",
                Lunch = "Κοτόπουλο με κινόα και λαχανικά",
                Dinner = "Ψάρι με πατάτες και σαλάτα"
            });

            programmataDiatrofis.Add(new ProgrammaDiatrofhs
            {
                Breakfast = "Smoothie με μύρτιλα, μπανάνα και πρωτεΐνη",
                Snack = "Φέτες αγγουριού με τυρί cottage",
                Lunch = "Ψητό κοτόπουλο με σαλάτα και ελαιόλαδο",
                Dinner = "Μοσχάρι με λαχανικά στον ατμό"
            });

            programmataDiatrofis.Add(new ProgrammaDiatrofhs
            {
                Breakfast = "Φρούτα με γιαούρτι χαμηλών λιπαρών",
                Snack = "Μπάρες ενέργειας",
                Lunch = "Τόνος με σαλάτα και ολικής αλέσεως κριθαράκι",
                Dinner = "Κοτόπουλο με σπανάκι και ρύζι"
            });

            programmataDiatrofis.Add(new ProgrammaDiatrofhs
            {
                Breakfast = "Βρώμη με ξηρούς καρπούς και μέλι",
                Snack = "Πρωτεϊνικές μπάρες",
                Lunch = "Στήθος κοτόπουλου με γλυκοπατάτες και λαχανικά",
                Dinner = "Μοσχάρι με ρύζι και μπρόκολο"
            });

            programmataDiatrofis.Add(new ProgrammaDiatrofhs
            {
                Breakfast = "Πλήρες πρωινό με αυγά, ψωμί ολικής και φρούτα",
                Snack = "Γιαούρτι με μέλι και ξηρούς καρπούς",
                Lunch = "Γαλοπούλα με φακές και σαλάτα",
                Dinner = "Σολομός με κινόα και λαχανικά"
            });
        }

        public void AgoraAntikeimenou(string onomaProiontos)
        {
            if (itemPurchased[onomaProiontos])
            {
                textEidopoihsh.text = "Το προιόν: " + onomaProiontos + " έχει ήδη αγοραστεί.";
                return;
            }

            Debug.Log("agora");
            float cost = 0f;
            switch (onomaProiontos)
            {
                case "Πρωτεϊνικό Ρόφημα (500ml)":
                    cost = 5f;
                    break;
                case "Μπάρα Ενέργειας":
                    cost = 2.5f;
                    break;
                case "Μπουκάλι Νερού (1L)":
                    cost = 1.5f;
                    break;
                case "Ενοικίαση Πετσέτας":
                    cost = 2f;
                    break;
                case "Στρώμα Γιόγκα":
                    cost = 20f;
                    break;
                case "Σέικερ Μπουκάλι":
                    cost = 7f;
                    break;
                case "Ενεργειακό ποτό με ηλεκτρολύτες":
                    cost = 2.9f;
                    break;
                case "Αγορά προγράμματος":
                    cost = 60f;
                    break;
                default:
                    return;
            }

            itemPurchased[onomaProiontos] = true;
            itemButtons[onomaProiontos].GetComponent<Image>().color = Color.grey;
            itemButtons[onomaProiontos].GetComponent<Button>().interactable = false;

            StartCoroutine(LerpYpoloipoPaikth(ypoloipoPaikth, ypoloipoPaikth - cost, 2f));
        }

        private IEnumerator LerpYpoloipoPaikth(float startValue, float endValue, float duration)
        {
            float time = 0f;
            while (time < duration)
            {
                ypoloipoPaikth = Mathf.Lerp(startValue, endValue, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            ypoloipoPaikth = endValue;
        }
    }

    public class ProgrammaDiatrofhs
    {
        public string Breakfast { get; set; }
        public string Snack { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
    }
}
