using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentInFrontPlayer : MonoBehaviour
{
    [SerializeField] private Material _materialOpaque;
    [SerializeField] private Material _materialTransparent;
    private Transform _playerTransform;
    private Transform _cameraTransform;
    private Collider _collider;
    private MeshRenderer _meshRender;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHp>().transform;
        _cameraTransform = Camera.main.transform;
        _collider = GetComponent<Collider>();
        _meshRender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector3 fromCameraToPlayer = _playerTransform.position - _cameraTransform.position;
        Ray ray = new Ray(_cameraTransform.position, fromCameraToPlayer);
        RaycastHit hit;

        if(_collider.Raycast(ray,out hit, fromCameraToPlayer.magnitude))
        {
            _meshRender.material = _materialTransparent;
        }
        else
        {
            _meshRender.material = _materialOpaque;
        }
    }
}
