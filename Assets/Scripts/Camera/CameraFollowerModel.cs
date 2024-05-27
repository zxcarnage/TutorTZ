namespace Camera
{
    public class CameraFollowerModel
    {
        private readonly float _smooth;
        
        public float Smooth => _smooth;

        public CameraFollowerModel(float smooth)
        {
            _smooth = smooth;
        }
    }
}