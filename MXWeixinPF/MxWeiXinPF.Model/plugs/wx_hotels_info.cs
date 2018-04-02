using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 商家基本表
	/// </summary>
	[Serializable]
	public partial class wx_hotels_info
	{
		public wx_hotels_info()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _hotelname;
		private string _hoteladdress;
		private string _hotelphone;
		private string _mobilphone;
		private string _noticeemail;
		private string _emailpws;
		private string _smtp;
		private string _coverpic;
		private string _toppic;
		private int? _orderlimit;
		private bool _listmode;
		private int? _messagenotice;
		private string _pwd;
		private string _hotelintroduct;
		private string _orderremark;
		private DateTime? _createdate;
		private int? _sortid;
		private decimal? _xplace;
		private decimal? _yplace;
		/// <summary>
		/// 编号
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
		/// 商家名称
		/// </summary>
		public string hotelName
		{
			set{ _hotelname=value;}
			get{return _hotelname;}
		}
		/// <summary>
		/// 商家地址
		/// </summary>
		public string hotelAddress
		{
			set{ _hoteladdress=value;}
			get{return _hoteladdress;}
		}
		/// <summary>
		/// 商家电话
		/// </summary>
		public string hotelPhone
		{
			set{ _hotelphone=value;}
			get{return _hotelphone;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string mobilPhone
		{
			set{ _mobilphone=value;}
			get{return _mobilphone;}
		}
		/// <summary>
		/// 通知邮箱
		/// </summary>
		public string noticeEmail
		{
			set{ _noticeemail=value;}
			get{return _noticeemail;}
		}
		/// <summary>
		/// 邮箱密码
		/// </summary>
		public string emailPws
		{
			set{ _emailpws=value;}
			get{return _emailpws;}
		}
		/// <summary>
		/// smtp服务器
		/// </summary>
		public string smtp
		{
			set{ _smtp=value;}
			get{return _smtp;}
		}
		/// <summary>
		/// 封面图片
		/// </summary>
		public string coverPic
		{
			set{ _coverpic=value;}
			get{return _coverpic;}
		}
		/// <summary>
		/// 订单页头部图片
		/// </summary>
		public string topPic
		{
			set{ _toppic=value;}
			get{return _toppic;}
		}
		/// <summary>
		/// 每人每天提交订单次数
		/// </summary>
		public int? orderLimit
		{
			set{ _orderlimit=value;}
			get{return _orderlimit;}
		}
		/// <summary>
		/// 列表模式
		/// </summary>
		public bool listMode
		{
			set{ _listmode=value;}
			get{return _listmode;}
		}
		/// <summary>
		/// 短信提醒
		/// </summary>
		public int? messageNotice
		{
			set{ _messagenotice=value;}
			get{return _messagenotice;}
		}
		/// <summary>
		/// 订单确认密码
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 商家介绍
		/// </summary>
		public string hotelIntroduct
		{
			set{ _hotelintroduct=value;}
			get{return _hotelintroduct;}
		}
		/// <summary>
		/// 订房说明
		/// </summary>
		public string orderRemark
		{
			set{ _orderremark=value;}
			get{return _orderremark;}
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
		public int? sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? xplace
		{
			set{ _xplace=value;}
			get{return _xplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? yplace
		{
			set{ _yplace=value;}
			get{return _yplace;}
		}
		#endregion Model

	}
}

