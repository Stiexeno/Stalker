using DG.Tweening;
using Framework;
using Framework.Bot.ECS;
using Framework.Generated;
using UnityEngine;
using UnityEngine.AI;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class EnemyBehaviour2 : CharacterBehaviour2, IDamageReceivedFromAttackerListener, IDeadListener
    {
        // Serialized fields
        
        [SF] private NavMeshAgent agent;
        [SF] private ECSAgent ecsAgent;
        
        [SF] private Renderer renderer;

        // Private fields

        private Transform target;
        
        private static readonly int flashProperty = Shader.PropertyToID("_FlashAmount");
        private IEffectFactory effectFactory;

        // Properties

        //EnemyBehaviour

        [Inject]
        private void Construct(IEffectFactory effectFactory)
        {
            this.effectFactory = effectFactory;
        }

        protected override void OnInit()
        {
            base.OnInit();
            
            Entity.isEnemy = true;
            Entity.AddMovementSpeed(50f);
            Entity.AddDirection(Vector2.zero);
            Entity.AddAgent(agent);
            
            Entity.AddDamageReceivedFromAttackerListener(this);
            Entity.AddDeadListener(this);

            ecsAgent.Setup(Entity, Context);
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        protected override void OnProcess(in float deltaTime)
        {
            base.OnProcess(in deltaTime);
            
            ecsAgent.Process();
        }

        //private void Update()
        //{
        //    if (target == null)
        //    {
        //        if (FindObjectOfType<PlayerBehaviour>() != null)
        //        {
        //            target = GameObject.FindObjectOfType<PlayerBehaviour>().transform;
        //            
        //        }
        //        return;
        //    }
        //    
        //    agent.SetDestination(target.position);
        //}

        public void OnDamageReceivedFromAttacker(GameEntity entity, GameEntity value)
        {
            var materialBlock = new MaterialPropertyBlock();
            materialBlock.SetFloat(flashProperty, 1);
            DOVirtual.Float(0.9f, 0, 0.08f, val =>
                {
                    renderer.GetPropertyBlock(materialBlock);
                    materialBlock.SetFloat(flashProperty, val);
                    renderer.SetPropertyBlock(materialBlock);
                })
                .SetEase(Ease.OutSine).SetUpdate(true);
            
            var effect = effectFactory.Take(Assets.Effects.Rifle_Hit_Blood, transform.position);
            effect.transform.rotation = Quaternion.LookRotation(value.direction.value, Vector3.forward);
        }

        public void OnDead(GameEntity entity)
        {
            animancer.Play(deathClip);
        }
    }
}
