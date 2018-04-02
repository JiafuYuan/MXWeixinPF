using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_hb_imggroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_hb_imggroup
	{
		public wx_hb_imggroup()
		{}
		#region Model
		private int _id;
		private int? _hid;
		private string _imgurl;
		private int? _sort_id;
		private string _igname;
		private DateTime? _cratedate;
		/// <summary>
		/// id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 图片组对应海报
		/// </summary>
		public int? hid
		{
			set{ _hid=value;}
			get{return _hid;}
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
		///排序号 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string igName
		{
			set{ _igname=value;}
			get{return _igname;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? cratedate
		{
			set{ _cratedate=value;}
			get{return _cratedate;}
		}
		#endregion Model

	}
}

