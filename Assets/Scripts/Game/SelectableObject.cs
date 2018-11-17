using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Detail
{
    public class SelectableObject : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent ReachedDelegate;
        [SerializeField]
        private UnityEvent ClearDelegate;
        [SerializeField]
        private Transform jumpPoint;
        [SerializeField]
        private Transform movePoint;

        public bool MustJump
        {
            get { return jumpPoint != null; }
        }

        public Vector2 GetPosition()
        {
            return movePoint.position;
        }

        public Vector2 GetJumpPosition()
        {
            return jumpPoint.position;
        }

        public void OnReachedOobject()
        {
            ReachedDelegate.Invoke();
        }

        public void Clear()
        {
            ClearDelegate.Invoke();
        }
    }
}
