using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_yySysset:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_yySysset
	{
		public wx_fc_yySysset()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _address;
		private decimal? _lngx;
		private decimal? _laty;
		private string _telephone;
		private string _headimg;
		private string _detail;
		private int? _sort_id;
		private DateTime? _createdate;
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
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
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
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string headImg
		{
			set{ _headimg=value;}
			get{return _headimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detail
		{
			set{ _detail=value;}
			get{return _detail;}
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
		#endregion Model

	}
}

