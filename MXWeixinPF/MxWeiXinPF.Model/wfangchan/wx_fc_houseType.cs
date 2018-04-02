using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// wx_fc_houseType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_fc_houseType
	{
		public wx_fc_houseType()
		{}
		#region Model
		private int _id;
		private int? _sid;
		private int? _sort_id;
		private string _name;
		private string _jieshao;
		private string _housetype;
		private string _storey;
		private string _htimga;
		private string _htimgb;
		private string _htimgc;
		private string _htimgd;
		private DateTime? _createdate;
		private int? _pid;
		private int? _wid;
		private decimal? _jzmj;
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
		public int? sid
		{
			set{ _sid=value;}
			get{return _sid;}
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Jieshao
		{
			set{ _jieshao=value;}
			get{return _jieshao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string houseType
		{
			set{ _housetype=value;}
			get{return _housetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string storey
		{
			set{ _storey=value;}
			get{return _storey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string htimgA
		{
			set{ _htimga=value;}
			get{return _htimga;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string htImgB
		{
			set{ _htimgb=value;}
			get{return _htimgb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string htimgC
		{
			set{ _htimgc=value;}
			get{return _htimgc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string htimgD
		{
			set{ _htimgd=value;}
			get{return _htimgd;}
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
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
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
		/// 建筑面积
		/// </summary>
		public decimal? jzmj
		{
			set{ _jzmj=value;}
			get{return _jzmj;}
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

