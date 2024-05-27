namespace Utils.EventBus.Signals
{

    public class PlayerHealthChangedSignal
    {
        private float _value;

        public float Value => _value;

        public PlayerHealthChangedSignal(float value)
        {
            _value = value;
        }
    }

}