using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Player _target;

    private Vector3 _position;
    private float _zOffset = -1;

    private void LateUpdate()
    {
        _position = _target.transform.position;
        _position.z += _zOffset;
        transform.position = _position;
    }
}
