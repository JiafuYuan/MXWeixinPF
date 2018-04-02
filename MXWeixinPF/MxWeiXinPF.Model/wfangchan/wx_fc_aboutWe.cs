using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_aboutWe:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_aboutWe
	{
		public wx_fc_aboutWe()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _telephone;
		private string _mobilephone;
		private string _address;
		private string _logoaddress;
		private decimal? _lngx;
		private decimal? _laty;
		private int? _sort_id;
		private string _newsdetail;
		private DateTime? _createdate;
		private int? _wid;
		private int? _fid;
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
		public string name
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
		public string mobilephone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logoAddress
		{
			set{ _logoaddress=value;}
			get{return _logoaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lngX
		{
			set{ _lngx=value;}
			get{return _lngx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? latY
		{
			set{ _laty=value;}
			get{return _laty;}
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
		public string newsDetail
		{
			set{ _newsdetail=value;}
			get{return _newsdetail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
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
		/// <summary>
		/// 
		/// </summary>
		public int? fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		#endregion Model

	}
}

