using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MxWeiXinPF.DBUtility;
using MxWeiXinPF.Common;
using System.Collections.Generic;//Please add references
using System.Linq;
namespace MxWeiXinPF.DAL
{
    /// <summary>
    /// 数据访问类:wx_qp_base
    /// </summary>
    public partial class wx_qp_base
    {
        public wx_qp_base()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "wx_qp_base");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wx_qp_base");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_qp_base ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public MxWeiXinPF.Model.wx_qp_base DataRowToModel(DataRow row)
        {
            MxWeiXinPF.Model.wx_qp_base model = new MxWeiXinPF.Model.wx_qp_base();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["wid"] != null && row["wid"].ToString() != "")
                {
                    model.wid = int.Parse(row["wid"].ToString());
                }
                if (row["bName"] != null)
                {
                    model.bName = row["bName"].ToString();
                }
                if (row["actBegin"] != null && row["actBegin"].ToString() != "")
                {
                    model.actBegin = DateTime.Parse(row["actBegin"].ToString());
                }
                if (row["actEnd"] != null && row["actEnd"].ToString() != "")
                {
                    model.actEnd = DateTime.Parse(row["actEnd"].ToString());
                }
                if (row["yyRemark"] != null)
                {
                    model.yyRemark = row["yyRemark"].ToString();
                }
                if (row["qpRemark"] != null)
                {
                    model.qpRemark = row["qpRemark"].ToString();
                }
                if (row["maxPersonNum"] != null && row["maxPersonNum"].ToString() != "")
                {
                    model.maxPersonNum = int.Parse(row["maxPersonNum"].ToString());
                }
                if (row["cyPersonNum"] != null && row["cyPersonNum"].ToString() != "")
                {
                    model.cyPersonNum = int.Parse(row["cyPersonNum"].ToString());
                }
                if (row["isSnSendsms"] != null && row["isSnSendsms"].ToString() != "")
                {
                    if ((row["isSnSendsms"].ToString() == "1") || (row["isSnSendsms"].ToString().ToLower() == "true"))
                    {
                        model.isSnSendsms = true;
                    }
                    else
                    {
                        model.isSnSendsms = false;
                    }
                }
                if (row["yyQPBeginDate"] != null && row["yyQPBeginDate"].ToString() != "")
                {
                    model.yyQPBeginDate = DateTime.Parse(row["yyQPBeginDate"].ToString());
                }
                if (row["yyQPEndDate"] != null && row["yyQPEndDate"].ToString() != "")
                {
                    model.yyQPEndDate = DateTime.Parse(row["yyQPEndDate"].ToString());
                }
                if (row["yyGouPiaoBeginDate"] != null && row["yyGouPiaoBeginDate"].ToString() != "")
                {
                    model.yyGouPiaoBeginDate = DateTime.Parse(row["yyGouPiaoBeginDate"].ToString());
                }
                if (row["yyGouPiaoEndDate"] != null && row["yyGouPiaoEndDate"].ToString() != "")
                {
                    model.yyGouPiaoEndDate = DateTime.Parse(row["yyGouPiaoEndDate"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["beginPic"] != null)
                {
                    model.beginPic = row["beginPic"].ToString();
                }
                if (row["haibaoPic"] != null)
                {
                    model.haibaoPic = row["haibaoPic"].ToString();
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
            strSql.Append("select id,wid,bName,actBegin,actEnd,yyRemark,qpRemark,maxPersonNum,cyPersonNum,isSnSendsms,yyQPBeginDate,yyQPEndDate,yyGouPiaoBeginDate,yyGouPiaoEndDate,remark,createDate,sort_id,beginPic,haibaoPic ");
            strSql.Append(" FROM wx_qp_base ");
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
            strSql.Append(" id,wid,bName,actBegin,actEnd,yyRemark,qpRemark,maxPersonNum,cyPersonNum,isSnSendsms,yyQPBeginDate,yyQPEndDate,yyGouPiaoBeginDate,yyGouPiaoEndDate,remark,createDate,sort_id,beginPic,haibaoPic ");
            strSql.Append(" FROM wx_qp_base ");
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
            strSql.Append("select count(1) FROM wx_qp_base ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wx_qp_base T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_requestRule where modelFunctionName='电影院抢票' and modelFunctionId=@id ; ");
            strSql.Append("delete from wx_qp_base where id=@id ; ");
            strSql.Append("delete from wx_qp_img where bId=@id ; ");
            strSql.Append("delete from wx_qp_film where bId=@id ; ");
            strSql.Append("delete from wx_qp_users where bId=@id");

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        /// 增加一条数据
        /// </summary>
        public int Add(MxWeiXinPF.Model.wx_qp_base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wx_qp_base(");
            strSql.Append("wid,bName,actBegin,actEnd,yyRemark,qpRemark,maxPersonNum,cyPersonNum,isSnSendsms,yyQPBeginDate,yyQPEndDate,yyGouPiaoBeginDate,yyGouPiaoEndDate,remark,createDate,sort_id,beginPic,haibaoPic)");
            strSql.Append(" values (");
            strSql.Append("@wid,@bName,@actBegin,@actEnd,@yyRemark,@qpRemark,@maxPersonNum,@cyPersonNum,@isSnSendsms,@yyQPBeginDate,@yyQPEndDate,@yyGouPiaoBeginDate,@yyGouPiaoEndDate,@remark,@createDate,@sort_id,@beginPic,@haibaoPic)");
            strSql.Append(";set @ReturnValue=  @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@bName", SqlDbType.VarChar,300),
					new SqlParameter("@actBegin", SqlDbType.DateTime),
					new SqlParameter("@actEnd", SqlDbType.DateTime),
					new SqlParameter("@yyRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@qpRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@maxPersonNum", SqlDbType.Int,4),
					new SqlParameter("@cyPersonNum", SqlDbType.Int,4),
					new SqlParameter("@isSnSendsms", SqlDbType.Bit,1),
					new SqlParameter("@yyQPBeginDate", SqlDbType.DateTime),
					new SqlParameter("@yyQPEndDate", SqlDbType.DateTime),
					new SqlParameter("@yyGouPiaoBeginDate", SqlDbType.DateTime),
					new SqlParameter("@yyGouPiaoEndDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@beginPic", SqlDbType.VarChar,800),
					new SqlParameter("@haibaoPic", SqlDbType.VarChar,800),
                    new SqlParameter("@ReturnValue", SqlDbType.Int)};
            parameters[0].Value = model.wid;
            parameters[1].Value = model.bName;
            parameters[2].Value = model.actBegin;
            parameters[3].Value = model.actEnd;
            parameters[4].Value = model.yyRemark;
            parameters[5].Value = model.qpRemark;
            parameters[6].Value = model.maxPersonNum;
            parameters[7].Value = model.cyPersonNum;
            parameters[8].Value = model.isSnSendsms;
            parameters[9].Value = model.yyQPBeginDate;
            parameters[10].Value = model.yyQPEndDate;
            parameters[11].Value = model.yyGouPiaoBeginDate;
            parameters[12].Value = model.yyGouPiaoEndDate;
            parameters[13].Value = model.remark;
            parameters[14].Value = model.createDate;
            parameters[15].Value = model.sort_id;
            parameters[16].Value = model.beginPic;
            parameters[17].Value = model.haibaoPic;
            parameters[18].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //图片相册
            if (model.yingyuanlist != null)
            {
                StringBuilder strSql3;
                foreach (Model.wx_qp_img modelt in model.yingyuanlist)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into  wx_qp_img(");
                    strSql3.Append("bId,iName,iType,imgPic,createDate)");
                    strSql3.Append(" values (");
                    strSql3.Append("@bId,@iName,2,@imgPic,getdate())");
                    SqlParameter[] parameters3 = {
					    new SqlParameter("@bId", SqlDbType.Int,4),
					    new SqlParameter("@iName", SqlDbType.NVarChar,300),
					    new SqlParameter("@imgPic", SqlDbType.NVarChar,800)};
                    parameters3[0].Direction = ParameterDirection.InputOutput;
                    parameters3[1].Value = modelt.iName;
                    parameters3[2].Value = modelt.imgPic;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[18].Value;


        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MxWeiXinPF.Model.wx_qp_base model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update wx_qp_base set ");
                        strSql.Append("wid=@wid,");
                        strSql.Append("bName=@bName,");
                        strSql.Append("actBegin=@actBegin,");
                        strSql.Append("actEnd=@actEnd,");
                        strSql.Append("yyRemark=@yyRemark,");
                        strSql.Append("qpRemark=@qpRemark,");
                        strSql.Append("maxPersonNum=@maxPersonNum,");
                        strSql.Append("cyPersonNum=@cyPersonNum,");
                        strSql.Append("isSnSendsms=@isSnSendsms,");
                        strSql.Append("yyQPBeginDate=@yyQPBeginDate,");
                        strSql.Append("yyQPEndDate=@yyQPEndDate,");
                        strSql.Append("yyGouPiaoBeginDate=@yyGouPiaoBeginDate,");
                        strSql.Append("yyGouPiaoEndDate=@yyGouPiaoEndDate,");
                        strSql.Append("remark=@remark,");
                        strSql.Append("createDate=@createDate,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("beginPic=@beginPic,");
                        strSql.Append("haibaoPic=@haibaoPic");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					new SqlParameter("@wid", SqlDbType.Int,4),
					new SqlParameter("@bName", SqlDbType.VarChar,300),
					new SqlParameter("@actBegin", SqlDbType.DateTime),
					new SqlParameter("@actEnd", SqlDbType.DateTime),
					new SqlParameter("@yyRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@qpRemark", SqlDbType.VarChar,2000),
					new SqlParameter("@maxPersonNum", SqlDbType.Int,4),
					new SqlParameter("@cyPersonNum", SqlDbType.Int,4),
					new SqlParameter("@isSnSendsms", SqlDbType.Bit,1),
					new SqlParameter("@yyQPBeginDate", SqlDbType.DateTime),
					new SqlParameter("@yyQPEndDate", SqlDbType.DateTime),
					new SqlParameter("@yyGouPiaoBeginDate", SqlDbType.DateTime),
					new SqlParameter("@yyGouPiaoEndDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
                    new SqlParameter("@beginPic", SqlDbType.VarChar,800),
                    new SqlParameter("@haibaoPic", SqlDbType.VarChar,800),
					new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.wid;
                        parameters[1].Value = model.bName;
                        parameters[2].Value = model.actBegin;
                        parameters[3].Value = model.actEnd;
                        parameters[4].Value = model.yyRemark;
                        parameters[5].Value = model.qpRemark;
                        parameters[6].Value = model.maxPersonNum;
                        parameters[7].Value = model.cyPersonNum;
                        parameters[8].Value = model.isSnSendsms;
                        parameters[9].Value = model.yyQPBeginDate;
                        parameters[10].Value = model.yyQPEndDate;
                        parameters[11].Value = model.yyGouPiaoBeginDate;
                        parameters[12].Value = model.yyGouPiaoEndDate;
                        parameters[13].Value = model.remark;
                        parameters[14].Value = model.createDate;
                        parameters[15].Value = model.sort_id;
                        parameters[16].Value = model.beginPic;
                        parameters[17].Value = model.haibaoPic;
                        parameters[18].Value = model.id;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //添加/修改相册
                        if (model.yingyuanlist != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.wx_qp_img modelt in model.yingyuanlist)
                            {
                                strSql3 = new StringBuilder();
                                strSql3.Append("insert into wx_qp_img(");
                                strSql3.Append("bId,iName,iType,imgPic,createDate)");
                                strSql3.Append(" values (");
                                strSql3.Append("@bId,@iName,2,@imgPic,getdate())");
                                SqlParameter[] parameters3 = {
					                        new SqlParameter("@bId", SqlDbType.Int,4),
					                        new SqlParameter("@iName", SqlDbType.NVarChar,300),
					                        new SqlParameter("@imgPic", SqlDbType.NVarChar,800)};
                                parameters3[0].Value = model.id;
                                parameters3[1].Value = modelt.iName;
                                parameters3[2].Value = modelt.imgPic;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                            }
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;

        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wx_qp_base set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MxWeiXinPF.Model.wx_qp_base GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,wid,bName,actBegin,actEnd,yyRemark,qpRemark,maxPersonNum,cyPersonNum,isSnSendsms,yyQPBeginDate,yyQPEndDate,yyGouPiaoBeginDate,yyGouPiaoEndDate,remark,createDate,sort_id,beginPic,haibaoPic from wx_qp_base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            MxWeiXinPF.Model.wx_qp_base model = new MxWeiXinPF.Model.wx_qp_base();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                DAL.wx_qp_img imgDal = new wx_qp_img();
                IList<Model.wx_qp_img> imglist = imgDal.GetModelList("bId=" + id+" and  itype=2");
                if (imglist != null)
                {
                    model.yingyuanlist = (from a in imglist where a.iType == 2 select a).ToArray<Model.wx_qp_img>();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select link_url='',*  from wx_qp_base   ");

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

