public class NormalZombieMovement : ZombieMovement
{
    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 3f;
    }
}