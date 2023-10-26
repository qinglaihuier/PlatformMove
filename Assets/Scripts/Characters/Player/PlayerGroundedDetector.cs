using UnityEngine;

namespace  Characters.Player
{
    public class PlayerGroundedDetector : MonoBehaviour
    {
        [SerializeField] private float detectionRadius;

        private int _groundLayer;

        private readonly Collider[] _colliders = new Collider[1];

        private void Awake()
        {
            _groundLayer = LayerMask.GetMask("Ground");
        }

        public bool IsGround => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, _colliders, _groundLayer) != 0;
        
    }
}

