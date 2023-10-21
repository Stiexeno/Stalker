//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyHealthListenerComponent anyHealthListener { get { return (AnyHealthListenerComponent)GetComponent(GameComponentsLookup.AnyHealthListener); } }
    public bool hasAnyHealthListener { get { return HasComponent(GameComponentsLookup.AnyHealthListener); } }

    public void AddAnyHealthListener(System.Collections.Generic.List<IAnyHealthListener> newValue) {
        var index = GameComponentsLookup.AnyHealthListener;
        var component = (AnyHealthListenerComponent)CreateComponent(index, typeof(AnyHealthListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyHealthListener(System.Collections.Generic.List<IAnyHealthListener> newValue) {
        var index = GameComponentsLookup.AnyHealthListener;
        var component = (AnyHealthListenerComponent)CreateComponent(index, typeof(AnyHealthListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyHealthListener() {
        RemoveComponent(GameComponentsLookup.AnyHealthListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyHealthListener;

    public static Entitas.IMatcher<GameEntity> AnyHealthListener {
        get {
            if (_matcherAnyHealthListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyHealthListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyHealthListener = matcher;
            }

            return _matcherAnyHealthListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddAnyHealthListener(IAnyHealthListener value) {
        var listeners = hasAnyHealthListener
            ? anyHealthListener.value
            : new System.Collections.Generic.List<IAnyHealthListener>();
        listeners.Add(value);
        ReplaceAnyHealthListener(listeners);
    }

    public void RemoveAnyHealthListener(IAnyHealthListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyHealthListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyHealthListener();
        } else {
            ReplaceAnyHealthListener(listeners);
        }
    }
}
