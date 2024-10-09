using System;
using TMPro;
using UnityEngine;

public class AskisiBicycle: MonoBehaviour
{
    public TextMeshProUGUI enhmerotikoMhnyma;
    private bool canUseBicycle;
    public int Synolikesepanalipseis;
    public bool isComplete;

    public GameObject gymnastis;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject organoCamera;
    public GameObject playerModel;
    public GameObject BicycleModel;
    public GameObject BicycleMiniGame;

    private void Start()
    {
        isComplete = false;
        canUseBicycle = false;
        Synolikesepanalipseis = 0;
    }

    void Update()
    {
        if (isComplete)
        {
            canUseBicycle = false;
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            BicycleModel.SetActive(false);

            gymnastis.GetComponent<Gymnastis>().isBicycleComplete = true;

            BicycleMiniGame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && canUseBicycle)
        {
            playerCamera.SetActive(false);
            organoCamera.SetActive(true);

            playerModel.SetActive(false);
            BicycleModel.SetActive(true);

            enhmerotikoMhnyma.text = " ";

            EkkinisiMiniGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            BicycleModel.SetActive(false);

            BicycleMiniGame.SetActive(false);
        }
    }

    private void EkkinisiMiniGame()
    {
        BicycleMiniGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Synolikesepanalipseis > 0 && !isComplete)
        {
            enhmerotikoMhnyma.text = " Πιέστε 'Ε' για εκκίνηση της άσκησης κοιλιακών. Επαναλήψεις των 5': " + Synolikesepanalipseis.ToString();
            canUseBicycle = true;
        }
        else if (other.tag == "Player" && isComplete)
        {
            enhmerotikoMhnyma.text = " Συγχαρητήρια, ολοκλήρωσες την άσκηση Κοιλιακών. Καλη δουλειά!";
            canUseBicycle = false;
        }
        else
        {
            enhmerotikoMhnyma.text = " Δεν φαίνεται να υπάρχει η άσκηση κοιλιακών στο πρόγραμμα σου. Έχεις επισκεφτεί πρώτα τον γυμναστή; ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUseBicycle = false;
        }
    }
}
