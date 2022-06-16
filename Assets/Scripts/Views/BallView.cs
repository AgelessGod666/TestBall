using UnityEngine;

namespace Views
{
    public class BallView
    {
        private readonly Rigidbody ball;
        private float speed = 2;
        private int direction = 1;

        public BallView(Rigidbody ball)
        {
            this.ball = ball;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void StartBall()
        {
            StopBall();
            ball.transform.position = new Vector3(0, 1, -1.1f);
            ball.AddForce(new Vector3(speed * direction, 1, 0), ForceMode.VelocityChange);
        }

        public void ChangeDirection()
        {
            StopBall();
            direction = -direction;
            ball.AddForce(new Vector3(speed * direction, 1, 0), ForceMode.VelocityChange);
        }

        public void StopBall()
        {
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
        }
    }
}