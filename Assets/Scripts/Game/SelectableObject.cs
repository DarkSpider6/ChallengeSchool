using UnityEngine;

namespace Game.Detail
{
    public class SelectableObject : MonoBehaviour
    {
        [SerializeField]
        private Transform movePoint;

        public Vector2 GetPosition()
        {
            return movePoint.position;
        }

    }
}
