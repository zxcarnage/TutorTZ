using UnityEngine;

namespace Player.Presenter
{
    public class PlayerInputPresenter
    {
        //В теории в модели инпута может содержаться кфг для допустимых клавиш и т.п.
        public Vector2 HandleInput()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            return new Vector2(horizontalInput, verticalInput);
        }
    }
}