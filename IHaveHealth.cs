public interface IHaveHealth
{
    float Health { get; set; }
    int HealthMax { get; }
    int ModifyHealth(int amount);
    int TakeDamage(int STR);
} 