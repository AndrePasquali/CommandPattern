using UnityEngine;
using UnityEngine.AI;

namespace HeartAttackGames.DesignPatterns.Command
{
    public class MoveCommand: ICommand
    {
        public readonly Vector3 _destination;
        public readonly NavMeshAgent _agent;

        public MoveCommand(Vector3 destination, NavMeshAgent agent)
        {
            _destination = destination;
            _agent = agent;
        }
        public void Execute()
        {
            _agent.SetDestination(_destination);
        }

        public bool IsFinished() => _agent.remainingDistance <= 0.1F;
    }
}