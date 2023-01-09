using System.Collections.Generic;
using Game.Scripts.DataModel;

public class EnemyModel : CharacterModel
{
    public enum EnemyTypeEnum
    {
        Lancer,
        Greatsword,
        Gunship
    }

    private EnemyTypeEnum _type;

    public EnemyModel(string id, string name, int level, Power power, List<OutfitModel> outfits,
        CharacterStateEnum characterState, float speed, List<WeaponModel> weapons, EnemyTypeEnum type) : base(id, name,
        level, power, outfits, characterState, speed, weapons)
    {
        _type = type;
    }
}