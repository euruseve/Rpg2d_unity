using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Tilemap map;

    private Transform _target;
    private Vector3 _bottomLeftLimit, _topRightLimit;
    private float _halfHeigth, _halfWidth;

    void Start()
    {
        _target = PlayerController.instance.transform;

        _halfHeigth = Camera.main.orthographicSize;
        _halfWidth = _halfHeigth * Camera.main.aspect;

        _bottomLeftLimit = map.localBounds.min + new Vector3(_halfWidth, _halfHeigth, 0);
        _topRightLimit = map.localBounds.max + new Vector3(-_halfWidth, -_halfHeigth, 0);

        PlayerController.instance.SetBounds(map.localBounds.min, map.localBounds.max);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x),
                                        Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y),
                                        transform.position.z);
    }
}
