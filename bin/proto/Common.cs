// 物品类型
public enum ItemType
{
    Reserved0 = 0,
    Gun = 1,            // 枪
    Handgun = 2,        // 手枪
    Missile = 3,        // 投掷武器
    Sword = 4,          // 近战武器
    Bullet = 5,         // 子弹
    Reserved3 = 6,
    Clip = 7,           // 弹夹
    Sight = 8,          // 瞄具
    Reserved1 = 9,
    Hair = 10,          // 头发
    Helmet = 11,        // 头盔
    Shoes = 12,         // 鞋子
    Shirt = 13,         // 衬衫
    Legs = 14,          // 裤子
    Armor = 15,         // 避弹衣
    Jacket = 16,        // 上衣
    Bag = 17,           // 背包
    Belt = 18,          // 腰带
    Mask = 19,          // 面具
    Glasses = 20,       // 眼镜
    Gloves = 21,        // 手套
    Hat = 22,           // 帽子
    R1 = 23,
    R2 = 24,
    R3 = 25,
    R4 = 26,
    Medicine = 27,      // 药
    Vehicle = 28,       // 载具
}

public enum SlotNumber
{
    Invalid = -1,
    Body = 0,
    Face = 1,
    Eyes = 2,
    Hair = 3,
    Eyelashes = 4,  // 睫毛
    Hat = 8,        // 帽子
    Helmet = 9,     // 头盔
    Shoes = 10,     // 鞋子
    Shirt = 11,     // 衬衫
    Legs = 12,      // 裤子
    Armor = 13,     // 避弹衣
    Jacket = 14,    // 上衣
    Back = 15,      // 背包
    Belt = 16,      // 腰带
    Mask = 17,      // 面具
    Glasses = 18,   // 眼镜
    Gloves = 19,    // 手套
    MaxCount
}

public static class CommonUtil
{
    public static SlotNumber ItemTypeToSlotNumber(int itemType)
    {
        switch (itemType)
        {
            case (int)ItemType.Hair:
                return SlotNumber.Hair;
            case (int)ItemType.Helmet:
                return SlotNumber.Helmet;
            case (int)ItemType.Shoes:
                return SlotNumber.Shoes;
            case (int)ItemType.Shirt:
                return SlotNumber.Shirt;
            case (int)ItemType.Legs:
                return SlotNumber.Legs;
            case (int)ItemType.Armor:
                return SlotNumber.Armor;
            case (int)ItemType.Jacket:
                return SlotNumber.Jacket;
            case (int)ItemType.Bag:
                return SlotNumber.Back;
            case (int)ItemType.Belt:
                return SlotNumber.Belt;
            case (int)ItemType.Mask:
                return SlotNumber.Mask;
            case (int)ItemType.Glasses:
                return SlotNumber.Glasses;
            case (int)ItemType.Gloves:
                return SlotNumber.Gloves;
            case (int)ItemType.Hat:
                return SlotNumber.Hat;
        }

        return SlotNumber.Invalid;
    }
}

// 玩家身上的武器挂载点位置
public enum BodySlotPosition
{
    Invalid               = -1, // 无效
    LeftShouder_Gun1      = 0,  // 枪挂载点---左肩
    RightShouder_Gun2     = 1,  // 枪挂载点---右肩
    RightLeg_HandGun      = 2,  // 手枪挂载点---右腿
    WaistRight_Explosion  = 3,  // 手雷挂载点---右腰
    WaistBack_Sword       = 4,  // 刀棍挂载点---后腰
}

// 投掷爆炸物类型
public enum ExplosionType
{
    Grenade         = 0, //手雷
    Smoking         = 1, //烟雾弹
    Burning         = 2, //燃烧弹
    Wave            = 3, //震爆弹
}

namespace SurviveGame
{
    public class ConstValue
    {
        public static int MAXHP = 100; //最大血量
    }
}

//身体部件类型定义
public enum BodyPartType
{
    Hip = 0,            // 腹部
    Spine,              // 躯干
    Head,
    LeftUpperLeg,
    LeftLowerLeg,
    RightUpperLeg,
    RightLowerLeg,
    LeftUpperArm,
    LeftLowerArm, 
    RightUpperArm,
    RightLowerArm,
    Neck,               // 颈部
    LeftFoot,
    RightFoot,

}

//登录Json数据
public class LoginDataJson
{
    public int code;
    public string msg;
    public LoginData data;
    public class LoginData
    {
        public string guid;
        public bool fcm;
    }
}

//注册Json数据
public class RegisterDataJson
{
    public int code;
    public string msg;
    public RegisterData data;
    public class RegisterData
    {
        public string guid;
        public bool fcm;
    }
}

//支付请求Json数据
public class PayRequestDataJson
{
    public int code;
    public string msg;
    public PayRequestData data;
    public class PayRequestData
    {
        public string url;
    }

}

//支付回掉Json数据
[System.Serializable]
public class PayCallbackDataJson
{
    public int code;
    public string msg;
    public PayCallbackData data;

    [System.Serializable]
    public class PayCallbackData
    {
        public string orderNo;
        public string time;
        public string sign;
    }

}