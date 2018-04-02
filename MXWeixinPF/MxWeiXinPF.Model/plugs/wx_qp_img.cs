using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 抢票对应的图片信息
	/// </summary>
	[Serializable]
	public partial class wx_qp_img
	{
		public wx_qp_img()
		{}
		#region Model
		private int _id;
		private int? _bid;
		private string _iname;
		private int? _itype;
		private string _imgpic;
		private string _weburl;
		private string _remark;
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
		/// 名称
		/// </summary>
		public string iName
		{
			set{ _iname=value;}
			get{return _iname;}
		}
		/// <summary>
		/// 图片类似（1海报，2影院，3广告）
		/// </summary>
		public int? iType
		{
			set{ _itype=value;}
			get{return _itype;}
		}
		/// <summary>
		/// 图片的路径
		/// </summary>
		public string imgPic
		{
			set{ _imgpic=value;}
			get{return _imgpic;}
		}
		/// <summary>
		/// 外部链接的url地址
		/// </summary>
		public string webUrl
		{
			set{ _weburl=value;}
			get{return _weburl;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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

