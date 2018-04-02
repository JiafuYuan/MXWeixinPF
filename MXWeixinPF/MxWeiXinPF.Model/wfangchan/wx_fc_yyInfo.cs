using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_yyInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_yyInfo
	{
		public wx_fc_yyInfo()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _hid;
		private int? _yid;
		private int? _fid;
		private string _name;
		private string _telephone;
		private DateTime? _yydate;
		private string _yydatepart;
		private string _orderstatus;
		private string _kfremark;
		private DateTime? _createdate;
		private int? _sort_id;
		private string _openid;
		private string _remark;
		/// <summary>
		/// 1,待回复 2，拒绝3，确认
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
		public int? hid
		{
			set{ _hid=value;}
			get{return _hid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? yid
		{
			set{ _yid=value;}
			get{return _yid;}
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? yydate
		{
			set{ _yydate=value;}
			get{return _yydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yydatepart
		{
			set{ _yydatepart=value;}
			get{return _yydatepart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kfRemark
		{
			set{ _kfremark=value;}
			get{return _kfremark;}
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
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

