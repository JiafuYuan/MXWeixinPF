using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 砸金蛋活动表
	/// </summary>
	[Serializable]
	public partial class wx_zjdActionInfo
	{
		public wx_zjdActionInfo()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _actname;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _brief;
		private string _contractinfo;
		private string _actcontent;
		private string _cfcjhf;
		private string _endnotice;
		private string _endcontent;
		private int? _personnum;
		private int? _personmaxtimes;
		private int? _daymaxtimes;
		private string _openxyj;
		private DateTime? _createdate;
		private string _beginpic;
		private string _endpic;
		private int? _astatus;
		private string _djpwd;
		private string _duijianginfo;
		private decimal? _zhongjianglv;
		private string _backmusic;
		private string _snshezhi;
		private string _snrename;
		private string _telrename;
		private bool _jpdisplay;
		private bool _mrxingyun;
		private int? _zhongjiangsz;
		private string _choujiangmode;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键Id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string actName
		{
			set{ _actname=value;}
			get{return _actname;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? beginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? endDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 联系信息
		/// </summary>
		public string contractInfo
		{
			set{ _contractinfo=value;}
			get{return _contractinfo;}
		}
		/// <summary>
		/// 活动说明
		/// </summary>
		public string actContent
		{
			set{ _actcontent=value;}
			get{return _actcontent;}
		}
		/// <summary>
		/// 重复抽奖回复
		/// </summary>
		public string cfcjhf
		{
			set{ _cfcjhf=value;}
			get{return _cfcjhf;}
		}
		/// <summary>
		/// 活动结束公告
		/// </summary>
		public string endNotice
		{
			set{ _endnotice=value;}
			get{return _endnotice;}
		}
		/// <summary>
		/// 活动结束说明
		/// </summary>
		public string endContent
		{
			set{ _endcontent=value;}
			get{return _endcontent;}
		}
		/// <summary>
		/// 预计抽奖人数
		/// </summary>
		public int? personNum
		{
			set{ _personnum=value;}
			get{return _personnum;}
		}
		/// <summary>
		/// 每人最多允许抽奖总次数
		/// </summary>
		public int? personMaxTimes
		{
			set{ _personmaxtimes=value;}
			get{return _personmaxtimes;}
		}
		/// <summary>
		/// 每天最多抽奖次数
		/// </summary>
		public int? dayMaxTimes
		{
			set{ _daymaxtimes=value;}
			get{return _daymaxtimes;}
		}
		/// <summary>
		/// 幸运奖内容（若不填写，则不开启幸运奖）
		/// </summary>
		public string openXyj
		{
			set{ _openxyj=value;}
			get{return _openxyj;}
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
		/// 活动开始的图片
		/// </summary>
		public string beginPic
		{
			set{ _beginpic=value;}
			get{return _beginpic;}
		}
		/// <summary>
		/// 活动结束的图片
		/// </summary>
		public string endPic
		{
			set{ _endpic=value;}
			get{return _endpic;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? aStatus
		{
			set{ _astatus=value;}
			get{return _astatus;}
		}
		/// <summary>
		/// 兑奖密码
		/// </summary>
		public string djPwd
		{
			set{ _djpwd=value;}
			get{return _djpwd;}
		}
		/// <summary>
		/// 兑奖信息
		/// </summary>
		public string duijiangInfo
		{
			set{ _duijianginfo=value;}
			get{return _duijianginfo;}
		}
		/// <summary>
		/// 中奖率设置
		/// </summary>
		public decimal? zhongjianglv
		{
			set{ _zhongjianglv=value;}
			get{return _zhongjianglv;}
		}
		/// <summary>
		/// 背景音乐
		/// </summary>
		public string backMusic
		{
			set{ _backmusic=value;}
			get{return _backmusic;}
		}
		/// <summary>
		/// SN码生成设置
		/// </summary>
		public string snShezhi
		{
			set{ _snshezhi=value;}
			get{return _snshezhi;}
		}
		/// <summary>
		/// sn码重命名
		/// </summary>
		public string snRename
		{
			set{ _snrename=value;}
			get{return _snrename;}
		}
		/// <summary>
		/// 手机重命名
		/// </summary>
		public string telRename
		{
			set{ _telrename=value;}
			get{return _telrename;}
		}
		/// <summary>
		/// 是否显示奖品数量
		/// </summary>
		public bool jpDisplay
		{
			set{ _jpdisplay=value;}
			get{return _jpdisplay;}
		}
		/// <summary>
		/// 没中奖是否默认中幸运奖
		/// </summary>
		public bool mrXingyun
		{
			set{ _mrxingyun=value;}
			get{return _mrxingyun;}
		}
		/// <summary>
		/// 中奖设置
		/// </summary>
		public int? zhongjiangSZ
		{
			set{ _zhongjiangsz=value;}
			get{return _zhongjiangsz;}
		}
		/// <summary>
		/// 抽奖模式
		/// </summary>
		public string choujiangMode
		{
			set{ _choujiangmode=value;}
			get{return _choujiangmode;}
		}
		#endregion Model

	}
}

