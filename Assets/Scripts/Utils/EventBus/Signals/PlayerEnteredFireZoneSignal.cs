namespace Utils.EventBus.Signals
{
    public class PlayerEnteredFireZoneSignal
    {
        private float _damage;

        public float Damage => _damage;
        
        public PlayerEnteredFireZoneSignal(float damage)
        {
            _damage = damage;
        }
    }
}