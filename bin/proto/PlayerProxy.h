
//0-100/////////////////////////////////////////////Debug///////////////////////////////////////////////////////////

//Debug命令
CS void CSDebugCommand(string cmd) = 0;

//100-200/////////////////////////////////////////////System///////////////////////////////////////////////////////////



///////////////////////////////////////////////Player///////////////////////////////////////////////////////////

//创建角色
CS bool CSCreatePlayer(MsgCreateRole msg) = 2001;

//告诉客户端 GameServer信息
SC void SCGameServerInfo(string ip,int32 port) = 2002;

//掉线
SC void SCNotifyErrorCode(uint32 code,int32,param) = 2202;

//客户端主动退出登录
CS bool CSPlayerLogOut() = 2205;




///////////////////////////////////////////////好友///////////////////////////////////////////////////////////

//获得好友列表
CS MsgFriendList CSGetFriendList() = 7000;

//添加好友，如果name为空字符串，就看id
CS FriendUnit CSAddFriend(string name,int64 id) = 7001;

//删除好友，如果name为空字符串，就看id
CS bool CSDelFriend(int64 id) = 7002;

//通知客户端有人申请加好友
SC void SCSyncFriendApplyList(Int64Array id) = 7004;

//获得好友申请列表
CS MsgFriendList CSGetFriendApplyList() = 7007;

//通知客户端被删除好友了
SC void SCBeDelFriend(int64 id) = 7008;

//同意添加为好友
CS bool CSAgreeAddFriend(int64 id, bool ok) = 7009;

// 服务器向客户端广播好友列表
SC bool SCRefreshFriendList(MsgFriendList list) = 7011;

// 添加黑名单
CS bool CSAddBlackList(int64 id) = 7012;

// 从黑名单删除
CS bool CSRemoveFromBlackList(int64 id) = 7013;

// 获得黑名单
CS MsgFriendList CSGetBlackList() = 7014;



///////////////////////////////////////////////匹配///////////////////////////////////////////////////////////

//改变匹配模式 人数
CS bool CSChangeMatchState(int32 type) = 12000;

//改变匹配是否自动添加队友
CS bool CSChangeMatchAutoAdd(bool isauto) = 12001;

//通知队友修改了匹配模式
SC void SCSyncChangeMatchState(int32 type) = 12002;

//通知队友修改了是否自动添加队友
SC void SCSyncChangeMatchAutoAdd(bool isauto) = 12003;

//通知客户端关闭匹配
SC void SCCancelMatch() = 12005;


//通知客户端关闭匹配
SC void SCMatchingResult(bool isauto) = 12006;




///////////////////////////////////////////////队伍///////////////////////////////////////////////////////////
//邀请进队
CS bool CSInviteTeam(int64 id) = 11000;

//转发邀请进队
SC bool SCInviteTeam(int64 id, string name) = 11001;

//回复邀请进队
CS bool CSInviteTeamReply(int64 id,bool ok) = 11002;

//离开队伍
CS bool CSLeaveTeam() = 11003;

//SC离开队伍
SC void SCLeaveTeam(int64 id, TeamInfo list) = 11004;

//获取队伍列表
CS TeamInfo CSGetTeamInfo() = 11005;

//队长踢人
CS bool CSRemoveTeamMember(int64 id) = 2318;

//进入/取消 准备状态  0 = notReady  1 = Ready
CS bool CSChangeReadyState(int32 state) = 2319;

SC void SCSyncReadyList(Int64Array ids) = 2308;

//通知客户端状态改变 PlayerGameState
SC void SCSyncPlayerState(int64 id, int32 gamestate) = 2310;

//通知客户端状态改变 PlayerGameState
SC void SCSyncPlayerOnline(int64 id, bool isonline) = 2311;

SC void SCSyncTeamInfo(TeamInfo list) = 10000;

//通知客户端邀请被拒绝
SC void SCSyncTeamApplyBeRefuse(int64 id, string name) = 2312;


///////////////////////////////////////////////商店///////////////////////////////////////////////////////////
//商店信息
CS MsgShopData CSRequestShopData() = 8100;

//购买物品
CS int32 BuyItem(int32 id) = 8110;

//打开物品
CS int32 OpenItem(int32 id) = 8111;

//买钥匙
CS int32 BuyKey(int32 number) = 8112;

// 同步货币
SC void SCSyncMoney(Money money) = 8113;

///////////////////////////////////////////////衣柜///////////////////////////////////////////////////////////
// 获取所有的衣柜数据
CS Dict_int_WardrobeItemData CSGetAllWardrobe() = 9000;
// 穿戴某个物品
CS bool CSDressItem(int32 itemId) = 9001;
// 卸下某个物品
CS bool CSUndressItem(int32 itemId) = 9002;
// 修改角色avatar信息
CS bool CSChangeAvatar(CharacterAvatarData avatarData) == 9003;
// 增加衣柜物品
SC void SCAddWardrobeItem(Dict_int_int_Data data) = 9004;


///////////////////////////////////////////////统计///////////////////////////////////////////////////////////
//请求统计信息
CS ClientStatisticsInfo CSApplyStatisticsInfo() = 8002;





///////////////////////////////////////////////结算///////////////////////////////////////////////////////////
//结算
SC void SCGameOver(MsgGameResult msg) = 8003;



//9100-9200//////////////////////////////////////支付//////////////////////////////////////////////////////////////////

//结算
CS string CSPayRequest(int32 goodId) = 9100;