using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _shadowTransform;
    private Transform _characterTransform;
    private Vector3 _cameraTransform;
    
    void Start()
    {
        _characterTransform = _playerTransform;
        _cameraTransform = transform.position;
    }

    void Update()
    {
        transform.position = _characterTransform.position + _cameraTransform;
    }

    public void ChangeUnderControllCharacter(bool _isShadowSummoned)
    {
        if (_isShadowSummoned)
        {
            _characterTransform = _shadowTransform;
        }
        else
        {
            _characterTransform = _playerTransform;
        }
    }
}
