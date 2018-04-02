using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;//Please add references
namespace MxWeiXinPF.DAL
{
	/// <summary>
	/// 数据访问类:wx_fc_aboutWe
	/// </summary>
	public partial class wx_fc_aboutWe
	{
		public wx_fc_aboutWe()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "wx_fc_aboutWe"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_fc_aboutWe");
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
		public int Add(MxWeiXinPF.Model.wx_fc_aboutWe model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_fc_aboutWe(");
			strSql.Append("name,telephone,mobilephone,address,logoAddress,lngX,latY,sort_id,newsDetail,createDate,wid,fid)");
			strSql.Append(" values (");
			strSql.Append("@name,@telephone,@mobilephone,@address,@logoAddress,@lngX,@latY,@sort_id,@newsDetail,@createDate,@wid,@fid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,300),
					new SqlParameter("@telephone", SqlDbType.VarChar,300),
					new SqlParameter("@mobilephone", SqlDbType.VarChar,300),
					new SqlParameter("@address", SqlDbType.VarChar,500),
					new SqlParameter("@logoAddress", SqlDbType.VarChar,500),
					new SqlParameter("@lngX", SqlDbType.Float,8),
					new SqlParameter("@latY", SqlDbType.Float,8),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@newsDetail", SqlDbType.VarChar,1000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@fid", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.telephone;
			parameters[2].Value = model.mobilephone;
			parameters[3].Value = model.address;
			parameters[4].Value = model.logoAddress;
			parameters[5].Value = model.lngX;
			parameters[6].Value = model.latY;
			parameters[7].Value = model.sort_id;
			parameters[8].Value = model.newsDetail;
			parameters[9].Value = model.createDate;
			parameters[10].Value = model.wid;
			parameters[11].Value = model.fid;

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
		public bool Update(MxWeiXinPF.Model.wx_fc_aboutWe model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_fc_aboutWe set ");
			strSql.Append("name=@name,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("mobilephone=@mobilephone,");
			strSql.Append("address=@address,");
			strSql.Append("logoAddress=@logoAddress,");
			strSql.Append("lngX=@lngX,");
			strSql.Append("latY=@latY,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("newsDetail=@newsDetail,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("wid=@wid,");
			strSql.Append("fid=@fid");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,300),
					new SqlParameter("@telephone", SqlDbType.VarChar,300),
					new SqlParameter("@mobilephone", SqlDbType.VarChar,300),
					new SqlParameter("@address", SqlDbType.VarChar,500),
					new SqlParameter("@logoAddress", SqlDbType.VarChar,500),
					new SqlParameter("@lngX", SqlDbType.Float,8),
					new SqlParameter("@latY", SqlDbType.Float,8),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@newsDetail", SqlDbType.VarChar,1000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.telephone;
			parameters[2].Value = model.mobilephone;
			parameters[3].Value = model.address;
			parameters[4].Value = model.logoAddress;
			parameters[5].Value = model.lngX;
			parameters[6].Value = model.latY;
			parameters[7].Value = model.sort_id;
			parameters[8].Value = model.newsDetail;
			parameters[9].Value = model.createDate;
			parameters[10].Value = model.wid;
			parameters[11].Value = model.fid;
			parameters[12].Value = model.Id;

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
			strSql.Append("delete from wx_fc_aboutWe ");
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
			strSql.Append("delete from wx_fc_aboutWe ");
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
		public MxWeiXinPF.Model.wx_fc_aboutWe GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,name,telephone,mobilephone,address,logoAddress,lngX,latY,sort_id,newsDetail,createDate,wid,fid from wx_fc_aboutWe ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MxWeiXinPF.Model.wx_fc_aboutWe model=new MxWeiXinPF.Model.wx_fc_aboutWe();
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
		public MxWeiXinPF.Model.wx_fc_aboutWe DataRowToModel(DataRow row)
		{
			MxWeiXinPF.Model.wx_fc_aboutWe model=new MxWeiXinPF.Model.wx_fc_aboutWe();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["mobilephone"]!=null)
				{
					model.mobilephone=row["mobilephone"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["logoAddress"]!=null)
				{
					model.logoAddress=row["logoAddress"].ToString();
				}
				if(row["lngX"]!=null && row["lngX"].ToString()!="")
				{
					model.lngX=decimal.Parse(row["lngX"].ToString());
				}
				if(row["latY"]!=null && row["latY"].ToString()!="")
				{
					model.latY=decimal.Parse(row["latY"].ToString());
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["newsDetail"]!=null)
				{
					model.newsDetail=row["newsDetail"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["wid"]!=null && row["wid"].ToString()!="")
				{
					model.wid=int.Parse(row["wid"].ToString());
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
			strSql.Append("select Id,name,telephone,mobilephone,address,logoAddress,lngX,latY,sort_id,newsDetail,createDate,wid,fid ");
			strSql.Append(" FROM wx_fc_aboutWe ");
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
			strSql.Append(" Id,name,telephone,mobilephone,address,logoAddress,lngX,latY,sort_id,newsDetail,createDate,wid,fid ");
			strSql.Append(" FROM wx_fc_aboutWe ");
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
			strSql.Append("select count(1) FROM wx_fc_aboutWe ");
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
			strSql.Append(")AS Row, T.*  from wx_fc_aboutWe T ");
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
			parameters[0].Value = "wx_fc_aboutWe";
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

		#endregion  ExtensionMethod
	}
}

