using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_my_tijian:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_my_tijian
	{
		public wx_my_tijian()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _userid;
		private int? _tijianmonth;
		private DateTime? _tijiandate;
		private decimal? _tijiangao;
		private decimal? _tijianzhong;
		private decimal? _tijiantou;
		private decimal? _tijianxiong;
		private decimal? _tijianfu;
		private string _tijiandetails;
		private DateTime? _tijianluru;
		private string _adminname;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tijianmonth
		{
			set{ _tijianmonth=value;}
			get{return _tijianmonth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tijiandate
		{
			set{ _tijiandate=value;}
			get{return _tijiandate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tijiangao
		{
			set{ _tijiangao=value;}
			get{return _tijiangao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tijianzhong
		{
			set{ _tijianzhong=value;}
			get{return _tijianzhong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tijiantou
		{
			set{ _tijiantou=value;}
			get{return _tijiantou;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tijianxiong
		{
			set{ _tijianxiong=value;}
			get{return _tijianxiong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tijianfu
		{
			set{ _tijianfu=value;}
			get{return _tijianfu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tijiandetails
		{
			set{ _tijiandetails=value;}
			get{return _tijiandetails;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tijianluru
		{
			set{ _tijianluru=value;}
			get{return _tijianluru;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adminname
		{
			set{ _adminname=value;}
			get{return _adminname;}
		}
		#endregion Model

	}
}

