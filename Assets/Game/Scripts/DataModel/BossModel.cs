using System.Collections.Generic;
using Game.Scripts.DataModel;
using MoreMountains.CorgiEngine;

public class BossModel : CharacterModel
{
    public enum BossTypeEnum
    {
        BigBoss,
        NonBoss
    }

    private BossTypeEnum _bossType;

    public BossModel(string id, string name, int level, Power power, List<OutfitModel> outfits, CharacterStateEnum characterState, float speed, List<WeaponModel> weapons, BossTypeEnum bossType) : base(id, name, level, power, outfits, characterState, speed, weapons)
    {
        _bossType = bossType;
    }

    public BossTypeEnum BossType
    {
        get => _bossType;
        set => _bossType = value;
    }
}