public class AttackTransition : Transition
{
    public override bool NeedTransit => FollowTrigger.HasPlayer && AttackTrigger.HasPlayer;
}
