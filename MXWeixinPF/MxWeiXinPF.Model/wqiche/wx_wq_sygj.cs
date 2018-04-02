using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_wq_sygj:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_wq_sygj
	{
		public wx_wq_sygj()
		{}
		#region Model
		private int _id;
		private string _url;
		private string _name;
		private int? _sort_id;
		private DateTime? _createdate;
		private int? _gjstatus;
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
		public string url
		{
			set{ _url=value;}
			get{return _url;}
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
		public int? gjstatus
		{
			set{ _gjstatus=value;}
			get{return _gjstatus;}
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

