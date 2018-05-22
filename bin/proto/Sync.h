//刷出其他玩家 
GC void SCSpawnPlayer(MsgSpawnPlayer info) = 6001;

//刷出其他玩家 
GC void SCDestroyObj(int64 id) = 6002;

//同步属性
CG void CSSyncPlayerPosAndDir(int64 id,MsgSyncPlayerPosAndDir msg) = 6003;
GC void SCSyncPlayerPosAndDir(int64 id,MsgSyncPlayerPosAndDir msg) = 6004;

//同步属性
GC void SCSyncPlayerState(int64 id,PlayerActionState msg) = 6005;

//同步属性
CG void CSSyncPlayerState(int64 id,PlayerActionState msg) = 6006;

//玩家伤害
GC void SCPlayerHurt(MsgDamage msg) = 6007;
//玩家伤害
CG void CSPlayerHurt(MsgDamage msg) = 6008;

//玩家死亡
GC void SCPlayerDead(MsgDead msg) = 6009;

//弹孔
CG void CSDecel(MsgDecel msg) = 6011;
//弹孔
GC void SCDecel(MsgDecel msg) = 6012;

//复活
GC void SCRelive(MsgRelive msg) = 6013;

//使用武器
GC void SCUsedWeapon(MsgUsedWeapon msg) = 6014;

//复活
CG void CSRelive(MsgRelive msg) = 6015;

//使用武器
CG void CSUsedWeapon(MsgUsedWeapon msg) = 6016;

//刷一辆载具debug
CG void CSSpawnVehicle(int64 id, MsgSpawnVehicle msg) = 6017;

//上车
CG void CSPlayerGetInVehicle(int64 id, int64 vehicleId, int32 seat) = 6018;

//下车
CG void CSPlayerGetOutVehicle(int64 id, int64 vehicleId) = 6019;

//同步载具状态
CG void CSSyncVehicleState(int64 id, MsgSyncVehicleState msg) = 6020;

//刷载具
GC void SCSpawnVehicle(int64 id, MsgSpawnVehicle msg) = 6021;

//上车
GC void SCPlayerGetInVehicle(int64 id, int64 vehicleId, int32 seat) = 6022;

//下车
GC void SCPlayerGetOutVehicle(int64 id, int64 vehicleId, int32 seat) = 6023;

//同步载具状态
GC void SCSyncVehicleState(int64 id, MsgSyncVehicleState msg) = 6024;

//玩家击杀数量
GC void SCPlayerKill(MsgKill msg) = 6026;

//广播玩家行为
CG void CSPlayerAction(int64 id, MsgSyncPlayerAction msg) = 6027;
GC void SCPlayerAction(int64 id, MsgSyncPlayerAction msg) = 6028;

//广播玩家切换武器
GC void SCChangeWeapon(int64 id, MsgSwitchWeapon msg) = 6029;

//同步新的毒圈
GC void SCCircleStartMove(int64 id, int32 danagerIndex) = 6025;

//同步新的毒圈
GC void SCInitCircle(int64 id, CircleList list) = 6030;

//投掷
CG void CSThrow(int64 playerId, int64 onlyId,FloatVector3 startPos,FloatVector3 direction,float force) = 6031;
GC void SCThrow(int64 playerId, int32 itemId,FloatVector3 startPos,FloatVector3 direction,float force) = 6032;

//玩家伤害
GC void SCTeamPlayerHurt(MsgDamage msg) = 6033;

//广播玩家跳伞的方向操作
CG void CSParachuteInputData(float forward, float right) = 6034;
GC void SCParachuteInputData(int64 id, float forward, float right) = 6035;

//炸弹伤害
CG void CSGrenadeHurt(int64 killerId, int64 targetId, int32 itemId, FloatVector3 hitPoint, FloatVector3 bombPoint) = 6036;

//广播删除载具控制者
CG void CSRemoveVehicleController(int64 VehicleId) = 6037;
GC void SCRemoveVehicleController(int64 VehicleId) = 6038;

//同步我的Voice Member Id
CG void CSSyncMyVoiceID(int32 voiceMemberId) = 6040;

//给队员伍所有同步所有
GC void CSSyncTeamVoiceIDMap(MsgVoiceIDMap msg) = 6041;

//同步附近玩家的可视装备
GC void SCSyncPlayerEquip(int64 id, MsgSynItem item) = 6042;

//载具轮子被击中
CG void CSVehicleWheelHit(int64 VehicleId,int32 wheelIndex) = 6043;
//载具身体被击中
CG void CSVehicleBodyHit(int64 VehicleId) = 6044;
//载具爆胎
GC void SCVehicleBlowOut(int64 VehicleId,int32 wheelIndex) = 6045;
//载具死亡
GC void SCVehicleDead(int64 VehicleId) = 6046;