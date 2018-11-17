using UnityEngine;
using UnityEngine.Events;

namespace Game.Detail
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent LosedDelegate;
        [SerializeField]
        private int maxLifes;
        [SerializeField]
        private PlayerJumper jumper;
        [SerializeField]
        private PlayerMover mover;
        [SerializeField]
        private ObjectSelector objectSelector;

        private bool wasJump;
        private int currentLifes;

        public void OnReachObject()
        {
            if(objectSelector.CurrentObject.MustJump)
                jumper.JumpTo(objectSelector.CurrentObject.GetJumpPosition());
            else
                objectSelector.CurrentObject.OnReachedOobject();
        }

        public void OnSuccess()
        {
            objectSelector.CurrentObject.Clear();
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

        public void OnFailed()
        {
            currentLifes = Mathf.Clamp(currentLifes - 1, 0, maxLifes);
            if (currentLifes == 0)
                LosedDelegate.Invoke();
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

        private void Start()
        {
            currentLifes = maxLifes;
        }
    }
}
