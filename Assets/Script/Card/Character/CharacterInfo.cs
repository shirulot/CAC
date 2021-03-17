// 10
// 3/8作为基础模板 

using System;
using System.Collections.Generic;

public class CharacterInfo
{
    //角色被破坏获得的分数
    public int Score;

    //出场消费
    public int Cost;

    //角色能力是否可用
    public bool EffectEnable = true;

    // 当前hp
    public int Hp;

    //初始hp
    public int MaxHp;

    //攻击力
    public int Attack;

    //攻击次数
    public int AttackCount = 1;

    //护盾
    public int Aegis = 0;

    // 步数
    public int Mobility;

    // 最大步数（暂不采用）
    public int maxMove;

    //是否可以反击 默认为是
    public bool CanCounter = true;

    // 是否已破坏 默认为否
    public bool IsBreak = false;

    // 超反击 默认为否
    public bool SuperCounter = false;

    // 超连击 默认为否
    public bool SuperComboHit = false;

    //命中率
    public int HitRate = 100;

    //反击次数
    public int CounterCount = 1;

    //已反击次数
    public int CountedCount = 0;
    
    // 已移动的次数
    public int Moved = 0;

    //回避率
    public int Avoid = 5;
    
    public List<Type> BreakLockTypes = new List<Type>();  

    public CharacterInfo Init(
        int hitRate = 100,
        int counterCount = 1,
        int attackCount = 1,
        int avoid = 5,
        bool superComboHit = false,
        bool superCounter = false,
        bool isBreak = false,
        bool canCounter = true,
        int mobility = 0,
        int moved = 1,
        int aegis = 0,
        int attack = 0,
        int maxHp = 0,
        int hp = 0,
        int countedCount = 0,
        int score = 0,
        int cost = 0
    )
    {
        this.Score = score;
        this.HitRate = hitRate;
        this.CounterCount = counterCount;
        this.CountedCount = countedCount;
        this.AttackCount = attackCount;
        this.Avoid = avoid;
        this.SuperComboHit = superComboHit;
        this.SuperCounter = superCounter;
        this.IsBreak = isBreak;
        this.CanCounter = canCounter;
        this.Mobility = mobility;
        this.Aegis = aegis;
        this.Attack = attack;
        this.MaxHp = maxHp;
        this.Hp = hp;
        this.Cost = cost;
        this.Moved = moved;
        return this;
    }
}