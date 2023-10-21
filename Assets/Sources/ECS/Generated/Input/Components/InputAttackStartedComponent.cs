//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity attackStartedEntity { get { return GetGroup(InputMatcher.AttackStarted).GetSingleEntity(); } }

    public bool isAttackStarted {
        get { return attackStartedEntity != null; }
        set {
            var entity = attackStartedEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isAttackStarted = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly AttackStarted attackStartedComponent = new AttackStarted();

    public bool isAttackStarted {
        get { return HasComponent(InputComponentsLookup.AttackStarted); }
        set {
            if (value != isAttackStarted) {
                var index = InputComponentsLookup.AttackStarted;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : attackStartedComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAttackStarted;

    public static Entitas.IMatcher<InputEntity> AttackStarted {
        get {
            if (_matcherAttackStarted == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AttackStarted);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAttackStarted = matcher;
            }

            return _matcherAttackStarted;
        }
    }
}
