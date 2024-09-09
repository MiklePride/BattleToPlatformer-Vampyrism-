using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    [SerializeField] protected PlayerTrigger AttackTrigger;
    [SerializeField] protected PlayerTrigger FollowTrigger;

    public State TargetState => _targetState;

    public virtual bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
