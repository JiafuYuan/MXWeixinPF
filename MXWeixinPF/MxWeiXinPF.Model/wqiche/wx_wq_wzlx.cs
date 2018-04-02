using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_wq_wzlx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_wq_wzlx
	{
		public wx_wq_wzlx()
		{}
		#region Model
		private int _id;
		private int? _cxid;
		private int? _yhid;
		private int? _escid;
		private int? _pxcid;
		private int? _lbsid;
		private int? _sort_id;
		private DateTime? _createdate;
		private int? _wid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cxid
		{
			set{ _cxid=value;}
			get{return _cxid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? yhid
		{
			set{ _yhid=value;}
			get{return _yhid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? escid
		{
			set{ _escid=value;}
			get{return _escid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pxcid
		{
			set{ _pxcid=value;}
			get{return _pxcid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lbsid
		{
			set{ _lbsid=value;}
			get{return _lbsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		#endregion Model

	}
}

