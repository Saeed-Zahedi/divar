using DBProject.Controllers.PresentationModels;
using DBProject.Database.MySql.Model;
using DBProject.Models;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace DBProject.Database.MySql
{
    public class MySqlDataContext
    {
        private MySqlConnection _connection;

        public MySqlDataContext(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public List<MySqlUser>? GetCustomers()
        {
            List<MySqlUser>? users = new List<MySqlUser>();
           
            string query = "SELECT * , city.name as cityName FROM user JOIN city On user.CID = city.CID";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new MySqlUser
                            {
                                cityId = reader.GetInt32("CID"),
                                cityName = reader.GetString("cityName"),
                               
                                email = reader.GetString("email"),
                                lastname = reader.GetString("lastname"),
                                name = reader.GetString("name"),
                                postNo = reader.GetInt32("postNo"),
                                telNo = reader.GetString("telNo"),
                                UID = reader.GetInt32("UID"),
                                UStatus = reader.GetInt32("UStatus")
                            });
                        }
                    }
                }

            return users;
        
        }

        public void addUser(AddCustomerRequest req) {

            string query = "INSERT INTO final.user (name,lastname,email,telNo,postNo,CID,UStatus,date)" +
                "values (" +"\""+ (req.name) + "\"" + "," + "\""+(req.lastname)+ "\""+ ","+"\""+ req.email+"\""+ "," + "\"" + req.telNo+"\""+
                "," + 0 + "," + 1 + "," + 1 + "," + "CURRENT_DATE())";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void addAdmin(AddAdminReq req) {

            string query = "INSERT INTO final.admin (password,name,lastname,email,telNo)" +
                "values (" + "\"" + (req.password) + "\"" +"," + "\"" + (req.name) + "\"" + "," + "\"" + (req.lastname) + "\"" + "," + "\"" + req.email + "\"" + "," + "\"" + req.telNo + "\"" +")";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public void addPostUser(addPost req)
        {   
            string query = "INSERT INTO final.post (title,body,viewNo,OwnerId,BTID,date,IsUser,poststatus,price,CID,)" +
                "values (" + "\"" + (req.title) + "\"" + "," + "\"" + (req.body) + "\"" +"," + 0 + "," + (req.ownerID) + "," + (req.BTID) +","+"CURRENT_DATE()"+ "," + 
                + 1 + "," + 1 + "," + (req.price) +"," + (req.CID) +")";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }
        public void addPostBussines(addPost req)
        {
            string query = "INSERT INTO final.post (title,body,viewNo,OwnerId,BTID,date,IsUser,poststatus,price,CID,)" +
                "values (" + "\"" + (req.title) + "\"" + "," + "\"" + (req.body) + "\"" + "," + 0 + "," + (req.ownerID) + "," + (req.BTID) + "," + "CURRENT_DATE()" + "," +
                + 1 + "," + 1 + "," + (req.price) + "," + (req.CID) + ")";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public void addPicture(addPicture req) 
        {
            string query = "INSERT INTO final.photo (postId,content) values ("+ req.postId +","+ "\""+ req.link +"\""+")";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public int getCIDByName(string cityName) {

         int CID = -1;
         
        string query = "SELECT CID FROM final.city WHERE name ="+"\""+cityName+"\"";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CID = reader.GetInt32("CID");

                    }
                }
            }

            return CID;
        }

        public string getCityNameById(int CID)
        {

            string name = "";

            string query = "SELECT name FROM final.city WHERE CID =" + "\"" + CID + "\"";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         name = reader.GetString("name");

                    }
                }
            }

            return name;
        }

        public void addAddress(AddAddressReq req)
        {

            string query = "INSERT INTO final.address (CID,FAddress)" +
                "values ("+ req.CID + "," + "\"" + req.FAddress + "\"" +")";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public List<MySqlPost>? getPost()
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            string query = "SELECT *,final.city.name AS CName FROM final.post JOIN final.city ON final.post.CID = final.city.CID";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = reader.GetInt32("CID"),
                            cityName = reader.GetString("CName"),
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }

        public List<MySqlPost>? getPostByCity(string city)
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            int CID = getCIDByName(city);

            string query = "SELECT * FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID  WHERE CID=" +CID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                           title = reader.GetString("title"),
                           body = reader.GetString("body"),
                           OwnerID = reader.GetInt32("OwnerID"),
                           BtID = reader.GetInt32("BTID"),
                           BTName = reader.GetString("name"),
                           CID = reader.GetInt32("CID"),
                           cityName = city,
                           date = reader.GetDateTime("date"),
                           IsUser = reader.GetBoolean("IsUser"),
                           poststatus = reader.GetBoolean("poststatus"),
                           price = reader.GetInt64("price"),
                           viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }

        public List<MySqlPost>? getPostByCategory(int Category)
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            string query = "SELECT *,final.city.name AS CName FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID JOIN final.city ON final.city.CID = final.post.CID WHERE final.post.BTID=" + Category;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = reader.GetInt32("CID"),
                            cityName = reader.GetString("CName"),
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }

        public List<MySqlPost>? getPostByCategoryAndCity(int Category,String City)
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            int CID = getCIDByName("City");
            
            string query = "SELECT *,final.city.name AS CName FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID JOIN final.city ON final.city.CID = final.post.CID WHERE final.post.BTID=" + Category+" AND final.post.CID = "+CID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = CID,
                            cityName = City,
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }

        public List<MySqlPost>? getPostPriceDesc()
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            string query = "SELECT * ,final.city.name as CName FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID JOIN final.city ON final.post.CID = final.city.CID ORDER BY price desc";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = reader.GetInt32("CID"),
                            cityName = reader.GetString("CName"),
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }

        public List<MySqlPost>? getPostPriceAsc()
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            string query = "SELECT * ,final.city.name as CName FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID JOIN final.city ON final.post.CID = final.city.CID ORDER BY price asc";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = reader.GetInt32("CID"),
                            cityName = reader.GetString("CName"),
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }
        public void addReport(AddReport req)
        {
            string query = "INSERT INTO final.report (PID,descripition,RTID,AdminId,UID,Rstatus)" +
                "values (" + req.PID + "," + "\"" + req.description + "\"" + "," + req.RTID  + "," + 0 +"," + req.UID + "," + 0 + ")";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<MySqlReport>? getReports()
        {
            List<MySqlReport> posts = new List<MySqlReport>();

            string query = "SELECT * ,final.reporttype.name AS reportName ,final.user.name AS Uname FROM final.report JOIN final.reporttype ON final.report.RTID = final.reporttype.RTID JOIN final.user ON final.report.UID = final.user.UID";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlReport
                        {
                            PID = reader.GetInt32("PID"),
                            description = reader.GetString("descripition"),
                            reportType = reader.GetString("reportName"),
                            UID = reader.GetInt32("UID"),
                            UserName = reader.GetString("Uname")
                        }); ;
                    }
                }
            }
            return posts;
        }

        public void acceptReport(int RID, int AdminId)
        {
            string query = "UPDATE final.report SET RStatus = 1 ,AdminId = "+ AdminId +"WHERE final.report.RID = "+RID;
                
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void denyReport(int RID, int AdminId)
        {
            string query = "UPDATE final.report SET RStatus = 0 , AdminId = "+ AdminId +"WHERE final.report.RID = " + RID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public int getPIDByRID(int RID) {

            string query = "SELECT PID FROM final.report WHERE RID = " + RID;

            int PID = -1;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PID = reader.GetInt32("PID");
                    }
                }
            }
            return PID;
        }

        public void blockPostByRID(int RID) {

            int PID = getPIDByRID(RID);

            string query = "UPDATE final.post SET poststatus = 0 WHERE final.post.PID = "+PID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public void blockPostByPID(int PID)
        {
            string query = "UPDATE final.post SET poststatus = 0 WHERE final.post.PID = " + PID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public void confirmPostByPID(int PID)
        {
            string query = "UPDATE final.post SET poststatus = 1 WHERE final.post.PID = " + PID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public List<MySqlPost>? getRecentPosts()
        {
            List<MySqlPost> posts = new List<MySqlPost>();

            string query = "SELECT * ,final.city.name as CName FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID JOIN final.city ON final.post.CID = final.city.CID ORDER By date desc";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = reader.GetInt32("CID"),
                            cityName = reader.GetString("CName"),
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;

        }

        public List<MySqlData> getPostData(int PID)
        {
            List<MySqlData> datas = new List<MySqlData>();

            string query = "SELECT * FROM final.meta WHERE PID =" + PID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        datas.Add(new MySqlData
                        {
                            key = reader.GetString("field"),
                            value = reader.GetString("value")
                        });  
                    }
                }
            }

            addViewNo(PID);
            return datas;
        }

        public int getViewNo(int PID) {

            string query = "SELECT viewNO FROM final.post WHERE PID = " + PID;

            int viewNO = -1;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        viewNO = reader.GetInt32("viewNO");
                    }
                }
            }
            return viewNO;

        }

        public void addViewNo(int PID)
        {
            int viewNo = getViewNo(PID);

            viewNo++;

            string query = "UPDATE final.post SET final.post.viewNo = " + viewNo + " WHERE PID ="+PID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public void addDataToPost(addData req) 
        {
            string query = "INSERT INTO final.meta (PID,field,value) values (" + req.PID + "," + "\"" + req.key + "\"" + "," +"\""+ req.value + "\"" + ")";
            
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void updateProfile(int UID,updateProfile req) 
        {
            string query = "UPDATE final.user SET name = " + "\"" + req.name + "\"" + " , CID ="+
                              req.CID +" , telNo = "+ "\"" + req.telNO + "\""+" WHERE UID = "+UID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public List<MySqlPost> getPostUser(int UID) 
        {

            List<MySqlPost> posts = new List<MySqlPost>();

            string query = "SELECT * ,final.city.name as CName FROM final.post JOIN final.bussinesstype ON final.post.BTID = final.bussinesstype.BTID JOIN final.city ON final.post.CID = final.city.CID WHERE IsUser = 1 AND ownerId = "+UID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new MySqlPost
                        {
                            title = reader.GetString("title"),
                            body = reader.GetString("body"),
                            OwnerID = reader.GetInt32("OwnerID"),
                            BtID = reader.GetInt32("BTID"),
                            BTName = reader.GetString("name"),
                            CID = reader.GetInt32("CID"),
                            cityName = reader.GetString("CName"),
                            date = reader.GetDateTime("date"),
                            IsUser = reader.GetBoolean("IsUser"),
                            poststatus = reader.GetBoolean("poststatus"),
                            price = reader.GetInt64("price"),
                            viewNO = reader.GetInt32("viewNo")
                        });
                    }
                }
            }
            return posts;
        }

        public void addBussiness(addBussiness req) 
        {
            string query = "INSERT INTO final.bussiness (addressId,name,bussinessNo,BTID,UID) values (" + req.addressId + "," + "\"" + req.name + "\"" + "," +
            req.bussinessNO + "," + req.bussinessTypeId + "," + req.UID + ")";

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }

        public void deletePost(int PID) 
        {
            string query = "DELETE FROM final.post WHERE PID = " + PID;
            
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void deActiveUser(int UID)
        {
            string query = "UPDATE final.user SET UStatus = 0 WHERE UID = "+UID;

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}
