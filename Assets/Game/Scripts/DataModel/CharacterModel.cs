using System.Collections.Generic;

namespace Game.Scripts.DataModel
{
    public class CharacterModel
    {
        private string _id;
        private string _name;
        private int _level;
        private Power _power;
        private List<OutfitModel> _outfits;
        private CharacterStateEnum _characterState;
        private float _speed;

        public CharacterModel(string id, string name, int level, Power power, List<OutfitModel> outfits, CharacterStateEnum characterState, float speed, List<WeaponModel> weapons)
        {
            _id = id;
            _name = name;
            _level = level;
            _power = power;
            _outfits = outfits;
            _characterState = characterState;
            _speed = speed;
            _weapons = weapons;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
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

        public List<OutfitModel> Outfits
        {
            get => _outfits;
            set => _outfits = value;
        }

        public CharacterStateEnum CharacterState
        {
            get => _characterState;
            set => _characterState = value;
        }

        public List<WeaponModel> Weapons
        {
            get => _weapons;
            set => _weapons = value;
        }

        public Power Power
        {
            get => _power;
            set => _power = value;
        }

        private List<WeaponModel> _weapons;
    }
    
    public enum CharacterStateEnum
    {
        Idle,
        Run,
        Attack,
        Death
    }
}