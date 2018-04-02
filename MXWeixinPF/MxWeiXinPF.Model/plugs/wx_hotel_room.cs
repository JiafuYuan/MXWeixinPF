using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 房间设置
	/// </summary>
	[Serializable]
	public partial class wx_hotel_room
	{
		public wx_hotel_room()
		{}
		#region Model
		private int _id;
		private int? _hotelid;
		private string _roomtype;
		private string _indroduce;
		private decimal? _roomprice;
		private decimal? _saleprice;
		private string _facilities;
		private DateTime? _createdate;
		private int? _sortid;
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
		/// 房间类型
		/// </summary>
		public string roomType
		{
			set{ _roomtype=value;}
			get{return _roomtype;}
		}
		/// <summary>
		/// 简要说明
		/// </summary>
		public string indroduce
		{
			set{ _indroduce=value;}
			get{return _indroduce;}
		}
		/// <summary>
		/// 原价
		/// </summary>
		public decimal? roomPrice
		{
			set{ _roomprice=value;}
			get{return _roomprice;}
		}
		/// <summary>
		/// 优惠价
		/// </summary>
		public decimal? salePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 配套设施
		/// </summary>
		public string facilities
		{
			set{ _facilities=value;}
			get{return _facilities;}
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
		public int? sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

