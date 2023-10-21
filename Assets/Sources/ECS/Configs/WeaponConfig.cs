using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	[CreateAssetMenu(menuName = "Roguelite/Weapons/Weapon Config")]
    public class WeaponConfig : ScriptableObject
    {
	    public int damage;
	    public float fireRate;
    }
}
