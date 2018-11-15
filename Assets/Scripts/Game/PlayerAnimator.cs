using UnityEngine;

namespace Game.Detail
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string walkParameterName;
        [SerializeField]
        private string jumpParameterName;

        public void StartWalk()
        {
            animator.SetBool(walkParameterName, true);
        }

        public void StopWalk()
        {
            animator.SetBool(walkParameterName, false);
        }

        public void Jump()
        {
            animator.SetTrigger(jumpParameterName);
        }
    }
}
