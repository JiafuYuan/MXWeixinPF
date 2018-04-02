using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_manager_bill
	/// </summary>
	public partial class wx_manager_bill
	{
		public wx_manager_bill()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_manager_bill"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_manager_bill");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MxWeiXinPF.Model.wx_manager_bill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_manager_bill(");
			strSql.Append("managerId,moneyType,billMoney,billUsed,operPersonId,operDate,remark)");
			strSql.Append(" values (");
			strSql.Append("@managerId,@moneyType,@billMoney,@billUsed,@operPersonId,@operDate,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@managerId", SqlDbType.Int,4),
					new SqlParameter("@moneyType", SqlDbType.VarChar,30),
					new SqlParameter("@billMoney", SqlDbType.Int,4),
					new SqlParameter("@billUsed", SqlDbType.VarChar,500),
					new SqlParameter("@operPersonId", SqlDbType.Int,4),
					new SqlParameter("@operDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,1500)};
			parameters[0].Value = model.managerId;
			parameters[1].Value = model.moneyType;
			parameters[2].Value = model.billMoney;
			parameters[3].Value = model.billUsed;
			parameters[4].Value = model.operPersonId;
			parameters[5].Value = model.operDate;
			parameters[6].Value = model.remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MxWeiXinPF.Model.wx_manager_bill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_manager_bill set ");
			strSql.Append("managerId=@managerId,");
			strSql.Append("moneyType=@moneyType,");
			strSql.Append("billMoney=@billMoney,");
			strSql.Append("billUsed=@billUsed,");
			strSql.Append("operPersonId=@operPersonId,");
			strSql.Append("operDate=@operDate,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@managerId", SqlDbType.Int,4),
					new SqlParameter("@moneyType", SqlDbType.VarChar,30),
					new SqlParameter("@billMoney", SqlDbType.Int,4),
					new SqlParameter("@billUsed", SqlDbType.VarChar,500),
					new SqlParameter("@operPersonId", SqlDbType.Int,4),
					new SqlParameter("@operDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.managerId;
			parameters[1].Value = model.moneyType;
			parameters[2].Value = model.billMoney;
			parameters[3].Value = model.billUsed;
			parameters[4].Value = model.operPersonId;
			parameters[5].Value = model.operDate;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_manager_bill ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_manager_bill ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MxWeiXinPF.Model.wx_manager_bill GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,managerId,moneyType,billMoney,billUsed,operPersonId,operDate,remark from wx_manager_bill ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_manager_bill model=new MxWeiXinPF.Model.wx_manager_bill();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MxWeiXinPF.Model.wx_manager_bill DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_manager_bill model=new MxWeiXinPF.Model.wx_manager_bill();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["managerId"]!=null && row["managerId"].ToString()!="")
				{
					model.managerId=int.Parse(row["managerId"].ToString());
				}
				if(row["moneyType"]!=null)
				{
					model.moneyType=row["moneyType"].ToString();
				}
				if(row["billMoney"]!=null && row["billMoney"].ToString()!="")
				{
					model.billMoney=int.Parse(row["billMoney"].ToString());
				}
				if(row["billUsed"]!=null)
				{
					model.billUsed=row["billUsed"].ToString();
				}
				if(row["operPersonId"]!=null && row["operPersonId"].ToString()!="")
				{
					model.operPersonId=int.Parse(row["operPersonId"].ToString());
				}
				if(row["operDate"]!=null && row["operDate"].ToString()!="")
				{
					model.operDate=DateTime.Parse(row["operDate"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,managerId,moneyType,billMoney,billUsed,operPersonId,operDate,remark ");
			strSql.Append(" FROM wx_manager_bill ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,managerId,moneyType,billMoney,billUsed,operPersonId,operDate,remark ");
			strSql.Append(" FROM wx_manager_bill ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wx_manager_bill ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_manager_bill T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "wx_manager_bill";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select top 1 [user_name] from dt_manager  m where m.id=b.managerId ) as agentName,(select top 1 real_name from dt_manager  m where m.id=b.managerId ) as agentreal_name,(select top 1 [user_name] from dt_manager  m where m.id=b.operPersonId ) as operPersonName from wx_manager_bill  b ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  ExtensionMethod
	}
}

