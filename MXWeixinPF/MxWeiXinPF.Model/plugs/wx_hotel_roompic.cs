using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 房间图片
	/// </summary>
	[Serializable]
	public partial class wx_hotel_roompic
	{
		public wx_hotel_roompic()
		{}
		#region Model
		private int _id;
		private int? _roomid;
		private int? _hotelid;
		private string _title;
		private int? _sortpicid;
		private string _roompic;
		private string _roompictz;
		private DateTime? _createdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 房间号
		/// </summary>
		public int? roomid
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// 商家号
		/// </summary>
		public int? hotelid
		{
			set{ _hotelid=value;}
			get{return _hotelid;}
		}
		/// <summary>
		/// 文字描述
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sortpicid
		{
			set{ _sortpicid=value;}
			get{return _sortpicid;}
		}
		/// <summary>
		/// 房间图片
		/// </summary>
		public string roomPic
		{
			set{ _roompic=value;}
			get{return _roompic;}
		}
		/// <summary>
		/// 图片跳转地址
		/// </summary>
		public string roomPictz
		{
			set{ _roompictz=value;}
			get{return _roompictz;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

