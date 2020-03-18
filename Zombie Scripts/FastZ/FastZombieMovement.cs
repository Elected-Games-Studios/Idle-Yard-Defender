public class FastZombieMovement : ZombieMovement
{
    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 2f;
    }
}