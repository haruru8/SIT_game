using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 5f;

    private Vector3 touchStartPos;
    private Vector3 moveDirection;

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // �^�b�`����
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenMiddle = Screen.width / 2;

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.position.x - touchStartPos.x;
                moveDirection = new Vector3(deltaX * 0.01f, 0, 0);
                transform.Translate(moveDirection * horizontalSpeed * Time.deltaTime);
                touchStartPos = touch.position;
            }
        }

        // �L�[�{�[�h����
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * horizontalSpeed * Time.deltaTime);
    }
}
