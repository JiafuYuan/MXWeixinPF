using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_wq_yyOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_wq_yyOrder
	{
		public wx_wq_yyOrder()
		{}
		#region Model
		private int _id;
		private int? _sort_id;
		private string _name;
		private string _telephone;
		private DateTime? _yydate;
		private string _yytime;
		private string _ddstatus;
		private DateTime? _createdate;
		private string _remark;
		private string _kfremark;
		private int? _yid;
		private int? _pid;
		private int? _xid;
		private string _openid;
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
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? yydate
		{
			set{ _yydate=value;}
			get{return _yydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yytime
		{
			set{ _yytime=value;}
			get{return _yytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ddstatus
		{
			set{ _ddstatus=value;}
			get{return _ddstatus;}
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
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kfremark
		{
			set{ _kfremark=value;}
			get{return _kfremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? yid
		{
			set{ _yid=value;}
			get{return _yid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? xid
		{
			set{ _xid=value;}
			get{return _xid;}
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

