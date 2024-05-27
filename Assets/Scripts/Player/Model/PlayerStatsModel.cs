namespace Player.Model
{
    public class PlayerStatsModel
    {
        private float _health;

        public float Health => _health;

        public PlayerStatsModel(float health)
        {
            _health = health;
        }
        
        public void SetHealth(float health)
        {
            _health = health >= 0 ? health : _health;
        }
    }
}