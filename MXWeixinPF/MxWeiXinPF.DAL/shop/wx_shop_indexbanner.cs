using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;
using System.Collections.Generic;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_shop_indexbanner
	/// </summary>
	public partial class wx_shop_indexbanner
	{
		public wx_shop_indexbanner()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_shop_indexbanner"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_shop_indexbanner");
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
		public int Add(MxWeiXinPF.Model.wx_shop_indexbanner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_shop_indexbanner(");
			strSql.Append("wid,bannerName,bannerPicUrl,bannerLinkUrl,remark,sort_id,createDate)");
			strSql.Append(" values (");
			strSql.Append("@wid,@bannerName,@bannerPicUrl,@bannerLinkUrl,@remark,@sort_id,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@bannerName", SqlDbType.VarChar,100),
					new SqlParameter("@bannerPicUrl", SqlDbType.VarChar,800),
					new SqlParameter("@bannerLinkUrl", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.bannerName;
			parameters[2].Value = model.bannerPicUrl;
			parameters[3].Value = model.bannerLinkUrl;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.sort_id;
			parameters[6].Value = model.createDate;

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
		public bool Update(MxWeiXinPF.Model.wx_shop_indexbanner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_shop_indexbanner set ");
			strSql.Append("wid=@wid,");
			strSql.Append("bannerName=@bannerName,");
			strSql.Append("bannerPicUrl=@bannerPicUrl,");
			strSql.Append("bannerLinkUrl=@bannerLinkUrl,");
			strSql.Append("remark=@remark,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@bannerName", SqlDbType.VarChar,100),
					new SqlParameter("@bannerPicUrl", SqlDbType.VarChar,800),
					new SqlParameter("@bannerLinkUrl", SqlDbType.VarChar,800),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wid;
			parameters[1].Value = model.bannerName;
			parameters[2].Value = model.bannerPicUrl;
			parameters[3].Value = model.bannerLinkUrl;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.sort_id;
			parameters[6].Value = model.createDate;
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
			strSql.Append("delete from wx_shop_indexbanner ");
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
			strSql.Append("delete from wx_shop_indexbanner ");
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
		public MxWeiXinPF.Model.wx_shop_indexbanner GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wid,bannerName,bannerPicUrl,bannerLinkUrl,remark,sort_id,createDate from wx_shop_indexbanner ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MxWeiXinPF.Model.wx_shop_indexbanner model=new MxWeiXinPF.Model.wx_shop_indexbanner();
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
		public MxWeiXinPF.Model.wx_shop_indexbanner DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_shop_indexbanner model=new MxWeiXinPF.Model.wx_shop_indexbanner();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
				}
				if(row["bannerName"]!=null)
				{
					model.bannerName=row["bannerName"].ToString();
				}
				if(row["bannerPicUrl"]!=null)
				{
					model.bannerPicUrl=row["bannerPicUrl"].ToString();
				}
				if(row["bannerLinkUrl"]!=null)
				{
					model.bannerLinkUrl=row["bannerLinkUrl"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
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
			strSql.Append("select id,wid,bannerName,bannerPicUrl,bannerLinkUrl,remark,sort_id,createDate ");
			strSql.Append(" FROM wx_shop_indexbanner ");
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
			strSql.Append(" id,wid,bannerName,bannerPicUrl,bannerLinkUrl,remark,sort_id,createDate ");
			strSql.Append(" FROM wx_shop_indexbanner ");
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
			strSql.Append("select count(1) FROM wx_shop_indexbanner ");
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
			strSql.Append(")AS Row, T.*  from wx_shop_indexbanner T ");
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
			parameters[0].Value = "wx_shop_indexbanner";
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
            strSql.Append(" select  * from wx_shop_indexbanner ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 取幻灯片信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="topNum">取前几条数据，若为-1，则取全部的数据</param>
        public IList<Model.wx_shop_indexbanner> GetHDPByWid(int wid, int topNum)
        {
            IList<Model.wx_shop_indexbanner> hdpList = new List<Model.wx_shop_indexbanner>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (topNum >= 0)
            {
                strSql.Append(" top " + topNum + " ");
            }
            strSql.Append(" * from wx_shop_indexbanner  ");
            strSql.Append(" where wid=@wid order by sort_id asc,id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4)
			};
            parameters[0].Value = wid;
            SqlDataReader sr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            Model.wx_shop_indexbanner hdp = new Model.wx_shop_indexbanner();
            while (sr.Read())
            {
                hdp = new Model.wx_shop_indexbanner();
                hdp.id = MyCommFun.Obj2Int(sr["id"]);
                hdp.bannerName = MyCommFun.ObjToStr(sr["bannerName"]);
                hdp.bannerPicUrl = MyCommFun.ObjToStr(sr["bannerPicUrl"]);
                hdp.bannerLinkUrl = MyCommFun.ObjToStr(sr["bannerLinkUrl"]);
                hdp.remark = MyCommFun.ObjToStr(sr["remark"]);
                hdp.sort_id = MyCommFun.Obj2Int(sr["sort_id"]);
                hdpList.Add(hdp);
            }
            sr.Close();
            return hdpList;

        }



		#endregion  ExtensionMethod
	}
}

