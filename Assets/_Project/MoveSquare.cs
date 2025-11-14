using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    void Start()
    {
        if(_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
            Debug.LogError("Nessun componente RigidBody2D trovato!");
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(xInput, yInput);

        float sqrLength = direction.sqrMagnitude;
        if(sqrLength > 1)
        {
            direction = direction / Mathf.Sqrt(sqrLength);
        }
        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));
    } 
}
