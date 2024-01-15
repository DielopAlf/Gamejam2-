using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("InputAction")]
    [SerializeField] private InputAction _movementInput;
    [Space(3)]
    [Header("2d Movement")]
    [SerializeField] private Vector2 _movement;
    [Space(3)]
    [Header("Values support")]
    [SerializeField] private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        _movement = _movementInput.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void OnEnable()
    {
        //Configura la entrada de las acciones

        _movementInput = new InputAction("Player.Move", InputActionType.Value, "<Gamepad>/leftStick");
        _movementInput.Enable();
    }
    private void OnDisable()
    {
        // Deshabilita la entrada de las acciones
        _movementInput.Disable();
    }

    private void MoveCharacter()
    {
        // Calcular el vector de movimiento y aplicar la velocidad
        Vector3 moveDirection = new Vector3(_movement.x, _movement.y, 0f).normalized;
        Vector3 moveVelocity = moveDirection * _speed;

        // Mover el personaje
        transform.Translate(moveVelocity * Time.fixedDeltaTime);
    }
}
