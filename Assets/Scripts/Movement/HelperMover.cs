using Environment;
using System.Collections;
using UnityEngine;

namespace Movement
{
    public class HelperMover : Mover
    {
        private const float MaximumRandomChanceValue = 100f;
        private const float NearMaximumRandomChanceValue = 95f;
        private const float MaximumAngleYValue = 110f;
        private const float AngleX = 0f;
        private const float AngleZ = 0f;

        [SerializeField] private float _obstacleDictance;
        [SerializeField] private float _fromPlayerDictance;
        [SerializeField] private float _zOffset = 3f;
        [SerializeField] private float _xOffset = 3f;
        [SerializeField] private float _delay;
        [SerializeField] private Transform _player;
        [SerializeField] private LayerMask _layerMask;

        private bool _needUp = true;
        private bool _wallCollision = false;
        private float _angleY;

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall wall))
            {
                if (_wallCollision == false)
                {
                    _wallCollision = true;
                }

                Rotate(_player.position);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall wall))
            {
                _wallCollision = false;
            }
        }

        public override void Move()
        {
            if (_needUp && Shooter.IsShooting)
            {
                Rigidbody.velocity = Vector3.zero;
                AnimatorController.Shoot();
                return;
            }

            AnimatorController.Run();

            if (_player != null && Vector3.Distance(_player.position, transform.position) > _fromPlayerDictance)
            {
                float randomZ = Random.Range(-_zOffset, _zOffset);
                float randomX = Random.Range(-_xOffset, _xOffset);
                Vector3 newRotation = new Vector3(_player.position.x + randomX, _player.position.y, _player.position.z + randomZ);
                Rotate(newRotation);
            }

            Vector3 newPosition = transform.position + transform.forward * MovingSpeed * Time.deltaTime;
            Rigidbody.MovePosition(newPosition);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, StopMovingDistance, _layerMask))
            {
                float randomChance = Random.Range(0, MaximumRandomChanceValue);

                if (hit.distance < _obstacleDictance || randomChance > NearMaximumRandomChanceValue)
                {
                    _angleY = Random.Range(-MaximumAngleYValue, MaximumAngleYValue);
                    Vector3 newAngle = new Vector3(AngleX, _angleY, AngleZ);
                    transform.eulerAngles = newAngle;
                }
            }
        }

        public void StandUp()
        {
            _needUp = true;
            AnimatorController.StandUp();
            StartCoroutine(StartDelay());
        }

        private IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(_delay);
            AnimatorController.StopStandUp();
            yield return new WaitForSeconds(_delay);
            _needUp = false;
        }
    }
}
