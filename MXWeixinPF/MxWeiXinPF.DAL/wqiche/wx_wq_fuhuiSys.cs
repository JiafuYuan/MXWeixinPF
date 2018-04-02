using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_wq_fuhuiSys
	/// </summary>
	public partial class wx_wq_fuhuiSys
	{
		public wx_wq_fuhuiSys()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MxWeiXinPF.Model.wx_wq_fuhuiSys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_wq_fuhuiSys(");
			strSql.Append("Id,wid,newstitle,titlepic,newsurl,jscx,jscxpic,jscxurl,xsgw,xsgwpic,xsgwurl,zxyy,zxyypic,zxyyurl,czgh,czghpic,czghurl,sygj,sygjpic,sygjurl,cxxs,cxxspic,cxxsurl,createdate)");
			strSql.Append(" values (");
			strSql.Append("@Id,@wid,@newstitle,@titlepic,@newsurl,@jscx,@jscxpic,@jscxurl,@xsgw,@xsgwpic,@xsgwurl,@zxyy,@zxyypic,@zxyyurl,@czgh,@czghpic,@czghurl,@sygj,@sygjpic,@sygjurl,@cxxs,@cxxspic,@cxxsurl,@createdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@newstitle", SqlDbType.VarChar,800),
					new SqlParameter("@titlepic", SqlDbType.VarChar,800),
					new SqlParameter("@newsurl", SqlDbType.VarChar,800),
					new SqlParameter("@jscx", SqlDbType.VarChar,300),
					new SqlParameter("@jscxpic", SqlDbType.VarChar,800),
					new SqlParameter("@jscxurl", SqlDbType.VarChar,800),
					new SqlParameter("@xsgw", SqlDbType.VarChar,300),
					new SqlParameter("@xsgwpic", SqlDbType.VarChar,800),
					new SqlParameter("@xsgwurl", SqlDbType.VarChar,800),
					new SqlParameter("@zxyy", SqlDbType.VarChar,300),
					new SqlParameter("@zxyypic", SqlDbType.VarChar,800),
					new SqlParameter("@zxyyurl", SqlDbType.VarChar,800),
					new SqlParameter("@czgh", SqlDbType.VarChar,300),
					new SqlParameter("@czghpic", SqlDbType.VarChar,800),
					new SqlParameter("@czghurl", SqlDbType.VarChar,800),
					new SqlParameter("@sygj", SqlDbType.VarChar,300),
					new SqlParameter("@sygjpic", SqlDbType.VarChar,800),
					new SqlParameter("@sygjurl", SqlDbType.VarChar,800),
					new SqlParameter("@cxxs", SqlDbType.VarChar,300),
					new SqlParameter("@cxxspic", SqlDbType.VarChar,800),
					new SqlParameter("@cxxsurl", SqlDbType.VarChar,800),
					new SqlParameter("@createdate", SqlDbType.DateTime)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.wid;
			parameters[2].Value = model.newstitle;
			parameters[3].Value = model.titlepic;
			parameters[4].Value = model.newsurl;
			parameters[5].Value = model.jscx;
			parameters[6].Value = model.jscxpic;
			parameters[7].Value = model.jscxurl;
			parameters[8].Value = model.xsgw;
			parameters[9].Value = model.xsgwpic;
			parameters[10].Value = model.xsgwurl;
			parameters[11].Value = model.zxyy;
			parameters[12].Value = model.zxyypic;
			parameters[13].Value = model.zxyyurl;
			parameters[14].Value = model.czgh;
			parameters[15].Value = model.czghpic;
			parameters[16].Value = model.czghurl;
			parameters[17].Value = model.sygj;
			parameters[18].Value = model.sygjpic;
			parameters[19].Value = model.sygjurl;
			parameters[20].Value = model.cxxs;
			parameters[21].Value = model.cxxspic;
			parameters[22].Value = model.cxxsurl;
			parameters[23].Value = model.createdate;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(MxWeiXinPF.Model.wx_wq_fuhuiSys model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_wq_fuhuiSys set ");
			strSql.Append("Id=@Id,");
			strSql.Append("wid=@wid,");
			strSql.Append("newstitle=@newstitle,");
			strSql.Append("titlepic=@titlepic,");
			strSql.Append("newsurl=@newsurl,");
			strSql.Append("jscx=@jscx,");
			strSql.Append("jscxpic=@jscxpic,");
			strSql.Append("jscxurl=@jscxurl,");
			strSql.Append("xsgw=@xsgw,");
			strSql.Append("xsgwpic=@xsgwpic,");
			strSql.Append("xsgwurl=@xsgwurl,");
			strSql.Append("zxyy=@zxyy,");
			strSql.Append("zxyypic=@zxyypic,");
			strSql.Append("zxyyurl=@zxyyurl,");
			strSql.Append("czgh=@czgh,");
			strSql.Append("czghpic=@czghpic,");
			strSql.Append("czghurl=@czghurl,");
			strSql.Append("sygj=@sygj,");
			strSql.Append("sygjpic=@sygjpic,");
			strSql.Append("sygjurl=@sygjurl,");
			strSql.Append("cxxs=@cxxs,");
			strSql.Append("cxxspic=@cxxspic,");
			strSql.Append("cxxsurl=@cxxsurl,");
			strSql.Append("createdate=@createdate");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@newstitle", SqlDbType.VarChar,800),
					new SqlParameter("@titlepic", SqlDbType.VarChar,800),
					new SqlParameter("@newsurl", SqlDbType.VarChar,800),
					new SqlParameter("@jscx", SqlDbType.VarChar,300),
					new SqlParameter("@jscxpic", SqlDbType.VarChar,800),
					new SqlParameter("@jscxurl", SqlDbType.VarChar,800),
					new SqlParameter("@xsgw", SqlDbType.VarChar,300),
					new SqlParameter("@xsgwpic", SqlDbType.VarChar,800),
					new SqlParameter("@xsgwurl", SqlDbType.VarChar,800),
					new SqlParameter("@zxyy", SqlDbType.VarChar,300),
					new SqlParameter("@zxyypic", SqlDbType.VarChar,800),
					new SqlParameter("@zxyyurl", SqlDbType.VarChar,800),
					new SqlParameter("@czgh", SqlDbType.VarChar,300),
					new SqlParameter("@czghpic", SqlDbType.VarChar,800),
					new SqlParameter("@czghurl", SqlDbType.VarChar,800),
					new SqlParameter("@sygj", SqlDbType.VarChar,300),
					new SqlParameter("@sygjpic", SqlDbType.VarChar,800),
					new SqlParameter("@sygjurl", SqlDbType.VarChar,800),
					new SqlParameter("@cxxs", SqlDbType.VarChar,300),
					new SqlParameter("@cxxspic", SqlDbType.VarChar,800),
					new SqlParameter("@cxxsurl", SqlDbType.VarChar,800),
					new SqlParameter("@createdate", SqlDbType.DateTime)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.wid;
			parameters[2].Value = model.newstitle;
			parameters[3].Value = model.titlepic;
			parameters[4].Value = model.newsurl;
			parameters[5].Value = model.jscx;
			parameters[6].Value = model.jscxpic;
			parameters[7].Value = model.jscxurl;
			parameters[8].Value = model.xsgw;
			parameters[9].Value = model.xsgwpic;
			parameters[10].Value = model.xsgwurl;
			parameters[11].Value = model.zxyy;
			parameters[12].Value = model.zxyypic;
			parameters[13].Value = model.zxyyurl;
			parameters[14].Value = model.czgh;
			parameters[15].Value = model.czghpic;
			parameters[16].Value = model.czghurl;
			parameters[17].Value = model.sygj;
			parameters[18].Value = model.sygjpic;
			parameters[19].Value = model.sygjurl;
			parameters[20].Value = model.cxxs;
			parameters[21].Value = model.cxxspic;
			parameters[22].Value = model.cxxsurl;
			parameters[23].Value = model.createdate;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_wq_fuhuiSys ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public MxWeiXinPF.Model.wx_wq_fuhuiSys GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,wid,newstitle,titlepic,newsurl,jscx,jscxpic,jscxurl,xsgw,xsgwpic,xsgwurl,zxyy,zxyypic,zxyyurl,czgh,czghpic,czghurl,sygj,sygjpic,sygjurl,cxxs,cxxspic,cxxsurl,createdate from wx_wq_fuhuiSys ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			MxWeiXinPF.Model.wx_wq_fuhuiSys model=new MxWeiXinPF.Model.wx_wq_fuhuiSys();
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
		public MxWeiXinPF.Model.wx_wq_fuhuiSys DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_wq_fuhuiSys model=new MxWeiXinPF.Model.wx_wq_fuhuiSys();
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
				if(row["newstitle"]!=null)
				{
					model.newstitle=row["newstitle"].ToString();
				}
				if(row["titlepic"]!=null)
				{
					model.titlepic=row["titlepic"].ToString();
				}
				if(row["newsurl"]!=null)
				{
					model.newsurl=row["newsurl"].ToString();
				}
				if(row["jscx"]!=null)
				{
					model.jscx=row["jscx"].ToString();
				}
				if(row["jscxpic"]!=null)
				{
					model.jscxpic=row["jscxpic"].ToString();
				}
				if(row["jscxurl"]!=null)
				{
					model.jscxurl=row["jscxurl"].ToString();
				}
				if(row["xsgw"]!=null)
				{
					model.xsgw=row["xsgw"].ToString();
				}
				if(row["xsgwpic"]!=null)
				{
					model.xsgwpic=row["xsgwpic"].ToString();
				}
				if(row["xsgwurl"]!=null)
				{
					model.xsgwurl=row["xsgwurl"].ToString();
				}
				if(row["zxyy"]!=null)
				{
					model.zxyy=row["zxyy"].ToString();
				}
				if(row["zxyypic"]!=null)
				{
					model.zxyypic=row["zxyypic"].ToString();
				}
				if(row["zxyyurl"]!=null)
				{
					model.zxyyurl=row["zxyyurl"].ToString();
				}
				if(row["czgh"]!=null)
				{
					model.czgh=row["czgh"].ToString();
				}
				if(row["czghpic"]!=null)
				{
					model.czghpic=row["czghpic"].ToString();
				}
				if(row["czghurl"]!=null)
				{
					model.czghurl=row["czghurl"].ToString();
				}
				if(row["sygj"]!=null)
				{
					model.sygj=row["sygj"].ToString();
				}
				if(row["sygjpic"]!=null)
				{
					model.sygjpic=row["sygjpic"].ToString();
				}
				if(row["sygjurl"]!=null)
				{
					model.sygjurl=row["sygjurl"].ToString();
				}
				if(row["cxxs"]!=null)
				{
					model.cxxs=row["cxxs"].ToString();
				}
				if(row["cxxspic"]!=null)
				{
					model.cxxspic=row["cxxspic"].ToString();
				}
				if(row["cxxsurl"]!=null)
				{
					model.cxxsurl=row["cxxsurl"].ToString();
				}
				if(row["createdate"]!=null && row["createdate"].ToString()!="")
				{
					model.createdate=DateTime.Parse(row["createdate"].ToString());
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
			strSql.Append("select Id,wid,newstitle,titlepic,newsurl,jscx,jscxpic,jscxurl,xsgw,xsgwpic,xsgwurl,zxyy,zxyypic,zxyyurl,czgh,czghpic,czghurl,sygj,sygjpic,sygjurl,cxxs,cxxspic,cxxsurl,createdate ");
			strSql.Append(" FROM wx_wq_fuhuiSys ");
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
			strSql.Append(" Id,wid,newstitle,titlepic,newsurl,jscx,jscxpic,jscxurl,xsgw,xsgwpic,xsgwurl,zxyy,zxyypic,zxyyurl,czgh,czghpic,czghurl,sygj,sygjpic,sygjurl,cxxs,cxxspic,cxxsurl,createdate ");
			strSql.Append(" FROM wx_wq_fuhuiSys ");
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
			strSql.Append("select count(1) FROM wx_wq_fuhuiSys ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from wx_wq_fuhuiSys T ");
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
			parameters[0].Value = "wx_wq_fuhuiSys";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

