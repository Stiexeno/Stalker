using Roguelite;

public interface IEntityComponent
{
    void Initialize(EntityView entityView);
    void Setup();
    void Process(in float deltaTime);
}
