using System;
using TMPro;
using UnityEngine;

public class AskisiBackSquat : MonoBehaviour
{
    public TextMeshProUGUI enhmerotikoMhnyma;
    private bool canUseBackSquats;
    public int Synolikesepanalipseis;
    public bool isComplete;

    public GameObject gymnastis;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject organoCamera;
    public GameObject playerModel;
    public GameObject BackSquatsModel;
    public GameObject BackSquatsMiniGame;

    private void Start()
    {
        isComplete = false;
        canUseBackSquats = false;
        Synolikesepanalipseis = 0;
    }

    void Update()
    {
        if (isComplete)
        {
            canUseBackSquats = false;
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            BackSquatsModel.SetActive(false);

            gymnastis.GetComponent<Gymnastis>().isBackSquatsComplete = true;

            BackSquatsMiniGame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && canUseBackSquats)
        {
            playerCamera.SetActive(false);
            organoCamera.SetActive(true);

            playerModel.SetActive(false);
            BackSquatsModel.SetActive(true);

            enhmerotikoMhnyma.text = " ";

            EkkinisiMiniGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            BackSquatsModel.SetActive(false);

            BackSquatsMiniGame.SetActive(false);
        }
    }

    private void EkkinisiMiniGame()
    {
        BackSquatsMiniGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Synolikesepanalipseis > 0 && !isComplete)
        {
            enhmerotikoMhnyma.text = " Πιέστε 'Ε' για εκκίνηση της άσκησης Ημικαθίσματος με ανύψωση αλτήρα. Επαναλήψεις των 5': " + Synolikesepanalipseis.ToString();
            canUseBackSquats = true;
        }
        else if (other.tag == "Player" && isComplete)
        {
            enhmerotikoMhnyma.text = " Συγχαρητήρια, ολοκλήρωσες την άσκηση Ημικαθίσματος με ανύψωση αλτήρα. Καλη δουλειά!";
            canUseBackSquats = false;
        }
        else
        {
            enhmerotikoMhnyma.text = " Δεν φαίνεται να υπάρχει η άσκηση Ημικαθίσματος με ανύψωση αλτήρα στο πρόγραμμα σου. Έχεις επισκεφτεί πρώτα τον γυμναστή; ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUseBackSquats = false;
        }
    }
}
