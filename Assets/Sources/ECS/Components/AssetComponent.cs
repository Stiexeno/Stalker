using Entitas;
using UnityEngine;

public sealed class AssetComponent : IComponent
{
	public string value;
	public Vector3 position;
	public Transform parent = null;
	public bool prewarm;
}