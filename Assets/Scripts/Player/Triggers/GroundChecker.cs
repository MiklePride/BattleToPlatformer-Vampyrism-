using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    private bool _isGround;

    public event Action<bool> GroundChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == Ground)
        {
            _isGround = true;
            GroundChanged?.Invoke(_isGround);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == Ground)
        {
            _isGround = false;
            GroundChanged?.Invoke(_isGround);
        }
    }
}
