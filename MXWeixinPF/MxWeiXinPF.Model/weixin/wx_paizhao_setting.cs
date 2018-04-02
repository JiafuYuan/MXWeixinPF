using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 微拍系统设置
	/// </summary>
	[Serializable]
	public partial class wx_paizhao_setting
	{
		public wx_paizhao_setting()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private bool _isopen;
		private string _enterkeywords;
		private string _prompt;
		private string _outkeywords;
		private string _initapiurl;
		private string _picapiurl;
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
		/// 是否开启了，开始为1，位开启为0
		/// </summary>
		public bool isOpen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 进入打印的关键词
		/// </summary>
		public string enterKeyWords
		{
			set{ _enterkeywords=value;}
			get{return _enterkeywords;}
		}
		/// <summary>
		/// 回复提示
		/// </summary>
		public string prompt
		{
			set{ _prompt=value;}
			get{return _prompt;}
		}
		/// <summary>
		/// 退出打印模式的关键词
		/// </summary>
		public string outKeyWords
		{
			set{ _outkeywords=value;}
			get{return _outkeywords;}
		}
		/// <summary>
		/// 初始化接口
		/// </summary>
		public string initApiUrl
		{
			set{ _initapiurl=value;}
			get{return _initapiurl;}
		}
		/// <summary>
		/// 传图片的接口url
		/// </summary>
		public string picApiUrl
		{
			set{ _picapiurl=value;}
			get{return _picapiurl;}
		}
		#endregion Model

	}
}

