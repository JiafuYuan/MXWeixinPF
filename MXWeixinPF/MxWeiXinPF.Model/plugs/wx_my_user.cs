using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_my_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_my_user
	{
		public wx_my_user()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _username;
		private string _userpsd;
		private int? _userscore;
		private int? _useractive;
		private int? _dianid;
		private int? _usergrade;
		private string _useraddr;
		private string _usertel;
		private DateTime? _userborn;
		private string _useremail;
		private string _userqq;
		private int? _forummanager;
		private string _userpic;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userpsd
		{
			set{ _userpsd=value;}
			get{return _userpsd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userscore
		{
			set{ _userscore=value;}
			get{return _userscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? useractive
		{
			set{ _useractive=value;}
			get{return _useractive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dianid
		{
			set{ _dianid=value;}
			get{return _dianid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? usergrade
		{
			set{ _usergrade=value;}
			get{return _usergrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useraddr
		{
			set{ _useraddr=value;}
			get{return _useraddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usertel
		{
			set{ _usertel=value;}
			get{return _usertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? userborn
		{
			set{ _userborn=value;}
			get{return _userborn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string useremail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userqq
		{
			set{ _userqq=value;}
			get{return _userqq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? forummanager
		{
			set{ _forummanager=value;}
			get{return _forummanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userpic
		{
			set{ _userpic=value;}
			get{return _userpic;}
		}
		#endregion Model

	}
}

