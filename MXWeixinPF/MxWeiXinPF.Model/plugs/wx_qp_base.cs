using System;
using System.Collections.Generic;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 抢票基本表
	/// </summary>
	[Serializable]
	public partial class wx_qp_base
	{
		public wx_qp_base()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _bname;
		private DateTime? _actbegin;
		private DateTime? _actend;
		private string _yyremark;
		private string _qpremark;
		private int? _maxpersonnum;
		private int? _cypersonnum;
		private bool _issnsendsms;
		private DateTime? _yyqpbegindate;
		private DateTime? _yyqpenddate;
		private DateTime? _yygoupiaobegindate;
		private DateTime? _yygoupiaoenddate;
		private string _remark;
		private DateTime? _createdate;
		private int? _sort_id;
        private string _beginpic;
        private string _haibaopic;
        
        private IList<Model.wx_qp_img> _yingyuanlist;
      
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微账号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string bName
		{
			set{ _bname=value;}
			get{return _bname;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? actBegin
		{
			set{ _actbegin=value;}
			get{return _actbegin;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? actEnd
		{
			set{ _actend=value;}
			get{return _actend;}
		}
		/// <summary>
		/// 影院简介
		/// </summary>
		public string yyRemark
		{
			set{ _yyremark=value;}
			get{return _yyremark;}
		}
		/// <summary>
		/// 抢票须知
		/// </summary>
		public string qpRemark
		{
			set{ _qpremark=value;}
			get{return _qpremark;}
		}
		/// <summary>
		/// 最大参与人数
		/// </summary>
		public int? maxPersonNum
		{
			set{ _maxpersonnum=value;}
			get{return _maxpersonnum;}
		}
		/// <summary>
		/// 已经参与的人数
		/// </summary>
		public int? cyPersonNum
		{
			set{ _cypersonnum=value;}
			get{return _cypersonnum;}
		}
		/// <summary>
		/// sn码是否发手机短信
		/// </summary>
		public bool isSnSendsms
		{
			set{ _issnsendsms=value;}
			get{return _issnsendsms;}
		}
		/// <summary>
		/// 影院抢票开始时间
		/// </summary>
		public DateTime? yyQPBeginDate
		{
			set{ _yyqpbegindate=value;}
			get{return _yyqpbegindate;}
		}
		/// <summary>
		/// 影院抢票结束时间
		/// </summary>
		public DateTime? yyQPEndDate
		{
			set{ _yyqpenddate=value;}
			get{return _yyqpenddate;}
		}
		/// <summary>
		/// 购票开始时间
		/// </summary>
		public DateTime? yyGouPiaoBeginDate
		{
			set{ _yygoupiaobegindate=value;}
			get{return _yygoupiaobegindate;}
		}
		/// <summary>
		/// 购票结束时间
		/// </summary>
		public DateTime? yyGouPiaoEndDate
		{
			set{ _yygoupiaoenddate=value;}
			get{return _yygoupiaoenddate;}
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
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}

        /// <summary>
        /// 关键词回复的开始图片
        /// </summary>
        public string beginPic
        {
            set { _beginpic = value; }
            get { return _beginpic; }
        }
        /// <summary>
        /// 海报图片url
        /// </summary>
        public string haibaoPic
        {
            set { _haibaopic = value; }
            get { return _haibaopic; }
        }

		#endregion Model

       
        /// <summary>
        /// 影院图片列表
        /// </summary>
        public IList<Model.wx_qp_img> yingyuanlist
        {
            get { return _yingyuanlist; }
            set { _yingyuanlist = value; }
        }

        

	}
}

