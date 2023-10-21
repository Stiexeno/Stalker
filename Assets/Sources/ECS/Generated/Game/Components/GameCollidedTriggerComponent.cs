//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly CollidedTriggerComponent collidedTriggerComponent = new CollidedTriggerComponent();

    public bool isCollidedTrigger {
        get { return HasComponent(GameComponentsLookup.CollidedTrigger); }
        set {
            if (value != isCollidedTrigger) {
                var index = GameComponentsLookup.CollidedTrigger;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : collidedTriggerComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollidedTrigger;

    public static Entitas.IMatcher<GameEntity> CollidedTrigger {
        get {
            if (_matcherCollidedTrigger == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollidedTrigger);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollidedTrigger = matcher;
            }

            return _matcherCollidedTrigger;
        }
    }
}
