using UnityEngine;

public class SpellRadiusRenderer
{
    private GameObject _radiusPrefab;
    private GameObject _center;

    public SpellRadiusRenderer(GameObject radiusPrefab, float radius)
    {
        float MultiplierOfRadius = 2;

        _radiusPrefab = radiusPrefab;
        _radiusPrefab.transform.localScale = Vector2.one * (radius * MultiplierOfRadius);
    }

    public void Active()
    {
        _radiusPrefab.SetActive(true);
    }

    public void Inactive()
    {
        _radiusPrefab.SetActive(false);
    }
}
