using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 微信Crm同步设置表
	/// </summary>
	[Serializable]
	public partial class wx_crm_setting
	{
		public wx_crm_setting()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _groupcount;
		private int? _openidcount;
		private DateTime? _groupsyndate;
		private DateTime? _personsyndate;
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
		/// 分组数量
		/// </summary>
		public int? groupCount
		{
			set{ _groupcount=value;}
			get{return _groupcount;}
		}
		/// <summary>
		/// 粉丝数量
		/// </summary>
		public int? openidCount
		{
			set{ _openidcount=value;}
			get{return _openidcount;}
		}
		/// <summary>
		/// 同步的时间
		/// </summary>
		public DateTime? groupSynDate
		{
			set{ _groupsyndate=value;}
			get{return _groupsyndate;}
		}
		/// <summary>
		/// 粉丝同步的时间
		/// </summary>
		public DateTime? personSynDate
		{
			set{ _personsyndate=value;}
			get{return _personsyndate;}
		}
		#endregion Model

	}
}

