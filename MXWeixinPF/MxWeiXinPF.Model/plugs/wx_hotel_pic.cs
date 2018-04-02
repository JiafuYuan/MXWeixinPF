using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 商家图片表
	/// </summary>
	[Serializable]
	public partial class wx_hotel_pic
	{
		public wx_hotel_pic()
		{}
		#region Model
		private int _id;
		private int? _hotelid;
		private string _title;
		private int? _sortid;
		private string _picurl;
		private string _pictiaozhuan;
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
		/// 商家id
		/// </summary>
		public int? hotelid
		{
			set{ _hotelid=value;}
			get{return _hotelid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 图片跳转地址
		/// </summary>
		public string picTiaozhuan
		{
			set{ _pictiaozhuan=value;}
			get{return _pictiaozhuan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

