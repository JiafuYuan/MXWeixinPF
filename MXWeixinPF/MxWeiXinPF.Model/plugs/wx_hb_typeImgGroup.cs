using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_hb_typeImgGroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_hb_typeImgGroup
	{
		public wx_hb_typeImgGroup()
		{}
		#region Model
		private int _id;
		private string _tigname;
		private string _imgurl;
		private int? _sort_id;
		private int? _cid;
		private DateTime? _createdate;
		/// <summary>
		/// id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string tigName
		{
			set{ _tigname=value;}
			get{return _tigname;}
		}
		/// <summary>
		/// 图片url
		/// </summary>
		public string imgurl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// 图片组对应类别
		/// </summary>
		public int? cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

