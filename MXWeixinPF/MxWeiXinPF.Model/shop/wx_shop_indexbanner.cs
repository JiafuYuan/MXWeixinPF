using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 首页幻灯片表
	/// </summary>
	[Serializable]
	public partial class wx_shop_indexbanner
	{
		public wx_shop_indexbanner()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _bannername;
		private string _bannerpicurl;
		private string _bannerlinkurl;
		private string _remark;
		private int? _sort_id;
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
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string bannerName
		{
			set{ _bannername=value;}
			get{return _bannername;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string bannerPicUrl
		{
			set{ _bannerpicurl=value;}
			get{return _bannerpicurl;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string bannerLinkUrl
		{
			set{ _bannerlinkurl=value;}
			get{return _bannerlinkurl;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
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

