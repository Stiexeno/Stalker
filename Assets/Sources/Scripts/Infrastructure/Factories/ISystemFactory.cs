using Entitas;

namespace Roguelite
{
    public interface ISystemFactory
    {
        T Create<T>() where T : ISystem;
        T Create<T>(params object[] constructorArgs) where T : ISystem;
    }
}
