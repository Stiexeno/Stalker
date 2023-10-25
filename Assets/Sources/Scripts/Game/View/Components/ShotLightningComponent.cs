using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Roguelite;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using SF = UnityEngine.SerializeField;

    public class ShotLightningComponent : MonoBehaviour, IEntityComponent, IShotListener
    {
    	// Serialized fields

    	[SF] private Light2D light2d;
        
    	// Private fields

        private float initialRadius;
        private TweenerCore<float, float, FloatOptions> tween;

        // Properties

    	// ShotLightningComponent
        
        public void Initialize(EntityView entityView)
        {
	        entityView.Entity.AddShotListener(this);
	        
	        initialRadius = light2d.pointLightOuterRadius;
        }

        public void OnShot(GameEntity entity)
        {
	        if (light2d != null)
	        {
		        if (tween != null)
			        tween.Kill(true);
		        
		        tween = DOTween.To(() => light2d.pointLightOuterRadius, x => light2d.pointLightOuterRadius = x, initialRadius * 1.5f, 0.1f)
			        .SetEase(Ease.OutSine)
			        .OnComplete(() =>
			        {
				        DOTween.To(() => light2d.pointLightOuterRadius, x => light2d.pointLightOuterRadius = x, initialRadius, 0.1f)
					        .SetEase(Ease.OutSine);
			        });
	        }
        }
    }