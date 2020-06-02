public interface IHealthHandler
{
    float Health { get; set; }

    void TakeDamage(float amount);
}