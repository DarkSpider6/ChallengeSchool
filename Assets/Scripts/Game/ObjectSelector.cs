using UnityEngine;

namespace Game.Detail
{
    [System.Serializable]
    public class ObjectSelector
    {
        [SerializeField]
        private LayerMask selectableLayers;

        public SelectableObject LastObject
        {
            get;
            private set;
        }

        public SelectableObject CurrentObject
        {
            get;
            private set;
        }

        public bool WasSelectedInThisFrame
        {
            get;
            private set;
        }
        
        public void Update()
        {
            WasSelectedInThisFrame = false;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, selectableLayers);
                if (hit)
                {
                    LastObject = CurrentObject;
                    CurrentObject = hit.transform.GetComponent<SelectableObject>();
                    WasSelectedInThisFrame = true;
                }
                else
                    CurrentObject = null;
            }
        }
    }
}
