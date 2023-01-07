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

        public Power(float attack, float hp, float mp)
        {
            this._attackDamage = attack;
            this._hp = hp;
            this._mp = mp;
        }
        
        public Power UpgradePower(float factor)
        {
            return new Power(factor * this._attackDamage, factor * this._hp, factor * this._mp);
        }
    }
}