using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LegoMobile
{
    public class APIService
    {
        Users.User currentUser;

        public bool loggedIn;

        /// <summary>
        /// This code fetches the API
        /// </summary>
        public async Task<bool> LoginRequest(string email, string password)
        {
            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
                form.Add(new StringContent(email), "email");
                form.Add(new StringContent(password), "password");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/login", form); // sending the http response from brickin-it 

                string content = await response.Content.ReadAsStringAsync(); // getting the http response from brickin-it 
                UserResponse login = JsonConvert.DeserializeObject<UserResponse>(content);

                currentUser = new Users.User(login.data.id, login.data.name, email, login.data.token);

                loggedIn = true;
                return login.success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> RegisterRequest(string name, string email, string password, string confirm_password)
        {
            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(email), "email");
                form.Add(new StringContent(password), "password");
                form.Add(new StringContent(confirm_password), "confirm_password");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/register", form);// // sending the http response from brickin-it 

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                UserResponse register = JsonConvert.DeserializeObject<UserResponse>(content);

                currentUser = new Users.User(register.data.id, register.data.name, email, register.data.token);

                loggedIn = true;
                return register.success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> LogoutRequest()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://brickin-it.herokuapp.com/api/logout"); // Create Http Request
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUser.Token); // Token Authentication 

                    var response = await client.SendAsync(requestMessage); // Send Request

                    string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                    UserResponse logout = JsonConvert.DeserializeObject<UserResponse>(content);

                    loggedIn = false;
                    return logout.success;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// Sets
        public async Task<Sets.Set> ShowSet(string setNumer)
        {
            var client = new HttpClient(); /// get the client id 

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/sets/look-up-by/number/" + setNumer); // Create Http Request
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
            Sets.Set setResponse = JsonConvert.DeserializeObject<Sets.Set>(content);

            return setResponse;
        }

        public async Task<bool> CreateSet(string name, string setNumber, Stream picture, int themeId, string barcode)
        {
            string pictureName = await UploadImage(picture);

            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(setNumber), "set_number");
                form.Add(new StringContent(pictureName), "picture");
                form.Add(new StringContent(themeId.ToString()), "theme_id");
                form.Add(new StringContent(barcode), "barcode");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/sets", form);// // sending the http response from brickin-it 

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                Sets.Set sets = JsonConvert.DeserializeObject<Sets.Set>(content);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<string> UploadImage(Stream picture)
        {
            var client = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
            form.Add(new StreamContent(picture), "file", "photo");

            var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/store-file", form);// // sending the http response from brickin-it 

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(content);

            return userResponse.file_name;
        }

        public async Task<List<Collections.Collection>> ShowCollections()
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/collections/user/" + currentUser.Id);
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

            List<Collections.Collection> collectionList = JsonConvert.DeserializeObject<List<Collections.Collection>>(content);

            return collectionList;
        }
    }
}
