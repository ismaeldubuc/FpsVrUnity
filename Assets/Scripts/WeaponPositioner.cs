using UnityEngine;

public class WeaponPositioner : MonoBehaviour
{
    public Vector3 localPosition = new Vector3(0.05f, -0.58f, 0.65f);
    public Vector3 localRotation = new Vector3(6.957f, -266.425f, 27.33f);
    public float rotationSpeed = 2.0f;
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";

    void Start()
    {
        Transform cameraTransform = Camera.main.transform;
        transform.SetParent(cameraTransform);

        transform.localPosition = localPosition;
        transform.localEulerAngles = localRotation;
    }

    void Update()
    {
        float horizontalRotation = Input.GetAxis(horizontalInput) * rotationSpeed;
        float verticalRotation = Input.GetAxis(verticalInput) * rotationSpeed;

        transform.Rotate(Vector3.up, horizontalRotation);
        transform.Rotate(Vector3.left, verticalRotation);
    }
}
