using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 热映电影表
	/// </summary>
	[Serializable]
	public partial class wx_qp_film
	{
		public wx_qp_film()
		{}
		#region Model
		private int _id;
		private int? _bid;
		private string _fname;
		private DateTime? _fbegin;
		private DateTime? _fend;
		private string _fstatus;
		private DateTime? _createdate;
		private int? _sort_id;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 基本表id
		/// </summary>
		public int? bId
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 电影名称
		/// </summary>
		public string fName
		{
			set{ _fname=value;}
			get{return _fname;}
		}
		/// <summary>
		/// 放映的开始时间
		/// </summary>
		public DateTime? fBegin
		{
			set{ _fbegin=value;}
			get{return _fbegin;}
		}
		/// <summary>
		/// 放映的结束时间
		/// </summary>
		public DateTime? fEnd
		{
			set{ _fend=value;}
			get{return _fend;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string fStatus
		{
			set{ _fstatus=value;}
			get{return _fstatus;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

