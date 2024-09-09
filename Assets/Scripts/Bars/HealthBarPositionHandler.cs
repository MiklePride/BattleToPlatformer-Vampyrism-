using UnityEngine;

public class HealthBarPositionHandler : MonoBehaviour
{
    [SerializeField] private Transform _entityPosition;
    [SerializeField] private float _offsetY;

    private void Update()
    {
        if (_entityPosition)
        {
            transform.position = new Vector2(_entityPosition.position.x, _entityPosition.position.y + _offsetY);
        }
    }
}
