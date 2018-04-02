using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 微信用户基本表
	/// </summary>
	[Serializable]
	public partial class wx_crm_users
	{
		public wx_crm_users()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _openid;
		private string _nickname;
		private string _sex;
		private string _city;
		private string _country;
		private string _province;
		private string _language;
		private string _headimgurl;
		private string _subscribe_time;
		private string _unionid;
		private DateTime? _createdate;
        private int? _groupid;
        private DateTime? _updatedate;
        private int? _ustatus=1;

		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 所在城市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 所在国家
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 所在省份
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 用户的语言，简体中文为zh_CN
		/// </summary>
		public string language
		{
			set{ _language=value;}
			get{return _language;}
		}
		/// <summary>
		/// 用户头像
		/// </summary>
		public string headimgurl
		{
			set{ _headimgurl=value;}
			get{return _headimgurl;}
		}
		/// <summary>
		/// 用户关注时间，为时间戳
		/// </summary>
		public string subscribe_time
		{
			set{ _subscribe_time=value;}
			get{return _subscribe_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unionid
		{
			set{ _unionid=value;}
			get{return _unionid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}

        /// <summary>
        /// 分组id
        /// </summary>
        public int? groupId
        {
            set { _groupid = value; }
            get { return _groupid; }
        }


        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 状态：1为关注状态，2为跑路，3为拉黑
        /// </summary>
        public int? uStatus
        {
            set { _ustatus = value; }
            get { return _ustatus; }
        }



		#endregion Model

	}
}

