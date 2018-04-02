using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_fc_zjComment
	/// </summary>
	public partial class wx_fc_zjComment
	{
		public wx_fc_zjComment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "wx_fc_zjComment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_fc_zjComment");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MxWeiXinPF.Model.wx_fc_zjComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_fc_zjComment(");
			strSql.Append("wid,title,zjname,zjPosition,zjPhoto,dpContent,zjJieshao,sort_id,createdate,fid)");
			strSql.Append(" values (");
			strSql.Append("@wid,@title,@zjname,@zjPosition,@zjPhoto,@dpContent,@zjJieshao,@sort_id,@createdate,@fid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,4000),
					new SqlParameter("@zjname", SqlDbType.VarChar,300),
					new SqlParameter("@zjPosition", SqlDbType.VarChar,300),
					new SqlParameter("@zjPhoto", SqlDbType.VarChar,500),
					new SqlParameter("@dpContent", SqlDbType.VarChar,800),
					new SqlParameter("@zjJieshao", SqlDbType.VarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@fid", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.zjname;
			parameters[3].Value = model.zjPosition;
			parameters[4].Value = model.zjPhoto;
			parameters[5].Value = model.dpContent;
			parameters[6].Value = model.zjJieshao;
			parameters[7].Value = model.sort_id;
			parameters[8].Value = model.createdate;
			parameters[9].Value = model.fid;

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
		public bool Update(MxWeiXinPF.Model.wx_fc_zjComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_fc_zjComment set ");
			strSql.Append("wid=@wid,");
			strSql.Append("title=@title,");
			strSql.Append("zjname=@zjname,");
			strSql.Append("zjPosition=@zjPosition,");
			strSql.Append("zjPhoto=@zjPhoto,");
			strSql.Append("dpContent=@dpContent,");
			strSql.Append("zjJieshao=@zjJieshao,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("createdate=@createdate,");
			strSql.Append("fid=@fid");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,4000),
					new SqlParameter("@zjname", SqlDbType.VarChar,300),
					new SqlParameter("@zjPosition", SqlDbType.VarChar,300),
					new SqlParameter("@zjPhoto", SqlDbType.VarChar,500),
					new SqlParameter("@dpContent", SqlDbType.VarChar,800),
					new SqlParameter("@zjJieshao", SqlDbType.VarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.zjname;
			parameters[3].Value = model.zjPosition;
			parameters[4].Value = model.zjPhoto;
			parameters[5].Value = model.dpContent;
			parameters[6].Value = model.zjJieshao;
			parameters[7].Value = model.sort_id;
			parameters[8].Value = model.createdate;
			parameters[9].Value = model.fid;
			parameters[10].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_fc_zjComment ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_fc_zjComment ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public MxWeiXinPF.Model.wx_fc_zjComment GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,wid,title,zjname,zjPosition,zjPhoto,dpContent,zjJieshao,sort_id,createdate,fid from wx_fc_zjComment ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MxWeiXinPF.Model.wx_fc_zjComment model=new MxWeiXinPF.Model.wx_fc_zjComment();
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
		public MxWeiXinPF.Model.wx_fc_zjComment DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_fc_zjComment model=new MxWeiXinPF.Model.wx_fc_zjComment();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["zjname"]!=null)
				{
					model.zjname=row["zjname"].ToString();
				}
				if(row["zjPosition"]!=null)
				{
					model.zjPosition=row["zjPosition"].ToString();
				}
				if(row["zjPhoto"]!=null)
				{
					model.zjPhoto=row["zjPhoto"].ToString();
				}
				if(row["dpContent"]!=null)
				{
					model.dpContent=row["dpContent"].ToString();
				}
				if(row["zjJieshao"]!=null)
				{
					model.zjJieshao=row["zjJieshao"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["createdate"]!=null && row["createdate"].ToString()!="")
				{
					model.createdate=DateTime.Parse(row["createdate"].ToString());
				}
				if(row["fid"]!=null && row["fid"].ToString()!="")
				{
					model.fid=int.Parse(row["fid"].ToString());
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
			strSql.Append("select Id,wid,title,zjname,zjPosition,zjPhoto,dpContent,zjJieshao,sort_id,createdate,fid ");
			strSql.Append(" FROM wx_fc_zjComment ");
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
			strSql.Append(" Id,wid,title,zjname,zjPosition,zjPhoto,dpContent,zjJieshao,sort_id,createdate,fid ");
			strSql.Append(" FROM wx_fc_zjComment ");
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
			strSql.Append("select count(1) FROM wx_fc_zjComment ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_fc_zjComment T ");
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
			parameters[0].Value = "wx_fc_zjComment";
			parameters[1].Value = "Id";
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
            strSql.Append("select a.*  from wx_fc_zjComment a ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  ExtensionMethod
	}
}

