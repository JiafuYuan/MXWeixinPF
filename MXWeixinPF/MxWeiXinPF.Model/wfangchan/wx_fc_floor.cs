using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_floor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_floor
	{
		public wx_fc_floor()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _yid;
		private int? _qid;
		private string _newstitle;
		private string _newscover;
		private string _slidea;
		private string _sildeb;
		private string _slidec;
		private string _slided;
		private string _slidee;
		private string _fheadimg;
		private string _htheadimg;
		private string _videourl;
		private decimal? _lngx;
		private decimal? _laty;
		private string _address;
		private string _fsummary;
		private string _psummary;
		private string _jtpt;
		private int? _sort_id;
		private DateTime? _createdate;
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
		/// 预约版面
		/// </summary>
		public int? yid
		{
			set{ _yid=value;}
			get{return _yid;}
		}
		/// <summary>
		/// 全景图id
		/// </summary>
		public int? qid
		{
			set{ _qid=value;}
			get{return _qid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string newsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string newsCover
		{
			set{ _newscover=value;}
			get{return _newscover;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string slideA
		{
			set{ _slidea=value;}
			get{return _slidea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sildeB
		{
			set{ _sildeb=value;}
			get{return _sildeb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string slideC
		{
			set{ _slidec=value;}
			get{return _slidec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string slideD
		{
			set{ _slided=value;}
			get{return _slided;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string slideE
		{
			set{ _slidee=value;}
			get{return _slidee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fheadImg
		{
			set{ _fheadimg=value;}
			get{return _fheadimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string htheadImg
		{
			set{ _htheadimg=value;}
			get{return _htheadimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string videoUrl
		{
			set{ _videourl=value;}
			get{return _videourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lngX
		{
			set{ _lngx=value;}
			get{return _lngx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? latY
		{
			set{ _laty=value;}
			get{return _laty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fSummary
		{
			set{ _fsummary=value;}
			get{return _fsummary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pSummary
		{
			set{ _psummary=value;}
			get{return _psummary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jtpt
		{
			set{ _jtpt=value;}
			get{return _jtpt;}
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
		#endregion Model

	}
}

