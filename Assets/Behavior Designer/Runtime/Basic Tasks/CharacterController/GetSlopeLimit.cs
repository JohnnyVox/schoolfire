using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
    [TaskCategory("Basic/CharacterController")]
    [TaskDescription("Stores the slope limit of the CharacterController. Returns Success.")]
    public class GetSlopeLimit : Action
    {
        [Tooltip("The slope limit of the CharacterController")]
        public SharedFloat storeValue;

        private CharacterController characterController;

        public override void OnAwake()
        {
            characterController = gameObject.GetComponent<CharacterController>();
        }

        public override TaskStatus OnUpdate()
        {
            if (characterController == null) {
                Debug.LogWarning("CharacterController is null");
                return TaskStatus.Failure;
            }

            storeValue.Value = characterController.slopeLimit;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (storeValue != null) {
                storeValue.Value = 0;
            }
        }
    }
}