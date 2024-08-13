using DBProject.Controllers.PresentationModels;
using DBProject.Database.MySql;
using DBProject.Models;
using ZstdSharp.Unsafe;

namespace DBProject.Services
{
    public class CustomerService
    {
        private MySqlDataContext _mySql;

        public CustomerService(MySqlDataContext mySql)
        {
            _mySql = mySql;
        }

        public List<Customer> GetCustomers()
        {
            var sqlCustomers = _mySql.GetCustomers();

            return sqlCustomers.Select(s =>
            {
                return new Customer
                {
                    firstName = s.name,
                    mobile = s.telNo
                };
            }).ToList();
        }

        public void addUser(AddCustomerRequest req) {

            _mySql.addUser(req);

        }


        public void addAdmin(AddAdminReq req)
        {

            _mySql.addAdmin(req);

        }

        public void addPostUser(addPost req)
        {

            _mySql.addPostUser(req);

        }

        public void addPostBussines(addPost req)
        {

            _mySql.addPostBussines(req);

        }

        public void addPicture(addPicture req) 
        {
            _mySql.addPicture(req);
        }

        public void getCID(string name)
        {

            _mySql.getCIDByName(name);

        }
        public void addAddress(AddAddressReq req)
        {

            _mySql.addAddress(req);

        }


        public List<Post> getPost()
        {
            var sqlPosts = _mySql.getPost();

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public List<Post> getPostByCity(string city)
        {
            var sqlPosts = _mySql.getPostByCity(city);

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                   body = s.body,
                   BtID = s.BtID,
                   BTName = s.BTName,
                   CID = s.CID,
                   cityName = s.cityName,
                   date = s.date,
                   IsUser = s.IsUser,
                   OwnerID = s.OwnerID,
                   poststatus = s.poststatus,
                   price = s.price,
                   title = s.title,
                   viewNO = s.viewNO
                };
            }).ToList();

        }

        public List<Post> getPostByCategory(int Category)
        {
            var sqlPosts = _mySql.getPostByCategory(Category);

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public List<Post> getPostByCategoryAndCity(int Category, String City)
        {
            var sqlPosts = _mySql.getPostByCategoryAndCity(Category,City);

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public List<Post> getPostPriceDesc()
        {
            var sqlPosts = _mySql.getPostPriceDesc();

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public List<Post> getPostPriceAsc()
        {
            var sqlPosts = _mySql.getPostPriceAsc();

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public void addReport(AddReport req)
        {

            _mySql.addReport(req);

        }

        public List<Report> getReports()
        {
            var sqlReports = _mySql.getReports();

            return sqlReports.Select(s =>
            {
                return new Report
                {
                    PID = s.PID,
                    reportType = s.reportType,
                    UID = s.UID,
                    UserName = s.UserName,
                    description = s.description
                };
            }).ToList();

        }

        public void acceptReport(int RID, int AdminId)
        {

            _mySql.acceptReport(RID,AdminId);

        }

        public void denyReport(int RID, int AdminId)
        {

            _mySql.denyReport(RID, AdminId);

            _mySql.blockPostByRID(RID);
        }

        public void blockPostByPID(int PID) {

            _mySql.blockPostByPID(PID);
        }

        public void confirmPostByPID(int PID)
        {

            _mySql.confirmPostByPID(PID);
        }

        public List<Post> getRecentPosts()
        {
            var sqlPosts = _mySql.getRecentPosts();
            
            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public List<data> getPostData(int PID)
        {
            var postData = _mySql.getPostData(PID);

            return postData.Select(s =>
            {
                return new data
                {
                    key = s.key,
                    value  = s.value
                };
            }).ToList();

        }
        public void addDataToPost(addData req)
        {

            _mySql.addDataToPost(req);
        }
        public void updateProfile(int UID,updateProfile req)
        {
            _mySql.updateProfile(UID,req);
        }

        public List<Post> getPostUser(int UID)
        {
            var sqlPosts = _mySql.getPostUser(UID);

            return sqlPosts.Select(s =>
            {
                return new Post
                {
                    body = s.body,
                    BtID = s.BtID,
                    BTName = s.BTName,
                    CID = s.CID,
                    cityName = s.cityName,
                    date = s.date,
                    IsUser = s.IsUser,
                    OwnerID = s.OwnerID,
                    poststatus = s.poststatus,
                    price = s.price,
                    title = s.title,
                    viewNO = s.viewNO
                };
            }).ToList();

        }

        public void addBussiness(addBussiness req)
        {
            _mySql.addBussiness(req);

        }

        public void deletePost(int PID) 
        {
            _mySql.deletePost(PID);
        }

        public void deActiveUser(int UID)
        {
            _mySql.deActiveUser(UID);
        }
    }
}
