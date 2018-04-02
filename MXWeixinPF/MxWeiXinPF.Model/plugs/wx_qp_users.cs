using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 抢票的用户表
	/// </summary>
	[Serializable]
	public partial class wx_qp_users
	{
		public wx_qp_users()
		{}
		#region Model
		private int _id;
		private int? _bid;
		private string _utel;
		private string _uname;
		private string _addr;
		private string _sn;
		private DateTime? _createdate;
		private string _ustatus;
		private string _remark;
		private string _openid;
		private int? _sort_id;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 基本表id
		/// </summary>
		public int? bId
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string uTel
		{
			set{ _utel=value;}
			get{return _utel;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string uName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 抢票的sn码
		/// </summary>
		public string sn
		{
			set{ _sn=value;}
			get{return _sn;}
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
		/// 状态
		/// </summary>
		public string uStatus
		{
			set{ _ustatus=value;}
			get{return _ustatus;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 微信用户openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

