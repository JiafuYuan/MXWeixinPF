using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_wq_chexing:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_wq_chexing
	{
		public wx_wq_chexing()
		{}
		#region Model
		private int _id;
		private int? _xid;
		private int? _dwnum;
		private string _name;
		private string _niankuan;
		private int? _sort_id;
		private decimal? _zdprice;
		private decimal? _jxsprice;
		private string _pic;
		private string _qjid;
		private string _pailiang;
		private string _biansuxiang;
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
		public int? xid
		{
			set{ _xid=value;}
			get{return _xid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dwNum
		{
			set{ _dwnum=value;}
			get{return _dwnum;}
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
		public string niankuan
		{
			set{ _niankuan=value;}
			get{return _niankuan;}
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
		public decimal? zdPrice
		{
			set{ _zdprice=value;}
			get{return _zdprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? jxsPrice
		{
			set{ _jxsprice=value;}
			get{return _jxsprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qjid
		{
			set{ _qjid=value;}
			get{return _qjid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pailiang
		{
			set{ _pailiang=value;}
			get{return _pailiang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string biansuxiang
		{
			set{ _biansuxiang=value;}
			get{return _biansuxiang;}
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

