using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_wq_chezhu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_wq_chezhu
	{
		public wx_wq_chezhu()
		{}
		#region Model
		private int _id;
		private int? _cpnum;
		private int? _ppid;
		private int? _cxid;
		private string _name;
		private string _teltephone;
		private DateTime? _spdate;
		private DateTime? _gcdate;
		private decimal? _prevbxmoney;
		private DateTime? _prevbxdate;
		private DateTime? _prevnjdate;
		private int? _sort_id;
		private DateTime? _createdate;
		private decimal? _prevbymoney;
		private DateTime? _prevbydate;
		private decimal? _prevbylicheng;
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
		public int? cpNum
		{
			set{ _cpnum=value;}
			get{return _cpnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ppid
		{
			set{ _ppid=value;}
			get{return _ppid;}
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teltephone
		{
			set{ _teltephone=value;}
			get{return _teltephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? spdate
		{
			set{ _spdate=value;}
			get{return _spdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gcdate
		{
			set{ _gcdate=value;}
			get{return _gcdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? prevBxmoney
		{
			set{ _prevbxmoney=value;}
			get{return _prevbxmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? prevBxdate
		{
			set{ _prevbxdate=value;}
			get{return _prevbxdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? prevNjdate
		{
			set{ _prevnjdate=value;}
			get{return _prevnjdate;}
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
		public decimal? prevBymoney
		{
			set{ _prevbymoney=value;}
			get{return _prevbymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? prevBydate
		{
			set{ _prevbydate=value;}
			get{return _prevbydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? prevBylicheng
		{
			set{ _prevbylicheng=value;}
			get{return _prevbylicheng;}
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

