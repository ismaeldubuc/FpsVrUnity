using UnityEngine;
using System.Collections;

public class RobotMover : MonoBehaviour
{
    public float speed = 3f;
    public float stopDistance = 2f;
    public float delayBeforeRestart = 2f;
    public bool isDead = false;

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
            Debug.LogError("Aucune caméra avec le tag 'MainCamera' trouvée !");
            enabled = false;
            return;
        }

        // 🔀 Vitesse aléatoire entre 0.5 et 5
        //speed = Random.Range(0.5f, 5f);

        startPos = transform.position;
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (isResetting) return;
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, cam.position);
        if (distance < stopDistance)
        {
            StartCoroutine(ResetRobot());
            return;
        }

        Vector3 dir = (cam.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnMouseDown()
    {
        if (!isResetting)
            StartCoroutine(ResetRobot());
    }

    IEnumerator ResetRobot()
    {
        isResetting = true;

        if (rend != null) rend.enabled = false;
        if (col != null) col.enabled = false;

        yield return new WaitForSeconds(delayBeforeRestart);

        transform.position = startPos;

        if (rend != null) rend.enabled = true;
        if (col != null) col.enabled = true;

        isResetting = false;
    }
}