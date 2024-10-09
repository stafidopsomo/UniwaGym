using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // δημοσιες μεταβλητες για να μπορουμε να τις αλλαζουμε απο τον Inspector
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    // τοπικες ιδιωτικες μεταβλητες μονο για αυτην την κλαση
    private CharacterController characterController;
    private bool canMove = true;
    private float rotationX = 0f;

    void Start()
    {
        // Περνουμε μια αναφορα απο το CharacterController component που βρισκεται πανω στον παικτη
        characterController = GetComponent<CharacterController>();

        // κανουμε τον κερσορα να "κλειδωνει" στο κεντρο και τον εξαφανιζουμε
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // αυτη η μεθοδος τρεχει σε καθε καρε του παιχνιδιου
    void Update()
    {
        // αυτη η μεθοδος ειναι υπευθηνη για την κινηση
        Move();

        // αυτη η μεθοδος ειναι υπευθηνη για την περιστροφη
        Rotate();
    }

    // μεθοδος κινησης
    void Move()
    {
        // περνουμε την εισαγωγη κινησης του παικτη για τους δυο αξονες καθετα και οριζοντια
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        // υπολογιζουμε την ταχυτητα κινησης βαση του εαν ο παικτης τρεχει η περπαταει
        float speed;
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftShift)) // εαν ειναι πατημενο το αριστερο shift τοτε ο παικτης τρεχει
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }
        }
        else
        {
            speed = 0f;
        }

        // υπολογιζουμε την κατευθηνση κινησης
        Vector3 forwardMovement = transform.forward * inputVertical;
        Vector3 sidewaysMovement = transform.right * inputHorizontal;
        Vector3 movement = forwardMovement + sidewaysMovement;

        // υπολογιζουμε την τελικη ταχυτητηα κινησης πολλαπλασιαζοντας την κινηση μας με την ταχυτητα
        Vector3 finalMovement = movement * speed;

        // προσαρμοζουμε την κινηση βαση του χρονου που περασε απο το προηγουμενο καρε
        Vector3 adjustedMovement = finalMovement * Time.deltaTime;

        // τελος, κινουμε τον παικτη με το CharacterController και του περναμε το vector3 κινησης
        characterController.Move(adjustedMovement);
    }

    // μεθοδος περιστροφης
    void Rotate()
    {
        //περνουμε εισαγωγη απο το ποντικι στους 2 αξονες
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y"); // το μειον (-) ειναι για να αντιστρεψουμε την είσοδο απο τον καθετο αξονα για πιο σωστη ρεαλιστικα κινηση ποντικιου

        // περιστροφη του παικτη οριζοντια βαση της κινησης του ποντικιου (ολοκληρο τον παικτη)
        transform.Rotate(Vector3.up * mouseX * lookSpeed);

        // περιστροφη του παικτη καθετα βαση της κινησης του ποντικιου
        rotationX += mouseY * lookSpeed;

        // χρησιμοποιοντας την clamp σιγουρευομαστε οτι η καθετη περιστροφη παραμενει στα ορια που εχουμε ορισει στην αρχη
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        // Εφαρμογη της καθετης περιστροφης στην "τοπικη περιστροφη" (local rotation) της καμερας (μονο την καμερα)
        Quaternion cameraRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerCamera.transform.localRotation = cameraRotation;
    }
}
