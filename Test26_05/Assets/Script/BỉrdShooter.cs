using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    public float maxPower = 10f;
    public LineRenderer line; // để vẽ hướng bắn (tùy chọn)
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private Vector3 initialPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = transform.position;
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DrawLine();
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            rb.isKinematic = false;

            Vector2 direction = startPoint - endPoint;
            float power = Mathf.Min(direction.magnitude, 2f);
            rb.velocity = direction.normalized * power * maxPower;

            ClearLine();
        }
    }

    void DrawLine()
    {
        if (line)
        {
            line.positionCount = 2;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + (Vector3)(startPoint - endPoint));
        }
    }

    void ClearLine()
    {
        if (line)
        {
            line.positionCount = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            Invoke("ResetBird", 1.5f);
        }
    }

    void ResetBird()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = initialPos;
        rb.isKinematic = true;
    }
}
