using Framework.GraphView;

namespace Framework.Bot.ECS
{
    public class ECSAgent : BTAgent
    {
        private ECSParams _ecsParams;
        private Contexts _contexts;

        public void Setup(GameEntity entity, Contexts contexts)
        {
            _ecsParams.entity = entity;
            _ecsParams.contexts = contexts;
		
            foreach (GraphBehaviour graphBehaviour in treeInstance.nodes)
            {
                if (graphBehaviour is IECSNode ecsNode)
                {
                    ecsNode.Initialize(_ecsParams);
                }
            }
        }
    }
}
