using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_wq_yuyue:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_wq_yuyue
	{
		public wx_wq_yuyue()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _telephone;
		private string _coverpic;
		private string _address;
		private decimal? _lngx;
		private decimal? _laty;
		private string _headpic;
		private string _remark;
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
		public string coverpic
		{
			set{ _coverpic=value;}
			get{return _coverpic;}
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
		public string headpic
		{
			set{ _headpic=value;}
			get{return _headpic;}
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

