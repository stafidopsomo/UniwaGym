using System;
using TMPro;
using UnityEngine;

public class AskisiSanida : MonoBehaviour
{
    public TextMeshProUGUI enhmerotikoMhnyma;
    private bool canUseSanida;
    public int Synolikesepanalipseis;
    public bool isComplete;

    public GameObject gymnastis;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject organoCamera;
    public GameObject playerModel;
    public GameObject sanidaModel;
    public GameObject sanidaMiniGame;

    private void Start()
    {
        isComplete = false;
        canUseSanida = false;
        Synolikesepanalipseis = 0;
    }

    void Update()
    {
        if (isComplete)
        {
            canUseSanida = false;
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            sanidaModel.SetActive(false);

            gymnastis.GetComponent<Gymnastis>().isSanidaComplete = true;

            sanidaMiniGame.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && canUseSanida)
        {
            playerCamera.SetActive(false);
            organoCamera.SetActive(true);

            playerModel.SetActive(false);
            sanidaModel.SetActive(true);
            enhmerotikoMhnyma.text = " ";

            EkkinisiMiniGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            sanidaModel.SetActive(false);

            sanidaMiniGame.SetActive(false);
        }
    }

    private void EkkinisiMiniGame()
    {
        sanidaMiniGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Synolikesepanalipseis > 0 && !isComplete)
        {
            enhmerotikoMhnyma.text = " Πιέστε 'Ε' για εκκίνηση της άσκησης σανίδας. Επαναλήψεις: " + Synolikesepanalipseis.ToString();
            canUseSanida = true;
        }
        else if (other.tag == "Player" && isComplete)
        {
            enhmerotikoMhnyma.text = " Συγχαρητήρια, ολοκλήρωσες την άσκηση σανίδας. Καλη δουλειά!";
            canUseSanida = false;
        }
        else
        {
            enhmerotikoMhnyma.text = " Δεν φαίνεται να υπάρχει η σανίδα σαν άσκηση στο πρόγραμμα σου. Έχεις επισκεφτεί πρώτα τον γυμναστή; ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUseSanida = false;
        }
    }
}
