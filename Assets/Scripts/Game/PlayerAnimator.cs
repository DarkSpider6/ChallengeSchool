using UnityEngine;

namespace Game.Detail
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string walkParameterName;

        public void StartWalk()
        {
            animator.SetBool(walkParameterName, true);
        }

        public void StopWalk()
        {
            animator.SetBool(walkParameterName, false);
        }
    }
}
