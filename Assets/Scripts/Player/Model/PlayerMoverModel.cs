namespace Player.Model
{

    public class PlayerMoverModel
    {
        private float _movementSpeed = 6.0f; //Задать вопрос про задание значений полей модели через инспектор

        public float MovementSpeed => _movementSpeed;

        public void SetMovementSpeed(float movementSpeed)
        {
            _movementSpeed = movementSpeed >= 0 ? movementSpeed : 0;
        }
    }

}
