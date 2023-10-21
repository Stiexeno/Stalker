using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Framework.Bot;
using Roguelite;
using UnityEngine;
using UnityEngine.AI;

public class EntityBehaviourComponent : IComponent { public EntityView value; }
public class PlayerComponent : IComponent {  }
public class Id : IComponent { [PrimaryEntityIndex] public int value; }
public class OwnerId : IComponent { public int value; }
public class TargetId : IComponent { public int value; }

public class Duration : IComponent { public float value; }
public class DurationLeft : IComponent { public float value; }
public class DurationUp : IComponent {  }

public class Poolable : IComponent {  }
public class SentToPool : IComponent {  }
public class Lifetime : IComponent { public float value; }

public class Destructed : IComponent { }

public class Layer : IComponent { public int value; }

// Health

public class MaxHealth : IComponent { public int value; }
[Event(EventTarget.Self), Event(EventTarget.Any)] public class Health : IComponent { public float value; }  

// Enemy

public class Team : IComponent { public Roguelite.Enums.Team value; }
public class Enemy : IComponent {  }
[Event(EventTarget.Self)] public class Dead : IComponent {  }
public class AttackTarget : IComponent { public GameEntity value; }
public class Agent : IComponent { public NavMeshAgent value; }

// Movement

public class TransformComponent : IComponent {  public Transform value; }
public class Direction : IComponent { public Vector2 value; }
public class MovementSpeed : IComponent { public float value; }
public class Rigidbody : IComponent { public Rigidbody2D value; }

// Weapon

public class WeaponComponent : IComponent { }
public class CurrentWeapon : IComponent { public GameEntity value; }
public class ShootingPoint : IComponent { public Transform value; }
public class Projectile : IComponent { }
public class Ammo : IComponent { public int value; }
public class MaxAmmo : IComponent { public int value; }
public class FireRate : IComponent { public float value; }
public class ShootingCooldown : IComponent { }
public class ReloadingCooldown : IComponent { }
public class ReloadingEntity : IComponent { public GameEntity value; }

public class Damage : IComponent { public int value; }
[Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)] public class DamageReceived : IComponent { public int value; }

// Collisions

[Cleanup(CleanupMode.DestroyEntity)] public sealed class CollisionEvent : IComponent {}
public class CollidedComponent : IComponent { }
public sealed class CollisionIdComponent : IComponent { [EntityIndex] public int value; }
public sealed class CollidedWithComponent : IComponent { public HashSet<int> value = new(); }
public sealed class CollidedTriggerComponent : IComponent { }
public sealed class CollisionTriggerIdComponent : IComponent { [EntityIndex] public int value; }
public sealed class CollisionContactPointComponent : IComponent { public ContactPoint value; }

// AI

public class NodeStatus : IComponent { public BTStatus value; }

// Events

//[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)] public class AttackStarted : IComponent { } 
[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)] public class Attacking : IComponent {}
[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)] public class Pooled : IComponent {}
[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)] public class DamageReceivedFromAttacker : IComponent {public GameEntity value; }
[Event(EventTarget.Self)] public class Reloading : IComponent {}
[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)] public class Reloaded : IComponent {}
[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)] public class WeaponAdded : IComponent {}