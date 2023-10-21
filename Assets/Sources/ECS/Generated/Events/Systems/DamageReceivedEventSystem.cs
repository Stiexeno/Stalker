//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class DamageReceivedEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IDamageReceivedListener> _listenerBuffer;

    public DamageReceivedEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IDamageReceivedListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.DamageReceived)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasDamageReceived && entity.hasDamageReceivedListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.damageReceived;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.damageReceivedListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnDamageReceived(e, component.value);
            }
        }
    }
}
