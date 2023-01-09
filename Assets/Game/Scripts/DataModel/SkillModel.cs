namespace Game.Scripts.DataModel
{
    public class SkillModel
    {
        private string _id;
        private string _name;
        private int _level;
        private float _damage;
        private float _travelDistance;
        private float _cooldown;

        public SkillModel(string id, string name, int level, float damage, float travelDistance, float cooldown)
        {
            _id = id;
            _name = name;
            _level = level;
            _damage = damage;
            _travelDistance = travelDistance;
            _cooldown = cooldown;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public float TravelDistance
        {
            get => _travelDistance;
            set => _travelDistance = value;
        }

        public float Cooldown
        {
            get => _cooldown;
            set => _cooldown = value;
        }
    }
}