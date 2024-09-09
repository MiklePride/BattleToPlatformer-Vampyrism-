public class PatrolTransition : Transition
{
    public override bool NeedTransit => !FollowTrigger.HasPlayer && !AttackTrigger.HasPlayer;
}
