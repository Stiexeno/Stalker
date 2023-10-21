using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class RuleTileWindow : EditorWindow
    {
	    private static RuleTile ruleTile;

	    // Serialized fields
	
    	// Private fields
	    
	    public Sprite[] sprites = Array.Empty<Sprite>();
	    private SerializedObject so;
	
    	// Properties
	
    	//RuleTileWindow

	    private void OnEnable()
	    {
		    ScriptableObject target = this;
		    so = new SerializedObject(target);
	    }

	    private void OnGUI()
	    {
		    if (ruleTile == null)
			    return;

		    GUI.enabled = false;
		    ruleTile = EditorGUILayout.ObjectField($"{ruleTile.name}:", ruleTile, typeof(RuleTile), false) as RuleTile;
		    GUI.enabled = true;
		    
		    so.Update();
		    var spritesProperty = so.FindProperty("sprites");
		    EditorGUILayout.PropertyField(spritesProperty, true);
		    so.ApplyModifiedProperties();
		    //sprites = EditorGUILayout.ObjectField("Sprites:", sprites, typeof(Sprite[]), false) as Sprite[];
		    
		    Generate();
		    Sample();
	    }

	    private void Sample()
	    {
		    if (GUILayout.Button("Sample"))
		    {
			    var output = "";
			    var vectorOutput = "";
			    for (int i = 0; i < ruleTile.m_TilingRules.Count; i++)
			    {
				    var rule = ruleTile.m_TilingRules[i];
                    
				    output += $"new [] {{ ";
				    vectorOutput += $"new [] {{ ";
				    for (int k = 0; k < rule.m_Neighbors.Count; k++)
				    {
					    Debug.LogError(rule.m_Neighbors.Count);
					    output += $"{(int)rule.m_Neighbors[k]}";
					    vectorOutput += $"new Vector3Int{rule.m_NeighborPositions[k]}";
//
					    if (k != rule.m_Neighbors.Count - 1)
					    {
						    output += ", ";
						    vectorOutput += ", ";
					    }
				    }
				    
				    output += $" }},\n";
				    vectorOutput += $" }},\n";
			    }
			    
			    //new [] { 2, 2, 0, 2, 1, 0, 1, 1},
			    
			    Debug.LogError(output);
			    Debug.LogError(vectorOutput);
		    }
	    }

	    private void Generate()
	    {
		    if (GUILayout.Button("Generate"))
		    {
			    ruleTile.m_DefaultSprite = sprites[0];
			    ruleTile.m_DefaultGameObject = null;
			    ruleTile.m_TilingRules.Clear();
                
			    for (int i = 0; i < sprites.Length; i++)
			    {
				    if (i > RuleTileSet.rules.Length - 1)
					    break;
				    
				    var rule = new RuleTile.TilingRule();
				    rule.m_Sprites[0] = sprites[i];
				    rule.m_Neighbors = RuleTileSet.rules[i].ToList();
				    rule.m_NeighborPositions = RuleTileSet.positions[i].ToList();
			    
				    ruleTile.m_TilingRules.Add(rule);
			    }
		    }
	    }

	    private static void Open(RuleTile ruleTile)
	    {
		    RuleTileWindow.ruleTile = ruleTile;
		    var window = GetWindow<RuleTileWindow>(false, "Installer", true);
		    window.titleContent = new GUIContent("Rule Tile");
		    window.Show();
	    }

	    [OnOpenAsset]
	    public static bool OpenAsset(int instanceId, int line)
	    {
		    var root = EditorUtility.InstanceIDToObject(instanceId) as RuleTile;

		    if (root == null)
			    return false;

		    Open(root);
		    return true;
	    }
    }
}

public static class RuleTileSet
{
	public static int[][] rules = {
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 2 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 2 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 2 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 2 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 2 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 2 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 2 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 1, 1, 1, 1, 2 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 1, 1, 1, 2, 2, 2 },
		new [] { 2, 2, 2, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 1, 1, 1, 1, 1 },
		new [] { 2, 2, 2, 1, 1, 1 }
	};

	public static Vector3Int[][] positions =
	{
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(0, 1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 0, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(0, 1, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(1, -1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(1, 0, 0) },
		new [] { new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 1, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(1, 1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0) },
		new [] { new Vector3Int(-1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0) },
		new [] { new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 1, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0) },
		new [] { new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(1, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0) },
		new [] { new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0) },
		new [] { new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(1, -1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(-1, -1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(-1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0), new Vector3Int(-1, 1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(-1, 0, 0), new Vector3Int(-1, 1, 0), new Vector3Int(0, 1, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(0, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0), new Vector3Int(1, 1, 0) },
		new [] { new Vector3Int(1, -1, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, -1, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0), new Vector3Int(-1, 0, 0) },
	};
}
