using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 行业默认模块
	/// </summary>
	[Serializable]
	public partial class wx_industry_defaultModule
	{
		public wx_industry_defaultModule()
		{}
		#region Model
		private int _id;
		private int? _role_id;
		private string _typename;
		private string _mname;
		private bool _isarticle;
		private string _url;
		private int? _sort_id;
		private DateTime? _createdate;
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
		/// 角色（行业）的主键id
		/// </summary>
		public int? role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string mName
		{
			set{ _mname=value;}
			get{return _mname;}
		}
		/// <summary>
		/// 是否为文章
		/// </summary>
		public bool isArticle
		{
			set{ _isarticle=value;}
			get{return _isarticle;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
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
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

