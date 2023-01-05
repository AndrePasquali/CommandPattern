using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace HeartAttackGames.DesignPatterns.Command
{
    public class CommandController : MonoBehaviour
    {
        private Queue<ICommand> _commands = new Queue<ICommand>();

        private ICommand _currentCommand;

        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            ListenForCommands();
        }

        private void ListenForCommands()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hitInfo))
                {
                    MoveCommand moveCommand = new MoveCommand(hitInfo.point, _agent);
                }
            }
        }

        public void ProcessCommands()
        {
            if (_currentCommand == null || !_currentCommand.IsFinished())
                return;

            if (!_commands.Any())
                return;

            _currentCommand = _commands.Dequeue();
            _currentCommand.Execute();

        }
    }
}
