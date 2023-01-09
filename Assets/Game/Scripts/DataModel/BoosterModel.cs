using System;

namespace Game.Scripts.DataModel
{
    public class BoosterModel
    {

        public BoosterTypeEnum Type
        {
            get => _type;
            set => _type = value;
        }

        public int Cost
        {
            get => _cost;
            set => _cost = value;
        }

        public float Cooldown
        {
            get => _cooldown;
            set => _cooldown = value;
        }

        public string Info
        {
            get => _info;
            set => _info = value;
        }

        public enum BoosterTypeEnum
        {
            HpMotion,
            MpMotion
        }

        private string _id;
        private BoosterTypeEnum _type;

        public BoosterModel(string id, BoosterTypeEnum type, int cost, float cooldown, string info)
        {
            _id = id;
            _type = type;
            _cost = cost;
            _cooldown = cooldown;
            _info = info;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        private int _cost;
        private float _cooldown;
        private string _info;

        public virtual void Use(Action callback)
        {
            callback?.Invoke();
        }
    }
}