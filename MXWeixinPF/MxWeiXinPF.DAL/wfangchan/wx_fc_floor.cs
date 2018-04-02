using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;//Please add references
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_fc_floor
    /// </summary>
    public partial class wx_fc_floor
    {
        public wx_fc_floor()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "wx_fc_floor");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_fc_floor");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MxWeiXinPF.Model.wx_fc_floor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_fc_floor(");
            strSql.Append("wid,yid,qid,newsTitle,newsCover,slideA,sildeB,slideC,slideD,slideE,fheadImg,htheadImg,videoUrl,lngX,latY,Address,fSummary,pSummary,jtpt,sort_id,createdate)");
            strSql.Append(" values (");
            strSql.Append("@wid,@yid,@qid,@newsTitle,@newsCover,@slideA,@sildeB,@slideC,@slideD,@slideE,@fheadImg,@htheadImg,@videoUrl,@lngX,@latY,@Address,@fSummary,@pSummary,@jtpt,@sort_id,@createdate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@yid", SqlDbType.Int,4),
					new SqlParameter("@qid", SqlDbType.Int,4),
					new SqlParameter("@newsTitle", SqlDbType.VarChar,500),
					new SqlParameter("@newsCover", SqlDbType.VarChar,300),
					new SqlParameter("@slideA", SqlDbType.VarChar,300),
					new SqlParameter("@sildeB", SqlDbType.VarChar,300),
					new SqlParameter("@slideC", SqlDbType.VarChar,300),
					new SqlParameter("@slideD", SqlDbType.VarChar,300),
					new SqlParameter("@slideE", SqlDbType.VarChar,300),
					new SqlParameter("@fheadImg", SqlDbType.VarChar,300),
					new SqlParameter("@htheadImg", SqlDbType.VarChar,300),
					new SqlParameter("@videoUrl", SqlDbType.VarChar,300),
					new SqlParameter("@lngX", SqlDbType.Float,8),
					new SqlParameter("@latY", SqlDbType.Float,8),
					new SqlParameter("@Address", SqlDbType.VarChar,800),
					new SqlParameter("@fSummary", SqlDbType.VarChar,800),
					new SqlParameter("@pSummary", SqlDbType.VarChar,800),
					new SqlParameter("@jtpt", SqlDbType.VarChar,1000),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.yid;
            parameters[2].Value = model.qid;
            parameters[3].Value = model.newsTitle;
            parameters[4].Value = model.newsCover;
            parameters[5].Value = model.slideA;
            parameters[6].Value = model.sildeB;
            parameters[7].Value = model.slideC;
            parameters[8].Value = model.slideD;
            parameters[9].Value = model.slideE;
            parameters[10].Value = model.fheadImg;
            parameters[11].Value = model.htheadImg;
            parameters[12].Value = model.videoUrl;
            parameters[13].Value = model.lngX;
            parameters[14].Value = model.latY;
            parameters[15].Value = model.Address;
            parameters[16].Value = model.fSummary;
            parameters[17].Value = model.pSummary;
            parameters[18].Value = model.jtpt;
            parameters[19].Value = model.sort_id;
            parameters[20].Value = model.createdate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(MxWeiXinPF.Model.wx_fc_floor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_fc_floor set ");
            strSql.Append("wid=@wid,");
            strSql.Append("yid=@yid,");
            strSql.Append("qid=@qid,");
            strSql.Append("newsTitle=@newsTitle,");
            strSql.Append("newsCover=@newsCover,");
            strSql.Append("slideA=@slideA,");
            strSql.Append("sildeB=@sildeB,");
            strSql.Append("slideC=@slideC,");
            strSql.Append("slideD=@slideD,");
            strSql.Append("slideE=@slideE,");
            strSql.Append("fheadImg=@fheadImg,");
            strSql.Append("htheadImg=@htheadImg,");
            strSql.Append("videoUrl=@videoUrl,");
            strSql.Append("lngX=@lngX,");
            strSql.Append("latY=@latY,");
            strSql.Append("Address=@Address,");
            strSql.Append("fSummary=@fSummary,");
            strSql.Append("pSummary=@pSummary,");
            strSql.Append("jtpt=@jtpt,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("createdate=@createdate");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@yid", SqlDbType.Int,4),
					new SqlParameter("@qid", SqlDbType.Int,4),
					new SqlParameter("@newsTitle", SqlDbType.VarChar,500),
					new SqlParameter("@newsCover", SqlDbType.VarChar,300),
					new SqlParameter("@slideA", SqlDbType.VarChar,300),
					new SqlParameter("@sildeB", SqlDbType.VarChar,300),
					new SqlParameter("@slideC", SqlDbType.VarChar,300),
					new SqlParameter("@slideD", SqlDbType.VarChar,300),
					new SqlParameter("@slideE", SqlDbType.VarChar,300),
					new SqlParameter("@fheadImg", SqlDbType.VarChar,300),
					new SqlParameter("@htheadImg", SqlDbType.VarChar,300),
					new SqlParameter("@videoUrl", SqlDbType.VarChar,300),
					new SqlParameter("@lngX", SqlDbType.Float,8),
					new SqlParameter("@latY", SqlDbType.Float,8),
					new SqlParameter("@Address", SqlDbType.VarChar,800),
					new SqlParameter("@fSummary", SqlDbType.VarChar,800),
					new SqlParameter("@pSummary", SqlDbType.VarChar,800),
					new SqlParameter("@jtpt", SqlDbType.VarChar,1000),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.yid;
            parameters[2].Value = model.qid;
            parameters[3].Value = model.newsTitle;
            parameters[4].Value = model.newsCover;
            parameters[5].Value = model.slideA;
            parameters[6].Value = model.sildeB;
            parameters[7].Value = model.slideC;
            parameters[8].Value = model.slideD;
            parameters[9].Value = model.slideE;
            parameters[10].Value = model.fheadImg;
            parameters[11].Value = model.htheadImg;
            parameters[12].Value = model.videoUrl;
            parameters[13].Value = model.lngX;
            parameters[14].Value = model.latY;
            parameters[15].Value = model.Address;
            parameters[16].Value = model.fSummary;
            parameters[17].Value = model.pSummary;
            parameters[18].Value = model.jtpt;
            parameters[19].Value = model.sort_id;
            parameters[20].Value = model.createdate;
            parameters[21].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_fc_floor ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_fc_floor ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public MxWeiXinPF.Model.wx_fc_floor GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,wid,yid,qid,newsTitle,newsCover,slideA,sildeB,slideC,slideD,slideE,fheadImg,htheadImg,videoUrl,lngX,latY,Address,fSummary,pSummary,jtpt,sort_id,createdate from wx_fc_floor ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            MxWeiXinPF.Model.wx_fc_floor model = new MxWeiXinPF.Model.wx_fc_floor();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_fc_floor DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_fc_floor model = new MxWeiXinPF.Model.wx_fc_floor();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["yid"] != null && row["yid"].ToString() != "")
                {
                    model.yid = int.Parse(row["yid"].ToString());
                }
                if (row["qid"] != null && row["qid"].ToString() != "")
                {
                    model.qid = int.Parse(row["qid"].ToString());
                }
                if (row["newsTitle"] != null)
                {
                    model.newsTitle = row["newsTitle"].ToString();
                }
                if (row["newsCover"] != null)
                {
                    model.newsCover = row["newsCover"].ToString();
                }
                if (row["slideA"] != null)
                {
                    model.slideA = row["slideA"].ToString();
                }
                if (row["sildeB"] != null)
                {
                    model.sildeB = row["sildeB"].ToString();
                }
                if (row["slideC"] != null)
                {
                    model.slideC = row["slideC"].ToString();
                }
                if (row["slideD"] != null)
                {
                    model.slideD = row["slideD"].ToString();
                }
                if (row["slideE"] != null)
                {
                    model.slideE = row["slideE"].ToString();
                }
                if (row["fheadImg"] != null)
                {
                    model.fheadImg = row["fheadImg"].ToString();
                }
                if (row["htheadImg"] != null)
                {
                    model.htheadImg = row["htheadImg"].ToString();
                }
                if (row["videoUrl"] != null)
                {
                    model.videoUrl = row["videoUrl"].ToString();
                }
                if (row["lngX"] != null && row["lngX"].ToString() != "")
                {
                    model.lngX = decimal.Parse(row["lngX"].ToString());
                }
                if (row["latY"] != null && row["latY"].ToString() != "")
                {
                    model.latY = decimal.Parse(row["latY"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["fSummary"] != null)
                {
                    model.fSummary = row["fSummary"].ToString();
                }
                if (row["pSummary"] != null)
                {
                    model.pSummary = row["pSummary"].ToString();
                }
                if (row["jtpt"] != null)
                {
                    model.jtpt = row["jtpt"].ToString();
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["createdate"] != null && row["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(row["createdate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,wid,yid,qid,newsTitle,newsCover,slideA,sildeB,slideC,slideD,slideE,fheadImg,htheadImg,videoUrl,lngX,latY,Address,fSummary,pSummary,jtpt,sort_id,createdate ");
            strSql.Append(" FROM wx_fc_floor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,wid,yid,qid,newsTitle,newsCover,slideA,sildeB,slideC,slideD,slideE,fheadImg,htheadImg,videoUrl,lngX,latY,Address,fSummary,pSummary,jtpt,sort_id,createdate ");
            strSql.Append(" FROM wx_fc_floor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wx_fc_floor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_fc_floor T ");
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
            parameters[0].Value = "wx_fc_floor";
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
            strSql.Append("select a.*,(select reqkeywords from wx_requestRule where modelfunctionName='微房产' and modelFunctionId=a.id) as kw from wx_fc_floor a ");
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

