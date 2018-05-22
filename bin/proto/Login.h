//登录
CS MsgLoginResult CSLogin(string name,string pwd) = 1000;

//注册账号
CS string CSRegister(string name,string pwd,string idname,string id) = 1001;

//保存用户信息
CS bool CSSaveUserInfo(int64 id, UserDetailInfo info) = 1003;
