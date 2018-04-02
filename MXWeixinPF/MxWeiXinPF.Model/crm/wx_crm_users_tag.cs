using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 用户标签表
	/// </summary>
	[Serializable]
	public partial class wx_crm_users_tag
	{
		public wx_crm_users_tag()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _openid;
		private string _tag;
		private DateTime? _createdate;
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
		/// 标签字符串（逗号隔开）
		/// </summary>
		public string tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

