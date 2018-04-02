using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_hb_category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_hb_category
	{
		public wx_hb_category()
		{}
		#region Model
		private int _id;
		private string _music;
		private string _cname;
		private string _ctitle;
		private string _coverimg;
		private int? _sort_id;
		private string _ccontent;
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
		/// 默认背景音乐
		/// </summary>
		public string music
		{
			set{ _music=value;}
			get{return _music;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string cName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 默认标题
		/// </summary>
		public string cTitle
		{
			set{ _ctitle=value;}
			get{return _ctitle;}
		}
		/// <summary>
		/// 默认封面
		/// </summary>
		public string coverImg
		{
			set{ _coverimg=value;}
			get{return _coverimg;}
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
		/// 默认内容
		/// </summary>
		public string cContent
		{
			set{ _ccontent=value;}
			get{return _ccontent;}
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

