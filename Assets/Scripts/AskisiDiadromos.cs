using System;
using TMPro;
using UnityEngine;

public class AskisiDiadromos : MonoBehaviour
{
    public TextMeshProUGUI enhmerotikoMhnyma;
    private bool canUseDiadromos;
    public int Synolikesepanalipseis;
    public bool isComplete;

    public GameObject gymnastis;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject organoCamera;
    public GameObject playerModel;
    public GameObject diadromosModel;
    public GameObject diadromosMiniGame;

    private void Start()
    {
        isComplete = false;
        canUseDiadromos = false;
        Synolikesepanalipseis = 0;
    }

    void Update()
    {
        if (isComplete)
        {
            canUseDiadromos = false;
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            diadromosModel.SetActive(false);

            gymnastis.GetComponent<Gymnastis>().isDiadromosComplete = true;

            diadromosMiniGame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && canUseDiadromos)
        {
            playerCamera.SetActive(false);
            organoCamera.SetActive(true);

            playerModel.SetActive(false);
            diadromosModel.SetActive(true);

            enhmerotikoMhnyma.text = " ";

            EkkinisiMiniGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            diadromosModel.SetActive(false);

            diadromosMiniGame.SetActive(false);
        }
    }

    private void EkkinisiMiniGame()
    {
        diadromosMiniGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Synolikesepanalipseis > 0 && !isComplete)
        {
            enhmerotikoMhnyma.text = " Πιέστε 'Ε' για εκκίνηση της άσκησης Διαδρόμου. Επαναλήψεις των 5': " + Synolikesepanalipseis.ToString();
            canUseDiadromos = true;
        }
        else if (other.tag == "Player" && isComplete)
        {
            enhmerotikoMhnyma.text = " Συγχαρητήρια, ολοκλήρωσες την άσκηση διαδρόμου. Καλη δουλειά!";
            canUseDiadromos = false;
        }
        else
        {
            enhmerotikoMhnyma.text = " Δεν φαίνεται να υπάρχει ο διάδρομος σαν άσκηση στο πρόγραμμα σου. Έχεις επισκεφτεί πρώτα τον γυμναστή; ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUseDiadromos = false;
        }
    }
}
