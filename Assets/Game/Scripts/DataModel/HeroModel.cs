using System.Collections.Generic;

namespace Game.Scripts.DataModel
{
    public class HeroModel : CharacterModel
    {
        private string _shoulder;
        private string _armor;
        private List<SkillModel> _mainSkills;
        private List<SkillModel> _subSkills;

        public HeroModel(string id, string name, int level, Power power, List<OutfitModel> outfits,
            CharacterStateEnum characterState, float speed, List<WeaponModel> weapons, string shoulder, string armor,
            List<SkillModel> mainSkills, List<SkillModel> subSkills) : base(id, name, level, power, outfits,
            characterState, weapons)
        {
            _shoulder = shoulder;
            _armor = armor;
            _mainSkills = mainSkills;
            _subSkills = subSkills;
        }
    }
}