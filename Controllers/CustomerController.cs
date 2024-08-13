using DBProject.Controllers.PresentationModels;
using DBProject.Models;
using DBProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {

        private CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<Customer> GetCustomers()
        {

            return _customerService.GetCustomers();
        }

        [HttpPost]
        public void AddCustomer(AddCustomerRequest req)
        {
            _customerService.addUser(req);

        }

        [HttpPost]
        public void AddAdmin(AddAdminReq req)
        {
            _customerService.addAdmin(req);

        }

        [HttpPost]
        public void AddPostUser(addPost req)
        {
            _customerService.addPostUser(req);

        }

        [HttpPost]
        public void AddPostBussiness(addPost req)
        {
            _customerService.addPostBussines(req);

        }

        [HttpPost]
        public void AddPicture(addPicture req)
        {
            _customerService.addPicture(req);

        }

        [HttpGet]
        public void getCID(string name)
        {
            _customerService.getCID(name);

        }


        [HttpPost]
        public void AddAddress(AddAddressReq req)
        {
            _customerService.addAddress(req);

        }

        [HttpGet]
        public List<Post> getPostByCity(string city) {

            return _customerService.getPostByCity(city);

        }

        [HttpGet]
        public List<Post> getPostByCategory(int Category)
        {

            return _customerService.getPostByCategory(Category);

        }

        [HttpGet]
        public List<Post> getPostPriceDesc()
        {

            return _customerService.getPostPriceDesc();

        }

        [HttpGet]
        public List<Post> getPostPriceAsc()
        {

            return _customerService.getPostPriceAsc();

        }

        [HttpGet]
        public List<Post> getPost()
        {

            return _customerService.getPost();

        }
        
        [HttpPost]
        public void addReport(AddReport req)
        {
            _customerService.addReport(req);

        }

        [HttpGet]
        public List<Report> getReports()
        {

            return _customerService.getReports();

        }

        [HttpPost]
        public void acceptReport(int RID, int AdminId)
        {

             _customerService.acceptReport(RID, AdminId);

        }

        [HttpPost]
        public void denyReport(int RID, int AdminId)
        {

            _customerService.denyReport(RID, AdminId);

        }

        [HttpPost]
        public void blockPostByPID(int PID)
        {

            _customerService.blockPostByPID(PID);

        }

        [HttpPost]
        public void confirmPostByPID(int PID)
        {

            _customerService.confirmPostByPID(PID);

        }

        [HttpGet]
        public void getRecentPosts() {

            _customerService.getRecentPosts();

        }

        [HttpGet]
        public List<data> getPostData(int PID) {

           return _customerService.getPostData(PID);

        }

        [HttpPost]
        public void addDataToPost(addData req)
        {
            _customerService.addDataToPost(req);

        }

        [HttpPost]
        public void updateProfile(int UID,updateProfile req)
        {
            _customerService.updateProfile(UID,req);

        }

        [HttpGet]
        public List<Post> getPostUser(int UID) 
        {
             return _customerService.getPostUser(UID);
        
        }
        [HttpPost]
        public void addBussiness(addBussiness req) 
        {
            _customerService.addBussiness(req);
        }

        [HttpPost]
        public void deletePost(int PID) 
        {
            _customerService.deletePost(PID);
        }

        [HttpPost]
        public void deActiveUser(int UID)
        {
            _customerService.deActiveUser(UID);
        }
    }
}
