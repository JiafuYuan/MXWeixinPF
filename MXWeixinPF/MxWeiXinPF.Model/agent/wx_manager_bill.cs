using System;
namespace MxWeiXinPF.Model
{
	/// <summary>
	/// 管理员（代理商）缴费记录
	/// </summary>
	[Serializable]
	public partial class wx_manager_bill
	{
		public wx_manager_bill()
		{}
		#region Model
		private int _id;
		private int? _managerid;
		private string _moneytype;
		private int? _billmoney;
		private string _billused;
		private int? _operpersonid;
		private DateTime? _operdate;
		private string _remark;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 管理员id
		/// </summary>
		public int? managerId
		{
			set{ _managerid=value;}
			get{return _managerid;}
		}
		/// <summary>
		/// 金额类型（充值，扣减）
		/// </summary>
		public string moneyType
		{
			set{ _moneytype=value;}
			get{return _moneytype;}
		}
		/// <summary>
		/// 缴费金额
		/// </summary>
		public int? billMoney
		{
			set{ _billmoney=value;}
			get{return _billmoney;}
		}
		/// <summary>
		/// 缴费内容
		/// </summary>
		public string billUsed
		{
			set{ _billused=value;}
			get{return _billused;}
		}
		/// <summary>
		/// 代缴费人员Id
		/// </summary>
		public int? operPersonId
		{
			set{ _operpersonid=value;}
			get{return _operpersonid;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? operDate
		{
			set{ _operdate=value;}
			get{return _operdate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

