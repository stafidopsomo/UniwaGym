using System;
using TMPro;
using UnityEngine;

public class AskisiJumpingJacks : MonoBehaviour
{
    public TextMeshProUGUI enhmerotikoMhnyma;
    private bool canUseJumpingJacks;
    public int Synolikesepanalipseis;
    public bool isComplete;

    public GameObject gymnastis;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject organoCamera;
    public GameObject playerModel;
    public GameObject jumpingJacksModel;
    public GameObject jumpingJacksMiniGame;

    private void Start()
    {
        isComplete = false;
        canUseJumpingJacks = false;
        Synolikesepanalipseis = 0;
    }

    void Update()
    {
        if (isComplete)
        {
            canUseJumpingJacks = false;
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            jumpingJacksModel.SetActive(false);

            gymnastis.GetComponent<Gymnastis>().isJumpingJacksComplete = true;

            jumpingJacksMiniGame.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && canUseJumpingJacks)
        {
            playerCamera.SetActive(false);
            organoCamera.SetActive(true);

            playerModel.SetActive(false);
            jumpingJacksModel.SetActive(true);

            enhmerotikoMhnyma.text = " ";

            EkkinisiMiniGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCamera.SetActive(true);
            organoCamera.SetActive(false);

            playerModel.SetActive(true);
            jumpingJacksModel.SetActive(false);

            jumpingJacksMiniGame.SetActive(false);
        }
    }

    private void EkkinisiMiniGame()
    {
        jumpingJacksMiniGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Synolikesepanalipseis > 0 && !isComplete)
        {
            enhmerotikoMhnyma.text = " Πιέστε 'Ε' για εκκίνηση της άσκησης Ανατάσεων - Εκτάσεων. Επαναλήψεις: " + Synolikesepanalipseis.ToString();
            canUseJumpingJacks = true;
        }
        else if (other.tag == "Player" && isComplete)
        {
            enhmerotikoMhnyma.text = " Συγχαρητήρια, ολοκλήρωσες την άσκηση Ανατάσεων - Εκτάσεων. Καλη δουλειά!";
            canUseJumpingJacks = false;
        }
        else
        {
            enhmerotikoMhnyma.text = " Δεν φαίνεται να υπάρχουν οι Ανατάσεις - Εκτάσεις σαν άσκηση στο πρόγραμμα σου. Έχεις επισκεφτεί πρώτα τον γυμναστή; ";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUseJumpingJacks = false;
        }
    }
}
