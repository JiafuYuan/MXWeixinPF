using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 数据表5
	/// </summary>
	[Serializable]
	public partial class wx_hotel_dingdan
	{
		public wx_hotel_dingdan()
		{}
		#region Model
		private int _id;
		private int? _hotelid;
		private string _openid;
		private string _odername;
		private string _tel;
		private DateTime? _arrivetime;
		private DateTime? _leavetime;
		private string _roomtype;
		private DateTime? _ordertime;
		private int? _ordernum;
		private decimal? _price;
		private int? _orderstatus;
		private int? _isdelete;
		private DateTime? _createdate;
		private int? _roomid;
		private decimal? _yuanjia;
		private string _remark;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 商家编号
		/// </summary>
		public int? hotelid
		{
			set{ _hotelid=value;}
			get{return _hotelid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 预定人
		/// </summary>
		public string oderName
		{
			set{ _odername=value;}
			get{return _odername;}
		}
		/// <summary>
		/// 预定人电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 入住时间
		/// </summary>
		public DateTime? arriveTime
		{
			set{ _arrivetime=value;}
			get{return _arrivetime;}
		}
		/// <summary>
		/// 离开时间
		/// </summary>
		public DateTime? leaveTime
		{
			set{ _leavetime=value;}
			get{return _leavetime;}
		}
		/// <summary>
		/// 房间类型
		/// </summary>
		public string roomType
		{
			set{ _roomtype=value;}
			get{return _roomtype;}
		}
		/// <summary>
		/// 预定时间
		/// </summary>
		public DateTime? orderTime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
		}
		/// <summary>
		/// 预定数量
		/// </summary>
		public int? orderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 订单状态
		/// </summary>
		public int? orderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? isDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
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
		/// 
		/// </summary>
		public int? roomid
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? yuanjia
		{
			set{ _yuanjia=value;}
			get{return _yuanjia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

