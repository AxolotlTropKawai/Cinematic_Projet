using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Transform _target;
    public Vector3 _offset;
    [Range(1, 10)]
    public float _smoothFactor = 10;

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        Vector3 targetPosition = _target.position + _offset;
        Vector3 _smoothPosition = Vector3.Lerp(transform.position, targetPosition, _smoothFactor * Time.fixedDeltaTime);
        transform.position = _smoothPosition;
    }
}
