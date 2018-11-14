using UnityEngine;
using UnityEngine.Events;

namespace Game.Detail
{
    [System.Serializable]
    public class PlayerMover
    {
        [SerializeField]
        private UnityEvent StartedMoveDelegate;
        [SerializeField]
        private UnityEvent StopedMoveDelegate;

        [SerializeField]
        private float speed;
        [SerializeField]
        private Transform content;

        private bool isActive;
        private Vector2 destination;

        public void MoveTo(Vector2 destination)
        {
            this.destination = destination;

            if (destination.x < content.position.x)
                content.rotation = Quaternion.Euler(0, 180, 0);
            else
                content.rotation = Quaternion.Euler(0, 0, 0);

            if (!isActive)
            {
                isActive = true;
                StartedMoveDelegate.Invoke();
            }
        }

        public void Update()
        {
            if (isActive)
            {
                if (Vector2.Distance(content.position, destination) <= 0.1f)
                {
                    isActive = false;
                    StopedMoveDelegate.Invoke();
                }
                else
                    content.position = Vector2.MoveTowards(content.position, destination, speed*Time.deltaTime);
            }
        }
    }
}
