using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_agent_info
	/// </summary>
	public partial class wx_agent_info
	{
		public wx_agent_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_agent_info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_agent_info");
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
		public int Add(MxWeiXinPF.Model.wx_agent_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_agent_info(");
			strSql.Append("managerId,companyName,companyInfo,agentPrice,agentPrice2,sqJine,czTotMoney,remainMony,userNum,wcodeNum,agentType,agentLevel,industry,agentArea,expiryDate,aRemark,createDate)");
			strSql.Append(" values (");
			strSql.Append("@managerId,@companyName,@companyInfo,@agentPrice,@agentPrice2,@sqJine,@czTotMoney,@remainMony,@userNum,@wcodeNum,@agentType,@agentLevel,@industry,@agentArea,@expiryDate,@aRemark,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@managerId", SqlDbType.Int,4),
					new SqlParameter("@companyName", SqlDbType.VarChar,200),
					new SqlParameter("@companyInfo", SqlDbType.VarChar,800),
					new SqlParameter("@agentPrice", SqlDbType.Int,4),
					new SqlParameter("@agentPrice2", SqlDbType.Int,4),
					new SqlParameter("@sqJine", SqlDbType.Int,4),
					new SqlParameter("@czTotMoney", SqlDbType.Int,4),
					new SqlParameter("@remainMony", SqlDbType.Int,4),
					new SqlParameter("@userNum", SqlDbType.Int,4),
					new SqlParameter("@wcodeNum", SqlDbType.Int,4),
					new SqlParameter("@agentType", SqlDbType.Int,4),
					new SqlParameter("@agentLevel", SqlDbType.VarChar,50),
					new SqlParameter("@industry", SqlDbType.VarChar,200),
					new SqlParameter("@agentArea", SqlDbType.VarChar,300),
					new SqlParameter("@expiryDate", SqlDbType.DateTime),
					new SqlParameter("@aRemark", SqlDbType.VarChar,1500),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.managerId;
			parameters[1].Value = model.companyName;
			parameters[2].Value = model.companyInfo;
			parameters[3].Value = model.agentPrice;
			parameters[4].Value = model.agentPrice2;
			parameters[5].Value = model.sqJine;
			parameters[6].Value = model.czTotMoney;
			parameters[7].Value = model.remainMony;
			parameters[8].Value = model.userNum;
			parameters[9].Value = model.wcodeNum;
			parameters[10].Value = model.agentType;
			parameters[11].Value = model.agentLevel;
			parameters[12].Value = model.industry;
			parameters[13].Value = model.agentArea;
			parameters[14].Value = model.expiryDate;
			parameters[15].Value = model.aRemark;
			parameters[16].Value = model.createDate;

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
		public bool Update(MxWeiXinPF.Model.wx_agent_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_agent_info set ");
			strSql.Append("managerId=@managerId,");
			strSql.Append("companyName=@companyName,");
			strSql.Append("companyInfo=@companyInfo,");
			strSql.Append("agentPrice=@agentPrice,");
			strSql.Append("agentPrice2=@agentPrice2,");
			strSql.Append("sqJine=@sqJine,");
			strSql.Append("czTotMoney=@czTotMoney,");
			strSql.Append("remainMony=@remainMony,");
			strSql.Append("userNum=@userNum,");
			strSql.Append("wcodeNum=@wcodeNum,");
			strSql.Append("agentType=@agentType,");
			strSql.Append("agentLevel=@agentLevel,");
			strSql.Append("industry=@industry,");
			strSql.Append("agentArea=@agentArea,");
			strSql.Append("expiryDate=@expiryDate,");
			strSql.Append("aRemark=@aRemark,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@managerId", SqlDbType.Int,4),
					new SqlParameter("@companyName", SqlDbType.VarChar,200),
					new SqlParameter("@companyInfo", SqlDbType.VarChar,800),
					new SqlParameter("@agentPrice", SqlDbType.Int,4),
					new SqlParameter("@agentPrice2", SqlDbType.Int,4),
					new SqlParameter("@sqJine", SqlDbType.Int,4),
					new SqlParameter("@czTotMoney", SqlDbType.Int,4),
					new SqlParameter("@remainMony", SqlDbType.Int,4),
					new SqlParameter("@userNum", SqlDbType.Int,4),
					new SqlParameter("@wcodeNum", SqlDbType.Int,4),
					new SqlParameter("@agentType", SqlDbType.Int,4),
					new SqlParameter("@agentLevel", SqlDbType.VarChar,50),
					new SqlParameter("@industry", SqlDbType.VarChar,200),
					new SqlParameter("@agentArea", SqlDbType.VarChar,300),
					new SqlParameter("@expiryDate", SqlDbType.DateTime),
					new SqlParameter("@aRemark", SqlDbType.VarChar,1500),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.managerId;
			parameters[1].Value = model.companyName;
			parameters[2].Value = model.companyInfo;
			parameters[3].Value = model.agentPrice;
			parameters[4].Value = model.agentPrice2;
			parameters[5].Value = model.sqJine;
			parameters[6].Value = model.czTotMoney;
			parameters[7].Value = model.remainMony;
			parameters[8].Value = model.userNum;
			parameters[9].Value = model.wcodeNum;
			parameters[10].Value = model.agentType;
			parameters[11].Value = model.agentLevel;
			parameters[12].Value = model.industry;
			parameters[13].Value = model.agentArea;
			parameters[14].Value = model.expiryDate;
			parameters[15].Value = model.aRemark;
			parameters[16].Value = model.createDate;
			parameters[17].Value = model.id;

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
			strSql.Append("delete from wx_agent_info ");
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
			strSql.Append("delete from wx_agent_info ");
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
		public MxWeiXinPF.Model.wx_agent_info GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,managerId,companyName,companyInfo,agentPrice,agentPrice2,sqJine,czTotMoney,remainMony,userNum,wcodeNum,agentType,agentLevel,industry,agentArea,expiryDate,aRemark,createDate from wx_agent_info ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_agent_info model=new MxWeiXinPF.Model.wx_agent_info();
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
		public MxWeiXinPF.Model.wx_agent_info DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_agent_info model=new MxWeiXinPF.Model.wx_agent_info();
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
				if(row["companyName"]!=null)
				{
					model.companyName=row["companyName"].ToString();
				}
				if(row["companyInfo"]!=null)
				{
					model.companyInfo=row["companyInfo"].ToString();
				}
				if(row["agentPrice"]!=null && row["agentPrice"].ToString()!="")
				{
					model.agentPrice=int.Parse(row["agentPrice"].ToString());
				}
				if(row["agentPrice2"]!=null && row["agentPrice2"].ToString()!="")
				{
					model.agentPrice2=int.Parse(row["agentPrice2"].ToString());
				}
				if(row["sqJine"]!=null && row["sqJine"].ToString()!="")
				{
					model.sqJine=int.Parse(row["sqJine"].ToString());
				}
				if(row["czTotMoney"]!=null && row["czTotMoney"].ToString()!="")
				{
					model.czTotMoney=int.Parse(row["czTotMoney"].ToString());
				}
				if(row["remainMony"]!=null && row["remainMony"].ToString()!="")
				{
					model.remainMony=int.Parse(row["remainMony"].ToString());
				}
				if(row["userNum"]!=null && row["userNum"].ToString()!="")
				{
					model.userNum=int.Parse(row["userNum"].ToString());
				}
				if(row["wcodeNum"]!=null && row["wcodeNum"].ToString()!="")
				{
					model.wcodeNum=int.Parse(row["wcodeNum"].ToString());
				}
				if(row["agentType"]!=null && row["agentType"].ToString()!="")
				{
					model.agentType=int.Parse(row["agentType"].ToString());
				}
				if(row["agentLevel"]!=null)
				{
					model.agentLevel=row["agentLevel"].ToString();
				}
				if(row["industry"]!=null)
				{
					model.industry=row["industry"].ToString();
				}
				if(row["agentArea"]!=null)
				{
					model.agentArea=row["agentArea"].ToString();
				}
				if(row["expiryDate"]!=null && row["expiryDate"].ToString()!="")
				{
					model.expiryDate=DateTime.Parse(row["expiryDate"].ToString());
				}
				if(row["aRemark"]!=null)
				{
					model.aRemark=row["aRemark"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,managerId,companyName,companyInfo,agentPrice,agentPrice2,sqJine,czTotMoney,remainMony,userNum,wcodeNum,agentType,agentLevel,industry,agentArea,expiryDate,aRemark,createDate ");
			strSql.Append(" FROM wx_agent_info ");
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
			strSql.Append(" id,managerId,companyName,companyInfo,agentPrice,agentPrice2,sqJine,czTotMoney,remainMony,userNum,wcodeNum,agentType,agentLevel,industry,agentArea,expiryDate,aRemark,createDate ");
			strSql.Append(" FROM wx_agent_info ");
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
			strSql.Append("select count(1) FROM wx_agent_info ");
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
			strSql.Append(")AS Row, T.*  from wx_agent_info T ");
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
			parameters[0].Value = "wx_agent_info";
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
            strSql.Append(" select  *   FROM  view_agent_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where id!=1 and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得完成的代理商信息
        /// </summary>
        public DataSet GetAgentListByView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * FROM view_agent_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_agent_info GetAgentModel(int managerId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,managerId,companyName,companyInfo,agentPrice,agentPrice2,sqJine,czTotMoney,remainMony,userNum,wcodeNum,agentType,agentLevel,industry,agentArea,expiryDate,aRemark,createDate from wx_agent_info ");
            strSql.Append(" where managerId=@managerId");
            SqlParameter[] parameters = {
					new SqlParameter("@managerId", SqlDbType.Int,4)
			};
            parameters[0].Value = managerId;

            MxWeiXinPF.Model.wx_agent_info model = new MxWeiXinPF.Model.wx_agent_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		#endregion  ExtensionMethod
	}
}

