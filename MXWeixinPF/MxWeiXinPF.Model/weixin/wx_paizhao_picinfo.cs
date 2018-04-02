using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 用户发送的照片信息
	/// </summary>
	[Serializable]
	public partial class wx_paizhao_picinfo
	{
		public wx_paizhao_picinfo()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _openid;
		private string _mediaid;
		private string _picurl;
		private int? _pstatus;
		private string _remark;
		private DateTime? _createdate;
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
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 图片的id
		/// </summary>
		public string mediaId
		{
			set{ _mediaid=value;}
			get{return _mediaid;}
		}
		/// <summary>
		/// 照片地址
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? pStatus
		{
			set{ _pstatus=value;}
			get{return _pstatus;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

