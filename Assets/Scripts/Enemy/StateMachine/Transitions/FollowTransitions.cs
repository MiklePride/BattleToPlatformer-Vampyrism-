public class FollowTransitions : Transition
{
    public override bool NeedTransit => FollowTrigger.HasPlayer && !AttackTrigger.HasPlayer;
}