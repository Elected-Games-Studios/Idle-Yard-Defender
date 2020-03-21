public class FastZombieMovement : ZombieMovement
{
    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 4.5f;
    }
}