using UnityEngine;
using UnityEngine.Events;

namespace Game.Detail
{
    public class SelectableObject : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent ReachedDelegate;

        [SerializeField]
        private Transform movePoint;

        public Vector2 GetPosition()
        {
            return movePoint.position;
        }

        public void OnReachedOobject()
        {
            ReachedDelegate.Invoke();
        }
    }
}
