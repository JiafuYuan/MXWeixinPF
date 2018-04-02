using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_mz_magazine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_mz_magazine
	{
		public wx_mz_magazine()
		{}
		#region Model
		private int _id;
		private string _mname;
		private string _mremark;
		private string _isbackmusic;
		private string _isrepeat;
		private string _coverimg;
		private string _footimg;
		private string _cleanimg;
		private int? _sort_id;
		private DateTime? _createdate;
		private string _footurl;
		private string _backmusic;
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
		public string mname
		{
			set{ _mname=value;}
			get{return _mname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mremark
		{
			set{ _mremark=value;}
			get{return _mremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isbackmusic
		{
			set{ _isbackmusic=value;}
			get{return _isbackmusic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isrepeat
		{
			set{ _isrepeat=value;}
			get{return _isrepeat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coverimg
		{
			set{ _coverimg=value;}
			get{return _coverimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string footimg
		{
			set{ _footimg=value;}
			get{return _footimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cleanimg
		{
			set{ _cleanimg=value;}
			get{return _cleanimg;}
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
		public string footurl
		{
			set{ _footurl=value;}
			get{return _footurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string backmusic
		{
			set{ _backmusic=value;}
			get{return _backmusic;}
		}
		#endregion Model

	}
}

