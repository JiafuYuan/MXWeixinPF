using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_panorama:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_panorama
	{
		public wx_fc_panorama()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _fid;
		private string _pri_front;
		private string _pic_right;
		private string _pic_behind;
		private string _pic_left;
		private string _pic_top;
		private string _pic_bottom;
		private string _pic_yulan;
		private string _remark;
		private int? _seq;
		private DateTime? _createdate;
		private string _jdname;
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
		public int? fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pri_front
		{
			set{ _pri_front=value;}
			get{return _pri_front;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_right
		{
			set{ _pic_right=value;}
			get{return _pic_right;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_behind
		{
			set{ _pic_behind=value;}
			get{return _pic_behind;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_left
		{
			set{ _pic_left=value;}
			get{return _pic_left;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_top
		{
			set{ _pic_top=value;}
			get{return _pic_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_bottom
		{
			set{ _pic_bottom=value;}
			get{return _pic_bottom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pic_yulan
		{
			set{ _pic_yulan=value;}
			get{return _pic_yulan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdname
		{
			set{ _jdname=value;}
			get{return _jdname;}
		}
		#endregion Model

	}
}

