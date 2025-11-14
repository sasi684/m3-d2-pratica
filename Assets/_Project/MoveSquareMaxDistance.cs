using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquareMaxDistance : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _maxDistance;
    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _startPosition;
    private float _xInput;
    private float _yInput;
    private Vector2 _direction;

    void Start()
    {
        if (_rb == null)
            _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
            Debug.LogError("Nessun componente RigidBody2D trovato!");

        _startPosition = _rb.position;
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        _direction = new Vector2(_xInput, _yInput);

        float sqrLength = _direction.sqrMagnitude;
        if (sqrLength > 1)
        {
            _direction = _direction / Mathf.Sqrt(sqrLength);
        }

        if(Vector2.Distance(_startPosition, _rb.position) > _maxDistance)
            _rb.position = _startPosition;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
