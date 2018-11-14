using UnityEngine;

namespace Game.Detail
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerMover mover;
        [SerializeField]
        private ObjectSelector objectSelector;

        private void Update()
        {
            objectSelector.Update();
            if (objectSelector.WasSelectedInThisFrame)
                mover.MoveTo(objectSelector.CurrentObject.GetPosition());
            mover.Update();
        }
    }
}
