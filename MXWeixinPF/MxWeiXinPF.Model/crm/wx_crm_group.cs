using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 用户分组表
	/// </summary>
	[Serializable]
	public partial class wx_crm_group
	{
		public wx_crm_group()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _name;
		private int? _count;
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
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? count
		{
			set{ _count=value;}
			get{return _count;}
		}
		#endregion Model

	}
}

