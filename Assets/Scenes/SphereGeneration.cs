using UnityEngine;
using System.Collections;

public class RobotMover : MonoBehaviour
{
    public float speed = 3f;
    public float stopDistance = 2f;
    public float delayBeforeRestart = 2f;

    private Vector3 startPos;
    private Transform cam;
    private bool isResetting = false;
    private Renderer rend;
    private Collider col;

    void Start()
    {
        cam = Camera.main?.transform;
        if (cam == null)
        {
            Debug.LogError("Aucune cam�ra avec le tag 'MainCamera' trouv�e !");
            enabled = false;
            return;
        }

        startPos = transform.position;
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (isResetting) return;

        // V�rifier si le robot atteint la cam�ra
        float distance = Vector3.Distance(transform.position, cam.position);
        if (distance < stopDistance)
        {
            StartCoroutine(ResetRobot());
            return;
        }

        // Si le robot n'a pas atteint la cam�ra, continuer � se d�placer
        Vector3 dir = (cam.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnMouseDown()
    {
        // Si le robot est cliqu�, il doit dispara�tre et r�appara�tre � sa position d'origine
        if (!isResetting) StartCoroutine(ResetRobot());
    }

    IEnumerator ResetRobot()
    {
        isResetting = true;

        // Disparition imm�diate
        if (rend != null) rend.enabled = false;
        if (col != null) col.enabled = false;

        // Attente avant r�apparition (configurable)
        yield return new WaitForSeconds(delayBeforeRestart);

        // R�apparition imm�diate � la position d'origine
        transform.position = startPos;

        if (rend != null) rend.enabled = true;
        if (col != null) col.enabled = true;

        isResetting = false;
    }
}
