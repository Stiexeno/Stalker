using Entitas;
using Framework;

namespace Roguelite
{
    public class SystemFactory : ISystemFactory
    {
        private IInstantiator instantiator;

        public SystemFactory(IInstantiator instantiator)
        {
            this.instantiator = instantiator;
        }
        
        public T Create<T>() where T : ISystem => instantiator.Instantiate<T>();
        
        public T Create<T>(params object[] constructorArgs) where T : ISystem => instantiator.Instantiate<T>(constructorArgs);
    }
}
