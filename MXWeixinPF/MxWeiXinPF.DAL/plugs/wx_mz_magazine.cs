using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_mz_magazine
	/// </summary>
	public partial class wx_mz_magazine
	{
		public wx_mz_magazine()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_mz_magazine"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_mz_magazine");
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
		public int Add(MxWeiXinPF.Model.wx_mz_magazine model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_mz_magazine(");
			strSql.Append("mname,mremark,isbackmusic,isrepeat,coverimg,footimg,cleanimg,sort_id,createdate,footurl,backmusic)");
			strSql.Append(" values (");
			strSql.Append("@mname,@mremark,@isbackmusic,@isrepeat,@coverimg,@footimg,@cleanimg,@sort_id,@createdate,@footurl,@backmusic)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,500),
					new SqlParameter("@mremark", SqlDbType.NVarChar,800),
					new SqlParameter("@isbackmusic", SqlDbType.NVarChar,50),
					new SqlParameter("@isrepeat", SqlDbType.NVarChar,50),
					new SqlParameter("@coverimg", SqlDbType.NVarChar,500),
					new SqlParameter("@footimg", SqlDbType.NVarChar,500),
					new SqlParameter("@cleanimg", SqlDbType.NVarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@footurl", SqlDbType.NVarChar,300),
					new SqlParameter("@backmusic", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.mname;
			parameters[1].Value = model.mremark;
			parameters[2].Value = model.isbackmusic;
			parameters[3].Value = model.isrepeat;
			parameters[4].Value = model.coverimg;
			parameters[5].Value = model.footimg;
			parameters[6].Value = model.cleanimg;
			parameters[7].Value = model.sort_id;
			parameters[8].Value = model.createdate;
			parameters[9].Value = model.footurl;
			parameters[10].Value = model.backmusic;

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
		public bool Update(MxWeiXinPF.Model.wx_mz_magazine model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_mz_magazine set ");
			strSql.Append("mname=@mname,");
			strSql.Append("mremark=@mremark,");
			strSql.Append("isbackmusic=@isbackmusic,");
			strSql.Append("isrepeat=@isrepeat,");
			strSql.Append("coverimg=@coverimg,");
			strSql.Append("footimg=@footimg,");
			strSql.Append("cleanimg=@cleanimg,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("createdate=@createdate,");
			strSql.Append("footurl=@footurl,");
			strSql.Append("backmusic=@backmusic");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,500),
					new SqlParameter("@mremark", SqlDbType.NVarChar,800),
					new SqlParameter("@isbackmusic", SqlDbType.NVarChar,50),
					new SqlParameter("@isrepeat", SqlDbType.NVarChar,50),
					new SqlParameter("@coverimg", SqlDbType.NVarChar,500),
					new SqlParameter("@footimg", SqlDbType.NVarChar,500),
					new SqlParameter("@cleanimg", SqlDbType.NVarChar,500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@footurl", SqlDbType.NVarChar,300),
					new SqlParameter("@backmusic", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.mname;
			parameters[1].Value = model.mremark;
			parameters[2].Value = model.isbackmusic;
			parameters[3].Value = model.isrepeat;
			parameters[4].Value = model.coverimg;
			parameters[5].Value = model.footimg;
			parameters[6].Value = model.cleanimg;
			parameters[7].Value = model.sort_id;
			parameters[8].Value = model.createdate;
			parameters[9].Value = model.footurl;
			parameters[10].Value = model.backmusic;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from wx_mz_magazine ");
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
			strSql.Append("delete from wx_mz_magazine ");
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
		public MxWeiXinPF.Model.wx_mz_magazine GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,mname,mremark,isbackmusic,isrepeat,coverimg,footimg,cleanimg,sort_id,createdate,footurl,backmusic from wx_mz_magazine ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_mz_magazine model=new MxWeiXinPF.Model.wx_mz_magazine();
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
		public MxWeiXinPF.Model.wx_mz_magazine DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_mz_magazine model=new MxWeiXinPF.Model.wx_mz_magazine();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["mremark"]!=null)
				{
					model.mremark=row["mremark"].ToString();
				}
				if(row["isbackmusic"]!=null)
				{
					model.isbackmusic=row["isbackmusic"].ToString();
				}
				if(row["isrepeat"]!=null)
				{
					model.isrepeat=row["isrepeat"].ToString();
				}
				if(row["coverimg"]!=null)
				{
					model.coverimg=row["coverimg"].ToString();
				}
				if(row["footimg"]!=null)
				{
					model.footimg=row["footimg"].ToString();
				}
				if(row["cleanimg"]!=null)
				{
					model.cleanimg=row["cleanimg"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["createdate"]!=null && row["createdate"].ToString()!="")
				{
					model.createdate=DateTime.Parse(row["createdate"].ToString());
				}
				if(row["footurl"]!=null)
				{
					model.footurl=row["footurl"].ToString();
				}
				if(row["backmusic"]!=null)
				{
					model.backmusic=row["backmusic"].ToString();
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
			strSql.Append("select id,mname,mremark,isbackmusic,isrepeat,coverimg,footimg,cleanimg,sort_id,createdate,footurl,backmusic ");
			strSql.Append(" FROM wx_mz_magazine ");
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
			strSql.Append(" id,mname,mremark,isbackmusic,isrepeat,coverimg,footimg,cleanimg,sort_id,createdate,footurl,backmusic ");
			strSql.Append(" FROM wx_mz_magazine ");
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
			strSql.Append("select count(1) FROM wx_mz_magazine ");
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
			strSql.Append(")AS Row, T.*  from wx_mz_magazine T ");
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
			parameters[0].Value = "wx_mz_magazine";
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
            strSql.Append("select  *  from wx_mz_magazine  ");
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

