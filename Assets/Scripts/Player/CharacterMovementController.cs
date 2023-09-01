using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private IPlayableCharacter _character;
    [SerializeField] private PlayerStats _stats;
    public void Config(IPlayableCharacter character)
    {
        _character = character;
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = direction * (_stats.Speed * Time.fixedDeltaTime);
    }


    public Vector2 MovementDirection { get; private set; }
    public Vector2 LastMovementDirection { get; private set; }


    private void Awake()
    {
        LastMovementDirection = Vector2.right;
    }


    // Update is called once per frame
    void Update()
    {
        /*MovementDirection = InputManager.Instance.GetDirection();
        if (MovementDirection != Vector2.zero)
            LastMovementDirection = MovementDirection;*/
    }
}