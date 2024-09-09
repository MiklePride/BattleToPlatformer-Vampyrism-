using UnityEngine;

public class Player : Entity
{
    [SerializeField] private LootCollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.MedicalKitIsRaised += OnHeal; 
    }

    private void OnDestroy()
    {
        _collisionHandler.MedicalKitIsRaised -= OnHeal;
    }

    public void Heal(float healPoint)
    {
        ChengeHealth(Mathf.Abs(healPoint));
    }

    private void OnHeal(MedicalKit medicalKit)
    {
        Heal(medicalKit.HealPoint);
        Destroy(medicalKit.gameObject);
    }
}