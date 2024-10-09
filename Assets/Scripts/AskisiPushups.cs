using System;
using TMPro;
using UnityEngine;

public class AskisiPushups : MonoBehaviour
{
    public TextMeshProUGUI enhmerotikoMhnyma;
    private bool canUsePushups;
    public int Synolikesepanalipseis;
    public bool isComplete;

    public GameObject gymnastis;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject organoCamera;
    public GameObject playerModel;
    public GameObject pushupsModel;
    public GameObject pushupsMiniGame;

    private void Start()
    {
        isComplete = false;
        canUsePushups = false;
        Synolikesepanalipseis = 0;
    }

    void Update()
    {
        if (isComplete)
        {
            canUsePushups = false;
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            pushupsModel.SetActive(false);

            gymnastis.GetComponent<Gymnastis>().isPushupsComplete = true;

            pushupsMiniGame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && canUsePushups)
        {
            playerCamera.SetActive(false);
            organoCamera.SetActive(true);

            playerModel.SetActive(false);
            pushupsModel.SetActive(true);

            enhmerotikoMhnyma.text = " ";

            EkkinisiMiniGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            pushupsModel.SetActive(false);

            pushupsMiniGame.SetActive(false);
        }
    }

    private void EkkinisiMiniGame()
    {
        pushupsMiniGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Synolikesepanalipseis > 0 && !isComplete)
        {
            enhmerotikoMhnyma.text = " Πιέστε 'Ε' για εκκίνηση της άσκησης Διαδρόμου. Επαναλήψεις των 5': " + Synolikesepanalipseis.ToString();
            canUsePushups = true;
        }
        else if (other.tag == "Player" && isComplete)
        {
            enhmerotikoMhnyma.text = " Συγχαρητήρια, ολοκλήρωσες την άσκηση διαδρόμου. Καλη δουλειά!";
            canUsePushups = false;
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
            canUsePushups = false;
        }
    }
}
