CG MsgGameSceneInfo CGConnectGameServer(int64 id) = 5000;

CG bool CGEnterGame() = 5001;

//准备倒计时
GC void GCReadyCountdown(int32 id) = 5100;

//开始游戏
GC void GCStartFight(int64 param) = 5101;

// 轰炸区域
GC void GCBombArea(int32 id, FloatVector3 startPosition, FloatVector3 bombPosition, float radius, float flySpeed) = 5110;
// 执行轰炸
GC void GCDoBomb(MsgBombPointList bombList) = 5111;

GC void GCBombEnd(int32 id) = 5112;

//拾取物品
CG bool CGPickupItem(int64 id, int64 gunId) = 5201;

//切换武器
CG void CGChangeWeapon(MsgSwitchWeapon msg) = 5202;

GC void GCPickupItem(MsgPickupItem item) = 5203;

CG bool CGAddToGun(int64 id, int64 gunId) = 5204;

CG bool CGThrowWeapon(int64 id, FloatVector3 pos) = 5205;

GC bool GCAddSceneItem(SceneItems ItemList) = 5206;

CG MsgRemoveGunPart CGRemoveGunPart(int64 id, int32 gunIndex) = 5207;

// 从背包装子弹
CG MsgReloadBullet CGReloadBullet(int64 gunId) = 5208;

// 开枪
CG void CGFire(int64 gunId, int32 bulletNum) = 5209;

// 丢弃物品(背包)
CG bool CGThrowItem(int64 id, FloatVector3 pos) = 5210;

// 丢弃身上物品
CG bool CGThrowBodyItem(int32 slotPos, FloatVector3 pos) = 5211;

// 穿戴或删除衣服
GC void GCWearItem(MsgWearItem item) = 5212;

//使用药品
CG void CGUseItemComplete()=5213;

//广播使用药品的事件
GC void GCBroadcastUseDrag(MsgUseDragInfo msg)=5214;

//使用物品
CG bool CGUseItem(int64 id)=5215;

//广播加血的事件
GC void GCBroadcastAddHp(MsgPlayerAddHpInfo info)=5216;

// 拾取宝箱内物品
CG bool CGPickupBoxItem(int64 boxUId, int64 itemUId, int64 gunId) = 5217;
// 删除物品
GC void SCDestroyItem(int64 id) = 5218;
// 删除载具
GC void SCDestroyVehicle(int64 id) = 5219;
//添加宝箱
GC void GCAddSceneBoxItem(SceneBoxItem boxItem)=5220;
// 拾取枪
CG MsgPickupItem CGPickGun(int64 id, int32 bagPos, FloatVector3 position) = 5221;
// 补给飞机
GC void GCFlyAirdrop(FloatVector3 startPosition, FloatVector3 supplyPosition, int64 boxId, float speed, float dropSpeed) = 5222;
// 投补给
GC void GCThrowSupply(int64 id, FloatVector3 throwPosition, float speed, FloatVector3 endPosition) = 5223;
// 查找有效的点
GC void GCFindGroundPosition(FloatVector3List posList) = 5224;
// 有效点索引
CG void CGGoundPositionIndex(Dict_int_float_Data indexs) = 5225;
// 背包切换枪
CG bool CGBagSwitchGun(int32 index1, int32 index2) = 5226;
// 交换枪上的部件
CG bool CGSwitchGunPart(int32 dragGunIndex, int64 dragPartId, int32 dropGunIndex) = 5227;
// 切换开火模式
CG bool CGSwitchFireMode() = 5228;

//通知服务器自身标记点改变
CG void CGChangeMarkPos(FloatVector3 vec3) = 5300;

//服务器广播标记点
GC void GCBroadCastPos(MsgTeamMemberMarkList posList) = 5301;

//客户端通知服务器改变可交互物体的状态
CG bool CGChangeInteractiveState(int32 dataId, int32 state) = 5302;

//服务器广播客户端可交互物体的状态
GC void GCBroadCastInteractiveState(MsgInteractiveList list) = 5303;

//服务器广播玩家信息
GC void GCBattlePlayerInfo(MsgBattlePlayerInfo Attr) = 5304;

//请求服务器队伍地图位置
CG void CGChangeMapPos()=5305;

//服务器广播玩家地图位置
GC void GCBroadCastMapPos(MsgMapPosList info)=5306;

//服务器广播登机信息
GC void GCBoarding(MsgPlaneInfo info)=5307;
//服务器广播进入跳伞区域
GC void GCGoSkyDive()=5308;
//服务器广播强制跳伞
GC void GCForceSkyDive()=5309;
//删除背包物品
GC void GCDeleteBagItem(int64 id)=5310;
//打断使用物品
CG void CGBreakUseDrag()=5311;
// 通知服务器退出游戏了
CG void CGLeaveGame() = 5312;
// 离开游戏了
GC void GCLeaveGame(int64 playerId) = 5313;

//广播加能量的事件
GC void GCBroadcastAddEnergy(MsgPlayerAddEnergyInfo info)=5314;

//玩家连进游戏
GC void GCPlayerConnected(int64 playerId,string name) = 5400;
//玩家断开链接
GC void GCPlayerLostConnection(int64 playerId) = 5401;

//进入濒临死亡状态 shooter是攻击者，blood是救援血量
GC void GCEnterDyingState(int64 targetId,int64 shooter,int32 damageType,int32 weaponId,int32 blood) = 5403;

//被救援 playerId救援了targetId
GC void GCRescueByPlayer(int64 targetId,int64 playerId,int32 hp) = 5404;

//救援队友
CG void CGRescueTeammate(int64 id) = 5405;













//Debug用
CG void CGDebugCommand(string cmd) = 5999;
