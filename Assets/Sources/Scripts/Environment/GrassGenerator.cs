using Framework;
using Framework.Utils;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class GrassGenerator : MonoBehaviour
    {
        // Serialized fields
        
        [SF] private SpriteRenderer grassPrefab;
        
        [SF] private Sprite[] grassTextures;
	
    	// Private fields
	
    	// Properties
	
    	//GrassGenerator

	    private void Awake()
	    {
		    for (int i = 0; i < 1000; i++)
		    {
			    var position = new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f));
			    var grass = Instantiate(grassPrefab, position, Quaternion.identity);

			    var grassTexture = grassTextures.RandomResult();
			    grass.material.mainTexture = grassTexture.texture;
			    grass.sprite = grassTexture;
			    
			    var scale = Random.Range(1f, 1.5f);
			    grass.transform.localScale *= scale;
			    if (Helper.RollChance(50))
			    {
				    grass.flipX = true;
			    }
			    
			    grass.transform.SetParent(transform);
		    }
	    }
    }
}
