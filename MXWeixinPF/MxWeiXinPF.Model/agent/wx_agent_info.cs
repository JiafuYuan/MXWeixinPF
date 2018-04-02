using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 代理商信息设置
	/// </summary>
	[Serializable]
	public partial class wx_agent_info
	{
		public wx_agent_info()
		{}
		#region Model

        //dt_manager
        private int _id;
		private int _managerid=0;
		private string _companyname;
		private string _companyinfo;
		private int? _agentprice;
		private int? _agentprice2;
		private int? _sqjine;
		private int? _cztotmoney;
		private int? _remainmony;
		private int? _usernum;
		private int? _wcodenum;
		private int? _agenttype;
		private string _agentlevel;
		private string _industry;
		private string _agentarea;
		private DateTime? _expirydate;
		private string _aremark;
		private DateTime _createdate=DateTime.Now;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 代理商id
		/// </summary>
		public int managerId
		{
			set{ _managerid=value;}
			get{return _managerid;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 公司信息简介
		/// </summary>
		public string companyInfo
		{
			set{ _companyinfo=value;}
			get{return _companyinfo;}
		}
		/// <summary>
		/// 享受的价格
		/// </summary>
		public int? agentPrice
		{
			set{ _agentprice=value;}
			get{return _agentprice;}
		}
		/// <summary>
		/// 享受的价格2
		/// </summary>
		public int? agentPrice2
		{
			set{ _agentprice2=value;}
			get{return _agentprice2;}
		}
		/// <summary>
		/// 代理商申请的费用
		/// </summary>
		public int? sqJine
		{
			set{ _sqjine=value;}
			get{return _sqjine;}
		}
		/// <summary>
		/// 充值总金额
		/// </summary>
		public int? czTotMoney
		{
			set{ _cztotmoney=value;}
			get{return _cztotmoney;}
		}
		/// <summary>
		/// 剩余金额
		/// </summary>
		public int? remainMony
		{
			set{ _remainmony=value;}
			get{return _remainmony;}
		}
		/// <summary>
		/// 用户数量
		/// </summary>
		public int? userNum
		{
			set{ _usernum=value;}
			get{return _usernum;}
		}
		/// <summary>
		/// 微帐号数量
		/// </summary>
		public int? wcodeNum
		{
			set{ _wcodenum=value;}
			get{return _wcodenum;}
		}
		/// <summary>
		/// 代理类型（区域1，行业代理2）
		/// </summary>
		public int? agentType
		{
			set{ _agenttype=value;}
			get{return _agenttype;}
		}
		/// <summary>
		/// 代理级别
		/// </summary>
		public string agentLevel
		{
			set{ _agentlevel=value;}
			get{return _agentlevel;}
		}
		/// <summary>
		/// 行业
		/// </summary>
		public string industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 代理区域
		/// </summary>
		public string agentArea
		{
			set{ _agentarea=value;}
			get{return _agentarea;}
		}
		/// <summary>
		/// 代理商截至日期
		/// </summary>
		public DateTime? expiryDate
		{
			set{ _expirydate=value;}
			get{return _expirydate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string aRemark
		{
			set{ _aremark=value;}
			get{return _aremark;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime  createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

