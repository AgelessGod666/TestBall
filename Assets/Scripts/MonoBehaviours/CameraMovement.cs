using UnityEngine;

namespace MonoBehaviours
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform ball;
        
        private void FixedUpdate()
        {
            var position = transform.position;
            position = Vector3.Lerp(position, new Vector3(position.x, ball.transform.position.y, position.z), 4f * Time.deltaTime);
            transform.position = position;
        }
    }
}