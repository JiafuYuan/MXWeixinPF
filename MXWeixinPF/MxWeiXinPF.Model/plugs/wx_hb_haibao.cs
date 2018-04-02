using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_hb_haibao:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_hb_haibao
	{
		public wx_hb_haibao()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _musicurl;
		private string _htitle;
		private string _hcontent;
		private int? _cid;
		private int? _hviewnum;
		private int? _hforwardnum;
		private string _coverimg;
		private string _copyright;
		private string _address;
		private string _urllink;
		private DateTime? _createdate;
		private int? _sort_id;
		private string _remark;
		/// <summary>
		/// id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微用户
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 背景音乐url
		/// </summary>
		public string musicUrl
		{
			set{ _musicurl=value;}
			get{return _musicurl;}
		}
		/// <summary>
		/// 海报标题
		/// </summary>
		public string hTitle
		{
			set{ _htitle=value;}
			get{return _htitle;}
		}
		/// <summary>
		///海报内容 
		/// </summary>
		public string hContent
		{
			set{ _hcontent=value;}
			get{return _hcontent;}
		}
		/// <summary>
		/// 海报类别
		/// </summary>
		public int? cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 访问量
		/// </summary>
		public int? hViewNum
		{
			set{ _hviewnum=value;}
			get{return _hviewnum;}
		}
		/// <summary>
		/// 转发量
		/// </summary>
		public int? hForwardNum
		{
			set{ _hforwardnum=value;}
			get{return _hforwardnum;}
		}
		/// <summary>
		/// 封面图片
		/// </summary>
		public string coverimg
		{
			set{ _coverimg=value;}
			get{return _coverimg;}
		}
		/// <summary>
		/// 版权
		/// </summary>
		public string copyright
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string urllink
		{
			set{ _urllink=value;}
			get{return _urllink;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createdate
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

