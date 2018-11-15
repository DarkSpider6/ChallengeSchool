using UnityEngine;

namespace Game.Detail
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerJumper jumper;
        [SerializeField]
        private PlayerMover mover;
        [SerializeField]
        private ObjectSelector objectSelector;

        private bool wasJump;

        public void OnReachObject()
        {
            if(objectSelector.CurrentObject.MustJump)
                jumper.JumpTo(objectSelector.CurrentObject.GetJumpPosition());
            else
                objectSelector.CurrentObject.OnReachedOobject();
        }

        public void OnJumpEnded()
        {
            if (!wasJump)
            {
                objectSelector.CurrentObject.OnReachedOobject();
                wasJump = true;
            }
            else
            {
                mover.MoveTo(objectSelector.CurrentObject.GetPosition());
                wasJump = false;
            }
        }

        private void Update()
        {
            objectSelector.Update();
            if (objectSelector.WasSelectedInThisFrame)
            {
                if(wasJump)
                    jumper.JumpTo(objectSelector.LastObject.GetPosition());
                else
                    mover.MoveTo(objectSelector.CurrentObject.GetPosition());
            }
            mover.Update();
            jumper.Update();
        }
    }
}
