using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_zjComment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_zjComment
	{
		public wx_fc_zjComment()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _title;
		private string _zjname;
		private string _zjposition;
		private string _zjphoto;
		private string _dpcontent;
		private string _zjjieshao;
		private int? _sort_id;
		private DateTime? _createdate;
		private int? _fid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjname
		{
			set{ _zjname=value;}
			get{return _zjname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjPosition
		{
			set{ _zjposition=value;}
			get{return _zjposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjPhoto
		{
			set{ _zjphoto=value;}
			get{return _zjphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dpContent
		{
			set{ _dpcontent=value;}
			get{return _dpcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjJieshao
		{
			set{ _zjjieshao=value;}
			get{return _zjjieshao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		#endregion Model

	}
}

