using System;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float _speedMoveShadow = 1.5f;
    [SerializeField] private float _speedRotationShadow = 5f;

    private Rigidbody _coliderShadow;
    private Animator _animatorShadow;
    private Transform _transformShadow;

    void Start()
    {
        _coliderShadow = GetComponent<Rigidbody>();
        _animatorShadow = GetComponent<Animator>();
        _transformShadow = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float directionX = Input.GetAxis("Horizontal");
            float directionZ = Input.GetAxis("Vertical");

            Vector3 directionVector = new Vector3(directionX, 0, directionZ);
            
            _animatorShadow.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

            if (directionVector.magnitude > Math.Abs(0.05f)) 
                _transformShadow.rotation = Quaternion.Lerp
                    (_transformShadow.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _speedRotationShadow);

            _coliderShadow.velocity = Vector3.ClampMagnitude(directionVector, 1) * _speedMoveShadow;
        }
    }
}
