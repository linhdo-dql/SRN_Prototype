namespace Game.Scripts.DataModel
{
    public class Power
    {
        private float _attackDamage;
        public float AttackDamage { get; set; }

        private float _hp;
        public float Hp { get; set; }

        private float _mp;
        public float Mp { get; set; }
        
        private float _speedMovement;
        public float SpeedMovement { get; set; }
        
        private float _speedAttack;
        public float SpeedAttack { get; set; }

        public Power()
        {
            
        }
        
        public Power UpgradePower(float factor)
        {
            return new Power() { Hp = factor * this._hp, Mp = factor * this._mp, AttackDamage = factor * this._attackDamage};
        }
    }
}