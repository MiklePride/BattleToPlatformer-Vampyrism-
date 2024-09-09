using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Player Target {  get; private set; }

    public bool HasPlayer => Target != null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Target = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Target = null;
        }
    }
}
