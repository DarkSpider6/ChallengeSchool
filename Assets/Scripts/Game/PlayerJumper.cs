using UnityEngine;
using UnityEngine.Events;

namespace Game.Detail
{
    [System.Serializable]
    public class PlayerJumper
    {
        [SerializeField]
        private UnityEvent JumpDelegate;
        [SerializeField]
        private UnityEvent ReachedDelegate;

        [SerializeField]
        private float duration;
        [SerializeField]
        private float delay;
        [SerializeField]
        private float delayToJump;
        [SerializeField]
        private Transform content;

        private bool isActive;
        private Vector2 destination;
        private Vector2 initialPosition;
        private float currentTime;
        private float timeToEnd;
        private float timeToJump;
        private bool isLanded;
        private bool mustStartJump;
        public void JumpTo(Vector2 destination)
        {
            JumpDelegate.Invoke();

            this.destination = destination;

            if (destination.x < content.position.x)
                content.rotation = Quaternion.Euler(0, 180, 0);
            else
                content.rotation = Quaternion.Euler(0, 0, 0);

            isLanded = false;
            initialPosition = content.transform.position;
            timeToJump = Time.time + delayToJump;
            mustStartJump = true;
            if (!isActive)
                isActive = true;
        }

        public void Update()
        {
            if (isActive)
            {
                if(isLanded)
                {
                    if(Time.time >= timeToEnd)
                    {
                        isLanded = false;
                        isActive = false;
                        ReachedDelegate.Invoke();
                    }
                }
                else if (Vector2.Distance(content.position, destination) <= 0.1f)
                {
                    timeToEnd = Time.time + delay;
                    isLanded = true;
                }
                else if(timeToJump <= Time.time)
                {
                    if (mustStartJump)
                    {
                        currentTime = Time.time;
                        mustStartJump = false;
                    }
                    content.position = Vector2.Lerp(initialPosition, destination, (Time.time - currentTime) / duration);
                }
                
            }
        }
    }
}
