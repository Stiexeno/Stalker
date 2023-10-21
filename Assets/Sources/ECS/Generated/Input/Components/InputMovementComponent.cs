//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity movementEntity { get { return GetGroup(InputMatcher.Movement).GetSingleEntity(); } }
    public Movement movement { get { return movementEntity.movement; } }
    public bool hasMovement { get { return movementEntity != null; } }

    public InputEntity SetMovement(UnityEngine.Vector2 newValue) {
        if (hasMovement) {
            throw new Entitas.EntitasException("Could not set Movement!\n" + this + " already has an entity with Movement!",
                "You should check if the context already has a movementEntity before setting it or use context.ReplaceMovement().");
        }
        var entity = CreateEntity();
        entity.AddMovement(newValue);
        return entity;
    }

    public void ReplaceMovement(UnityEngine.Vector2 newValue) {
        var entity = movementEntity;
        if (entity == null) {
            entity = SetMovement(newValue);
        } else {
            entity.ReplaceMovement(newValue);
        }
    }

    public void RemoveMovement() {
        movementEntity.Destroy();
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

    public Movement movement { get { return (Movement)GetComponent(InputComponentsLookup.Movement); } }
    public bool hasMovement { get { return HasComponent(InputComponentsLookup.Movement); } }

    public void AddMovement(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.Movement;
        var component = (Movement)CreateComponent(index, typeof(Movement));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMovement(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.Movement;
        var component = (Movement)CreateComponent(index, typeof(Movement));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMovement() {
        RemoveComponent(InputComponentsLookup.Movement);
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

    static Entitas.IMatcher<InputEntity> _matcherMovement;

    public static Entitas.IMatcher<InputEntity> Movement {
        get {
            if (_matcherMovement == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Movement);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMovement = matcher;
            }

            return _matcherMovement;
        }
    }
}
