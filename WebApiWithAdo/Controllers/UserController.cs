using DataAccess;
using EnAndDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiWithAdo.Controllers
{
    public class UserController : ApiController
    {
        UserDBAccessLayer userDBAccessLayer = new UserDBAccessLayer();
        Base64 base64 = new Base64();

        [HttpGet]
        public List<UserEntities> GetAll()
        {
            return userDBAccessLayer.GetAllUsers();
        }

        [HttpGet]
        public UserEntities GetUserById(int id)
        {
            var user = userDBAccessLayer.GetAllUsers().Find(e => e.Id == id);
            user.PassWord = base64.Decrypt(user.PassWord);

            return user;
        }

        [HttpPost]
        public List<UserEntities> Add(UserEntities u)
        {  
            try
            {
                u.PassWord = base64.Encrypt(u.PassWord);
                userDBAccessLayer.AddUser(u);
                return userDBAccessLayer.GetAllUsers();
            }
            catch (Exception)
            {
                //code...
                return null;
            }

        }
        [HttpPut]
        public UserEntities UpdateUser(int id, UserEntities u)
        {
            var user = userDBAccessLayer.GetAllUsers().Find(e => e.Id == id);
            if (user == null)
            {
                return null;
            }
            try
            {
                user.FullName = u.FullName;
                user.UserName = u.UserName;
                user.PassWord = base64.Encrypt(u.PassWord);
                userDBAccessLayer.UpdateUser(id, user);
                return user;
            }
            catch (Exception)
            {
                //code...
                return null;
            }
        }

        [HttpDelete]
        public List<UserEntities> DeleteUser(int id)
        {
            var user = userDBAccessLayer.GetAllUsers().Find(e => e.Id == id);

            if (user == null)
            {
                return null;
            }
            try
            {
                userDBAccessLayer.DeleteUser(id);
                return userDBAccessLayer.GetAllUsers();
            }
            catch (Exception)
            {
                //code...
                return null;
            }

        }
    }
}
