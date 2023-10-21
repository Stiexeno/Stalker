using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique, Input] public sealed class Movement : IComponent { public Vector2 value; }
[Unique, Input] public sealed class Aiming : IComponent { public Vector2 value; }
[Unique, Input] public sealed class AttackStarted : IComponent { }
[Unique, Input] public sealed class AttackPressed : IComponent { }

[Unique, Input] public sealed class ReloadStarted : IComponent { }
[Unique, Input] public sealed class ReloadPressed : IComponent { }