using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_qp_users
	/// </summary>
	public partial class wx_qp_users
	{
		public wx_qp_users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_qp_users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_qp_users");
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
		public int Add(MxWeiXinPF.Model.wx_qp_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_qp_users(");
			strSql.Append("bId,uTel,uName,addr,sn,createDate,uStatus,remark,openid,sort_id)");
			strSql.Append(" values (");
			strSql.Append("@bId,@uTel,@uName,@addr,@sn,@createDate,@uStatus,@remark,@openid,@sort_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bId", SqlDbType.Int,4),
					new SqlParameter("@uTel", SqlDbType.VarChar,100),
					new SqlParameter("@uName", SqlDbType.VarChar,200),
					new SqlParameter("@addr", SqlDbType.VarChar,500),
					new SqlParameter("@sn", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@uStatus", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@openid", SqlDbType.VarChar,800),
					new SqlParameter("@sort_id", SqlDbType.Int,4)};
			parameters[0].Value = model.bId;
			parameters[1].Value = model.uTel;
			parameters[2].Value = model.uName;
			parameters[3].Value = model.addr;
			parameters[4].Value = model.sn;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.uStatus;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.openid;
			parameters[9].Value = model.sort_id;

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
		public bool Update(MxWeiXinPF.Model.wx_qp_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_qp_users set ");
			strSql.Append("bId=@bId,");
			strSql.Append("uTel=@uTel,");
			strSql.Append("uName=@uName,");
			strSql.Append("addr=@addr,");
			strSql.Append("sn=@sn,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("uStatus=@uStatus,");
			strSql.Append("remark=@remark,");
			strSql.Append("openid=@openid,");
			strSql.Append("sort_id=@sort_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@bId", SqlDbType.Int,4),
					new SqlParameter("@uTel", SqlDbType.VarChar,100),
					new SqlParameter("@uName", SqlDbType.VarChar,200),
					new SqlParameter("@addr", SqlDbType.VarChar,500),
					new SqlParameter("@sn", SqlDbType.VarChar,100),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@uStatus", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@openid", SqlDbType.VarChar,800),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.bId;
			parameters[1].Value = model.uTel;
			parameters[2].Value = model.uName;
			parameters[3].Value = model.addr;
			parameters[4].Value = model.sn;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.uStatus;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.openid;
			parameters[9].Value = model.sort_id;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from wx_qp_users ");
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
			strSql.Append("delete from wx_qp_users ");
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
		public MxWeiXinPF.Model.wx_qp_users GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,bId,uTel,uName,addr,sn,createDate,uStatus,remark,openid,sort_id from wx_qp_users ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_qp_users model=new MxWeiXinPF.Model.wx_qp_users();
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
		public MxWeiXinPF.Model.wx_qp_users DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_qp_users model=new MxWeiXinPF.Model.wx_qp_users();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["bId"]!=null && row["bId"].ToString()!="")
				{
					model.bId=int.Parse(row["bId"].ToString());
				}
				if(row["uTel"]!=null)
				{
					model.uTel=row["uTel"].ToString();
				}
				if(row["uName"]!=null)
				{
					model.uName=row["uName"].ToString();
				}
				if(row["addr"]!=null)
				{
					model.addr=row["addr"].ToString();
				}
				if(row["sn"]!=null)
				{
					model.sn=row["sn"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["uStatus"]!=null)
				{
					model.uStatus=row["uStatus"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
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
			strSql.Append("select id,bId,uTel,uName,addr,sn,createDate,uStatus,remark,openid,sort_id ");
			strSql.Append(" FROM wx_qp_users ");
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
			strSql.Append(" id,bId,uTel,uName,addr,sn,createDate,uStatus,remark,openid,sort_id ");
			strSql.Append(" FROM wx_qp_users ");
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
			strSql.Append("select count(1) FROM wx_qp_users ");
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
			strSql.Append(")AS Row, T.*  from wx_qp_users T ");
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
			parameters[0].Value = "wx_qp_users";
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
        public DataSet GetList(int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select id, bId, uTel, uName, addr, sn, createDate, uStatus, remark, openid, sort_id from wx_qp_users p");
            strSql.Append(" where " + strWhere);
            if (category_id > 0)
            {
                strSql.Append(" and bId=" + category_id);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  ExtensionMethod
	}
}

