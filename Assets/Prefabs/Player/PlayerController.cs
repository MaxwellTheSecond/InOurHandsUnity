using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActions controls;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    [SerializeField]
    public GameObject playerPrefab;
    [SerializeField]
    private float moveSpeed = 5f;

    private void Awake()
    {
        controls = new InputActions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }
}
