namespace UI.Healthbar
{

    public class HealthbarModel
    {
        private float _value;

        public float Value => _value;

        public void SetValue(float value)
        {
            _value = value >= 0 ? value : _value;
        }
    }

}