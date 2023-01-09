using System.Collections.Generic;

namespace Game.Scripts.DataModel
{
    public class WeaponModel
    {
        private string _id;
        private string _name;
        private int _level;
        private List<SkillModel> _skills;
        private int _damage;

        public WeaponModel(string id, string name, int level, List<SkillModel> skills, int damage)
        {
            _id = id;
            _name = name;
            _level = level;
            _skills = skills;
            _damage = damage;
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

        public List<SkillModel> Skills
        {
            get => _skills;
            set => _skills = value;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
    }
}
